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
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.Properties;
using WProject.UiLibrary;
using WProject.UiLibrary.Classes;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Helpers;
using WProject.UiLibrary.Theme;
using WProject.WebApiClasses.Classes;
using WProject.WebApiClasses.Data;
using Task = WProject.WebApiClasses.Classes.Task;
using Utils = WProject.GenericLibrary.Helpers.Utils;

namespace WProject.Controls.MainPageControls.DashboardControls
{
    public partial class ctrlDashBoardBacklogItem : WpUserControl
    {
        #region Fields

        public const int MIN_HEIGHT_FOR_BACKLOG_OPEN = 160;

        private Backlog _backlog;
        private bool _collapsed;
        private DashBoardColumnsCollectionSize _columns;
        private readonly ctrlDashBoardBacklogItemControl ctrlDashBoardBacklogItemControl;
        private bool _onDrag;

        public new static Size DefaultSize { get; }
        
        #endregion

        #region Properties

        public Backlog Backlog
        {
            get
            {
                return _backlog;
            }
            set
            {
                _backlog = value;

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
                btnAddTask.Visible = !_collapsed;

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

        public Action<Backlog, Action> OnAddClick { get; set; }

        public IEnumerable<ctrlDashBoardTaskItem> TaskControls => flwToDo.Controls
                                                                         .OfType<ctrlDashBoardTaskItem>()
                                                                         .Union(flwInProgress.Controls
                                                                                             .OfType<ctrlDashBoardTaskItem>())
                                                                         .Union(flwDone.Controls
                                                                                       .OfType<ctrlDashBoardTaskItem>());

        public DictItem State => ctrlDashBoardBacklogItemControl?.State;

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

            ctrlDashBoardBacklogItemControl.Click += OnDashBoardBacklogItemControl_Click;

            _collapsed = true;

            Controls.Add(ctrlDashBoardBacklogItemControl);

            pbColapse.Style.NormalStyle.Cursor = Cursors.Hand;

            DoubleBuffered = true;

            flwToDo.Tag = Task.States.TO_DO_CODE;
            flwInProgress.Tag = Task.States.IN_PROGRESS_CODE;
            flwDone.Tag = Task.States.DONE_CODE;
        }

        public ctrlDashBoardBacklogItem(Backlog backlog)
            : this()
        {
            _backlog = backlog;

            ctrlDashBoardBacklogItemControl.Backlog = backlog;

            Columns = new DashBoardColumnsCollectionSize();
        }

        static ctrlDashBoardBacklogItem()
        {
            DefaultSize = new Size(ctrlDashBoardBacklogItemControl.DefaultSize.Width + 100, 
                                   ctrlDashBoardBacklogItemControl.DefaultSize.Height);
        }

        #endregion

        #region Overrides of WpStyledControl

        public override void ApplyStyle()
        {
            btnAddTask?.ApplyStyle();

            base.ApplyStyle();
        }

        protected override async void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (Backlog == null)
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
            //e.Graphics.FillRectangle(new SolidBrush(WpThemeColors.Blue.SetOpacity(40)), 0, 0, Width, Height);

            if (Backlog.Type?.Color != null)
                try
                {
                    using (Brush mb = new SolidBrush(Backlog.Type.Color.Value))
                        e.Graphics.FillRectangle(mb, pbColapse.Right + 1, 6, 6, pbColapse.Height);
                }
                catch
                {
                    //ignored
                }

            e.Graphics.DrawString(Backlog.Name ?? string.Empty,
                                  WpThemeFonts.DefaultBackLogNameFont,
                                  Brushes.Black,
                                  pbColapse.Right + 10,
                                  4);

            Task<Image> mtask = Backlog?.AssignedTo?.Avatar?.GetImageAsync();
            if (mtask != null)
            {
                var mimage = await mtask;
                if (mimage != null)
                    e.Graphics.DrawImage(mimage, new RectangleF(pbColapse.Right, pbColapse.Bottom + 6, 16, 16));
            }

            e.Graphics.DrawString(Backlog.AssignedTo?.Name ?? string.Empty,
                                  WpThemeFonts.DefaultBackLogFont,
                                  Brushes.Black,
                                  pbColapse.Right + 20,
                                  pbColapse.Bottom + 8);

            if (_backlog.Tasks == null && Columns.Sum < 3)
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
        
        private void flwDragEfect_Enter(object sender, DragEventArgs e)
        {
            FlowLayoutPanel mp = sender as FlowLayoutPanel;

            if (mp == null)
                return;

            if (e.Data.GetData(typeof(ctrlDashBoardTaskItem)) == null)
                return;

            e.Effect = DragDropEffects.Move;

            mp.BackColor = WpThemeColors.Yellow.SetOpacity(100);
            _onDrag = true;
        }

        private void flwDragEfect_Leave(object sender, EventArgs e)
        {
            FlowLayoutPanel mp = sender as FlowLayoutPanel;

            if (mp == null)
                return;

            mp.BackColor = Color.Transparent;
            _onDrag = false;
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

            if (!await ChangeTaskState(mc.Task, mp.Tag.ToString())) //daca nu a reusit mutarea 
                mc.Parent = moldParent;
            else
                AfterTaskEdit();

            _onDrag = false;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            OnAddClick?.Invoke(Backlog, InitStuff); //todo metoda de adaugare separata (de schimbat InitStuff-ul cu o metoda specializata)
        }

        private void ctrlDashBoardBacklogItem_SizeChanged(object sender, EventArgs e)
        {
            btnAddTask.Top = Height - btnAddTask.Height - 2;
        }
        
        private void OnDashBoardBacklogItemControl_Click(object sender, EventArgs eventArgs)
        {
            UIHelper.ShowBackLogEditor(Backlog, async backlog => SetBacklog(backlog));
        }

        #endregion

        #region Private methods

        private void InitStuff()
        {
            if (_backlog.Tasks == null)
                return;

            try
            {
                flwToDo.SuspendLayout();
                flwInProgress.SuspendLayout();
                flwDone.SuspendLayout();

                ClearTasks();

                foreach (var mtask in _backlog.Tasks.Where(t => t.State != null))
                {
                    var mc = CreateTaskControl(mtask);

                    if (mtask.State.Code == Task.States.TO_DO_CODE)
                        flwToDo.Controls.Add(mc);
                    else if (mtask.State.Code == Task.States.IN_PROGRESS_CODE)
                        flwInProgress.Controls.Add(mc);
                    else if (mtask.State.Code == Task.States.DONE_CODE)
                        flwDone.Controls.Add(mc);
                }

                AfterTaskEdit();
            }
            finally
            {
                flwDone.ResumeLayout();
                flwInProgress.ResumeLayout();
                flwToDo.ResumeLayout();
                Refresh();
            }
        }

        private void ClearTasks()
        {
            flwToDo.Controls.Clear();
            flwInProgress.Controls.Clear();
            flwDone.Controls.Clear();
        }

        private Control CreateTaskControl(Task task)
        {
            var mtsk = new ctrlDashBoardTaskItem(task)
            {
                Size = ctrlDashBoardTaskItem.DefaultSize,
                AllowDrop = true
            };

            mtsk.Click += (sender, args) =>
            {
                var mte = sender as ctrlDashBoardTaskItem;

                if (mte?.Task != null)
                    UIHelper.ShowTaskEditor(mte.Task, async t =>
                    {
                        mte.SetTask(t);
                        AfterTaskEdit();
                    }, parentForm:ParentForm);
            };

            mtsk.MouseMove += (sender, args) =>
            {
                if (args.Button == MouseButtons.Left)
                    DoDragDrop(sender, DragDropEffects.Move);
            };
            
            return mtsk;
        }

        private void AfterTaskEdit()
        {
            UIHelper.UpdateStatusBarTexts();
            if(!Collapsed)
                Height = CalculateSize();
        }

        private int CalculateSize()
        {
            return Math.Max(new[]
            {
                UIHelper.GetTopMostItem(flwToDo, Direction.Down),
                UIHelper.GetTopMostItem(flwInProgress, Direction.Down),
                UIHelper.GetTopMostItem(flwDone, Direction.Down)
            }.DefaultIfEmpty(Height)
             .Max(), MIN_HEIGHT_FOR_BACKLOG_OPEN);
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
                Height = CalculateSize();

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

                if (!mres.Error)
                {
                    Logger.Log("Success!");
                    task.State = SimpleCache.FirstOrDefault<DictItem>(di => di.IsType(DictItem.Types.TaskState) && di.Code == newState);
                }

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

        public void AddTask(Task task)
        {
            var mc = CreateTaskControl(task);

            var mnewState = SimpleCache.GetAll<DictItem>()
                                       .FirstOrDefault(di => di.Id == task.StateId);

            if(mnewState == null)
                return;

            if (mnewState.Code == Task.States.TO_DO_CODE)
                flwToDo.Controls.Add(mc);
            else if (mnewState.Code == Task.States.IN_PROGRESS_CODE)
                flwInProgress.Controls.Add(mc);
            else if (mnewState.Code == Task.States.DONE_CODE)
                flwDone.Controls.Add(mc);

            AfterTaskEdit();
        }

        public void SetTaskState(Task task, int stateId)
        {
            var mctrl = TaskControls.FirstOrDefault(tc => tc.Task.Id == task.Id);

            if(mctrl?.Task == null || mctrl.Task.StateId == stateId)
                return;

            var mnewState = SimpleCache.GetAll<DictItem>()
                                       .FirstOrDefault(di => di.Id == stateId);

            if(mnewState == null)
                return;

            if (mnewState.Code == Task.States.TO_DO_CODE)
                mctrl.Parent = flwToDo;
            else if(mnewState.Code == Task.States.IN_PROGRESS_CODE)
                mctrl.Parent = flwInProgress;
            else if (mnewState.Code == Task.States.DONE_CODE)
                mctrl.Parent = flwDone;
            else if (mnewState.Code == Task.States.REMOVED_CODE)
                mctrl.Dispose();

            AfterTaskEdit();
        }

        public void SetBacklog(Backlog backlog)
        {
            ctrlDashBoardBacklogItemControl.SetBacklog(backlog);
        }

        #endregion
    }

}
