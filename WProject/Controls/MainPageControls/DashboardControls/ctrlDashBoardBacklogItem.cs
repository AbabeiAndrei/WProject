using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.Classes;
using WProject.Connection;
using WProject.GenericLibrary.Helpers;
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.Properties;
using WProject.UiLibrary;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Theme;
using WProject.WebApiClasses.Classes;
using Task = WProject.WebApiClasses.Classes.Task;

namespace WProject.Controls.MainPageControls.DashboardControls
{
    public partial class ctrlDashBoardBacklogItem : WpUserControl
    {
        #region Fields

        private Backlog _backLog;
        private bool _collapsed;
        private DashBoardColumnsCollectionSize _columns;
        private ctrlDashBoardBacklogItemControl ctrlDashBoardBacklogItemControl;

        public new static Size DefaultSize { get; }
        
        #endregion

        #region Properties

        public Backlog BackLog
        {
            get
            {
                return _backLog;
            }
            set
            {
                _backLog = value;

                InitStuff();
            }
        }

        public bool Collapsed
        {
            get
            {
                return _collapsed;
            }
            set
            {
                _collapsed = value;
                OnCollaptionChange?.Invoke(this, new BacklogCollaptionChangedArgs(_collapsed));
                pbColapse.Image = _collapsed
                                      ? Resources.expand_l
                                      : Resources.tree_l;

                RecalculateSize();
                Refresh();
            }
        }

        public DashBoardColumnsCollectionSize Columns
        {
            get
            {
                return _columns;
            }
            set
            {
                _columns = value;
                RecalculateSize();
                Refresh();
            }
        }

        public event BacklogCollaptionChanged OnCollaptionChange;

        #endregion
        
        #region Constructors

        public ctrlDashBoardBacklogItem()
        {
            InitializeComponent();

            ctrlDashBoardBacklogItemControl = new ctrlDashBoardBacklogItemControl
            {
                Location = new Point(pbColapse.Right + 6, pbColapse.Top),
                Size = new Size(380, 160),
                Visible = false
            };

            _collapsed = true;

            Controls.Add(ctrlDashBoardBacklogItemControl);

            pbColapse.Style.NormalStyle.Cursor = Cursors.Hand;

            DoubleBuffered = true;

            flwToDo.Tag = Task.TO_DO_CODE;
            flwInProgress.Tag = Task.IN_PROGRESS_CODE;
            flwDone.Tag = Task.DONE_CODE;
        }

        public ctrlDashBoardBacklogItem(Backlog backLog)
            : this()
        {
            _backLog = backLog;

            ctrlDashBoardBacklogItemControl.Backlog = backLog;

            Columns = new DashBoardColumnsCollectionSize();
        }

        static ctrlDashBoardBacklogItem()
        {
            DefaultSize = new Size(ctrlDashBoardBacklogItemControl.DefaultSize.Width + 100, 
                                   ctrlDashBoardBacklogItemControl.DefaultSize.Height);
        }

        #endregion

        #region Overrides of WpStyledControl

        protected override async void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (BackLog == null)
                    return;

                ctrlDashBoardBacklogItemControl.Visible = !Collapsed;

