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
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.Properties;
using WProject.UiLibrary;
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
                Location = new Point(pbColapse.Right + 2, pbColapse.Top),
                Visible = false
            };

            _collapsed = true;

            //Controls.Add(ctrlDashBoardBacklogItemControl);

            pbColapse.Style.NormalStyle.Cursor = Cursors.Hand;

            DoubleBuffered = true;
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
            DefaultSize = new Size(ctrlDashBoardBacklogItemControl.DefaultSize.Width + 10, 
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

                //ctrlDashBoardBacklogItemControl.Visible = Collapsed;

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

            using (Brush mb = new SolidBrush(WpThemeColors.Shadow))
            {
                e.Graphics.DrawString("1 task not started ~ 2h",
                                      WpThemeFonts.DefaultBackLogTasksInfo,
                                      mb,
                                      Columns.ToDoLeft(Width),
                                      pbColapse.Bottom + 8);

                e.Graphics.DrawString("1 task in progress ~ 1h",
                                      WpThemeFonts.DefaultBackLogTasksInfo,
                                      mb,
                                      Columns.InProgressLeft(Width),
                                      pbColapse.Bottom + 8);

                e.Graphics.DrawString("8 tasks done ~ 16h",
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
            Collapsed = !Collapsed;
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
                        flwToDo.Controls.Add(mc);
                }
            }
            finally
            {
                flwDone.ResumeLayout();
                flwInProgress.ResumeLayout();
                flwToDo.ResumeLayout();
            }
        }

        private Control CreateTaskControl(Task task)
        {
            return new ctrlDashBoardTaskItem(task)
            {
                Size = ctrlDashBoardTaskItem.DefaultSize
            };
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