                if (Collapsed)
                    await PaintOnColapsed(e);
            }
            finally
            {
                base.OnPaint(e);
            }

        }

        private async System.Threading.Tasks.Task PaintOnColapsed(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(WpThemeColors.Blue.SetOpacity(40)), 0, 0, Width, Height);

            if (BackLog.Type?.Color != null)
                try
                {
                    using (Brush mb = new SolidBrush(BackLog.Type.Color.Value))
                        e.Graphics.FillRectangle(mb, pbColapse.Right + 1, 6, 6, pbColapse.Height);
                }
                catch
                {
                    //ignored
                }

            e.Graphics.DrawString(BackLog.Name ?? string.Empty,
                                  WpThemeFonts.DefaultBackLogNameFont,
                                  Brushes.Black,
                                  pbColapse.Right + 10,
                                  4);

            Task<Image> mtask = BackLog?.AssignedTo?.Avatar?.GetImageAsync();
            if (mtask != null)
            {
                var mimage = await mtask;
                if (mimage != null)
                    e.Graphics.DrawImage(mimage, new RectangleF(pbColapse.Right, pbColapse.Bottom + 6, 16, 16));
            }

            e.Graphics.DrawString(BackLog.AssignedTo?.Name ?? string.Empty,
                                  WpThemeFonts.DefaultBackLogFont,
                                  Brushes.Black,
                                  pbColapse.Right + 20,
                                  pbColapse.Bottom + 8);

            if (_backLog.Tasks == null && Columns.Sum < 3)
                return;

            var mtodoCount = flwToDo.Controls.Count;
            var mtodoHours = flwToDo.Controls
                                    .OfType<ctrlDashBoardTaskItem>()
                                    .Select(c => c.Task?.RemainingWork.GetValueOrDefault(0) ?? 0)
                                    .DefaultIfEmpty(0)
                                    .Sum();

            var minProgressCount = flwInProgress.Controls.Count;
            var minProgressHours = flwInProgress.Controls
                                                .OfType<ctrlDashBoardTaskItem>()
                                                .Select(c => c.Task?.RemainingWork.GetValueOrDefault(0) ?? 0)
                                                .DefaultIfEmpty(0)
                                                .Sum();

            var mdoneCount = flwDone.Controls.Count;
            var mdoneHours = flwDone.Controls
                                    .OfType<ctrlDashBoardTaskItem>()
                                    .Select(c => c.Task?.RemainingWork.GetValueOrDefault(0) ?? 0)
                                    .DefaultIfEmpty(0)
                                    .Sum();


            const string mtasksText = "tasks";
            const string mtaskText = "task";

            using (Brush mb = new SolidBrush(WpThemeColors.Shadow))
            {
                string mtasksTest = mtodoCount > 1 ? mtasksText : mtaskText;
                string mtime = mtodoHours > 0 ? $"~ {Utils.MinutesToTime(mtodoHours)}" : string.Empty;

                if(mtodoCount > 0)
                    e.Graphics.DrawString($"{mtodoCount} {mtasksTest} not started {mtime}",
                                          WpThemeFonts.DefaultBackLogTasksInfo,
                                          mb,
                                          Columns.ToDoLeft(Width),
                                          pbColapse.Bottom + 8);

                mtasksTest = minProgressCount > 1 ? mtasksText : mtaskText;
                mtime = minProgressHours > 0 ? $"~ {Utils.MinutesToTime(minProgressHours)}" : string.Empty; 

                if(minProgressCount > 0)
                    e.Graphics.DrawString($"{minProgressCount} {mtasksTest} in progress {mtime}",
                                          WpThemeFonts.DefaultBackLogTasksInfo,
                                          mb,
                                          Columns.InProgressLeft(Width),
                                          pbColapse.Bottom + 8);

                mtasksTest = mdoneCount > 1 ? mtasksText : mtaskText;
                mtime = mdoneHours > 0 ? $"~ {Utils.MinutesToTime(mdoneHours)}" : string.Empty;
                if (mdoneCount > 0)
                    e.Graphics.DrawString($"{mdoneCount} {mtasksTest} tasks done {mtime}",
                                          WpThemeFonts.DefaultBackLogTasksInfo,
                                          mb,
                                          Columns.DoneLeft(Width),
                                          pbColapse.Bottom + 8);
            }
        }
        
        #endregion

        #region Events
        
        private void ctrlDashBoardBacklogItem_Load(object sender, EventArgs e)
        {
            InitStuff();
        }

        private void pbColapse_Click(object sender, EventArgs e)
        {
            ToggleExpand();
        }

        private void ctrlTaskItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                DoDragDrop(sender, DragDropEffects.Move);
        }

        private void flwDragEfect_Enter(object sender, DragEventArgs e)
        {
            FlowLayoutPanel mp = sender as FlowLayoutPanel;

            if (mp == null)
                return;

            if (e.Data.GetData(typeof(ctrlDashBoardTaskItem)) == null)
                return;

            e.Effect = DragDropEffects.Move;

            mp.BackColor = WpThemeColors.Yellow.SetOpacity(100);
        }

        private void flwDragEfect_Leave(object sender, EventArgs e)
        {
            FlowLayoutPanel mp = sender as FlowLayoutPanel;

            if (mp == null)
                return;

            mp.BackColor = Color.Transparent;
        }

        private async void flwDragEfect_Drop(object sender, DragEventArgs e)
        {
            FlowLayoutPanel mp = sender as FlowLayoutPanel;

            if (mp?.Tag == null)
                return;

            ctrlDashBoardTaskItem mc = e.Data.GetData(typeof(ctrlDashBoardTaskItem)) as ctrlDashBoardTaskItem;

            if (mc == null)
                return;

            mp.BackColor = Color.Transparent;

            if (mc.Parent == mp)
                return;

            var moldParent = mc.Parent;
            mc.Parent = mp;

            if (!await ChangeTaskState(mc.Task, mp.Tag.ToString()))
                mc.Parent = moldParent;
        }

        #endregion

        #region Private methods

        private void InitStuff()
        {
            if (_backLog.Tasks == null)
                return;

            try
            {
                flwToDo.SuspendLayout();
                flwInProgress.SuspendLayout();
                flwDone.SuspendLayout();

                foreach (var mtask in _backLog.Tasks.Where(t => t.State != null))
                {
                    var mc = CreateTaskControl(mtask);

                    if (mtask.State.Code == Task.TO_DO_CODE)
                        flwToDo.Controls.Add(mc);
                    else if (mtask.State.Code == Task.IN_PROGRESS_CODE)
                        flwInProgress.Controls.Add(mc);
                    else if (mtask.State.Code == Task.DONE_CODE)
                        flwDone.Controls.Add(mc);
                }
            }
            finally
            {
                flwDone.ResumeLayout();
                flwInProgress.ResumeLayout();
                flwToDo.ResumeLayout();
                Refresh();
            }
        }

        private Control CreateTaskControl(Task task)
        {
            var mtsk = new ctrlDashBoardTaskItem(task)
            {
                Size = ctrlDashBoardTaskItem.DefaultSize,
                AllowDrop = true
            };

            mtsk.MouseUp += (sender, args) =>
            {
                var mte = sender as ctrlDashBoardTaskItem;

                if (mte?.Task != null)
                    UIHelper.ShowTaskEditor(mte.Task.Id, task1 => {}, parentForm:ParentForm);
            };

            mtsk.MouseDown += ctrlTaskItem_MouseDown;

            return mtsk;
        }

        private void RecalculateSize()
        {
            try
            {
                flwToDo.Visible =
                    flwInProgress.Visible =
                    flwDone.Visible = !Collapsed;

                if (Collapsed)
                {
                    Height = 60;
                    return;
                }
                int mheight = 150;
                if (_backLog.Tasks != null)
                    mheight = Math.Max(_backLog.Tasks
                                               .GroupBy(t => t.StateId)
                                               .Select(t => t.Count())
                                               .DefaultIfEmpty(0)
                                               .Max(t => t)*120,
                                       mheight);
                Height = mheight + 8;

                flwToDo.Width = Columns.ToDoWidth;
                flwInProgress.Width = Columns.InProgressWitdh;
                flwDone.Width = Columns.DoneWidth;
            }
            finally
            {
                flwDone.BringToFront();
                flwInProgress.BringToFront();
                flwToDo.BringToFront();
            }
        }

        private static async Task<bool> ChangeTaskState(Task task, string newState)
        {
            if (task == null)
                return false;

            try
            {
                Logger.Log($"Change task {task.Id} state from {task.State?.Code} to {newState}");
                var mres = await WebCallFactory.ChangeTaskState(task.Id, newState);
            
                if(!mres.Error)
                    Logger.Log("Success!");

                return !mres.Error;
            }
            catch (Exception mex)
            {
                Logger.Log("Error!");
                Logger.Log(mex);
                return false;
            }
        }

        #endregion

        #region Public methods

        public void ToggleExpand()
        {
            Collapsed = !Collapsed;
        }

        public void Expand(bool expanded = true)
        {
            Collapsed = !expanded;
        }

        public void Collapse(bool collapsed = true)
        {
            Collapsed = collapsed;
        }

        #endregion

    }

    public delegate void BacklogCollaptionChanged(object sender, BacklogCollaptionChangedArgs args);

    public class BacklogCollaptionChangedArgs
    {
        public bool Collapsed { get; set; }

        public BacklogCollaptionChangedArgs(bool collapsed)
        {
            Collapsed = collapsed;
        }
    }
}
