using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using WProject.Classes;
using WProject.Connection;
using WProject.Controls.MainPageControls.TimeLineControls;
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.Interfaces;
using WProject.UiLibrary.Classes;
using WProject.UiLibrary.Components;
using WProject.UiLibrary.Theme;
using WProject.WebApiClasses.Classes;

namespace WProject.Controls.MainPageControls
{
    public sealed partial class ctrlTimeLine : MainPageControl
    {
        #region Fields

        private IEnumerable<Task> _tasks;
        private IEnumerable<Backlog> _backlogs;
        private readonly ctrlTimeLineRowHeader ctrlTimeLineRowHeader;
        private readonly ctrlTimeLineTasks ctrlTimeLineTasks;

        #endregion

        #region Properties

        public bool Loaded { get; set; }

        public IEnumerable<Task> Tasks => _tasks ?? Enumerable.Empty<Task>();
        public IEnumerable<Backlog> Backlogs => _backlogs ?? Enumerable.Empty<Backlog>();
        public ctrlTimeLineTasks RowsControl => ctrlTimeLineTasks;


        #endregion

        #region Constructors

        public ctrlTimeLine()
        {
            InitializeComponent();

            StatusBarVisibility.Visible = false;

            ctrlTimeLineTasks = new ctrlTimeLineTasks
            {
                Name = nameof(ctrlTimeLineTasks),
                Dock = DockStyle.Fill,
                StartHour = 8,
                EndHour = 17
            };

            ctrlTimeLineRowHeader = new ctrlTimeLineRowHeader
            {
                Name = nameof(ctrlTimeLineRowHeader),
                Dock = DockStyle.Left,
                Size = new Size(250, 0),
                TopPadding = ctrlTimeLineTasks.HEADER_SIZE
            };


            ctrlTimeLineRowHeader.OnRowElaptionChanged += ctrlTimeLineRowHeader_OnRowElaptionChanged;
            ctrlTimeLineRowHeader.BacklogMouseEnter += ctrlTimeLineRowHeaderOnBacklogMouseEnter;

            Controls.Add(ctrlTimeLineRowHeader);
            Controls.Add(ctrlTimeLineTasks);

            ctrlTimeLineRowHeader.BacklogMouseEnter += (backlogId, userId, color) => ctrlTimeLineTasks.SetBacklogHover(backlogId, userId, color);
            ctrlTimeLineTasks.BringToFront();
            ctrlTimeLineTasks.PerformResizeWidth();
        }

        private void ctrlTimeLineRowHeaderOnBacklogMouseEnter(int backlogId, int userId, Color color)
        {
            foreach (var mcontrol in ctrlTimeLineRowHeader.Users.SelectMany(u => u.Backlog).Where(b => b.BacklogId == backlogId && b.UserId == userId))
                mcontrol.BackColor = color;

            foreach (var mcontrol in ctrlTimeLineTasks.Users.SelectMany(u => u.BacklogControls).Where(b => b.BacklogId == backlogId && b.UserId == userId))
                mcontrol.BackColor = color;
        }

        #endregion

        #region Implementation of IMainPageControl

        public override Pages Page => Pages.TimeLine;

        #endregion

        #region Overrides of MainPageControl
        
        public override async void SetProject(Project project)
        {
            await SetTimeLineForProject(project);
        }
        
        protected override void OnStatusBarChatClick()
        {
            ShowChatsWindow();
        }

        public override async void OnPageSelected()
        {
            //if (!Loaded)  todo de scos
            await LoadTasks();
        }

        #endregion

        #region Overrides of WpStyledControl

        public override void ApplyStyle()
        {
            base.ApplyStyle();

            ctrlTimeLineRowHeader?.ApplyStyle();
            ctrlTimeLineTasks?.ApplyStyle();
        }

        #endregion

        #region Overrides of UserControl

        protected override void OnResize(EventArgs e)
        {
            try
            {
                if(ctrlTimeLineRowHeader == null || ctrlTimeLineTasks == null)
                    return;

                int mheight = ctrlTimeLineRowHeader.ResizeControls();

                ctrlTimeLineTasks.PerformResizeWidth(ctrlTimeLineTasks.ClientSize.Width - 1);
                ctrlTimeLineTasks.PerformResizeHeigh(Math.Max(mheight, ctrlTimeLineTasks.ClientSize.Height - 1));
            }
            finally
            {
                base.OnResize(e);
            }
        }

        #endregion

        #region Event handlers

        private void ctrlTimeLineRowHeader_OnRowElaptionChanged(object sender, TimeLineRowHeaderExpandArgs args)
        {
            if (ctrlTimeLineRowHeader == null || ctrlTimeLineTasks == null)
                return;

            ctrlTimeLineTasks.SetExpanded(args.UserId, args.Expanded);

            int mheight = ctrlTimeLineRowHeader.ResizeControls();

            ctrlTimeLineTasks.PerformResizeWidth(ctrlTimeLineTasks.ClientSize.Width - 1);
            ctrlTimeLineTasks.PerformResizeHeigh(Math.Max(mheight, ctrlTimeLineTasks.ClientSize.Height - 1));
        }
        
        #endregion

        #region Private methods

        private async System.Threading.Tasks.Task SetTimeLineForProject(Project project)
        {
            Logger.Log("ctrlTimeLine > " + project.Name);
            await SetTasks(project.Id);
        }

        private async System.Threading.Tasks.Task SetTasks(int projectId)
        {
            try
            {
                UIHelper.ShowLoader("Load tasks...");
                Logger.Log($"Get tasks for project {projectId}");


                var mres = await WebCallFactory.GetAllBackLogsForToday(projectId);

                if (mres.Error)
                    throw mres.Exception;

                Logger.Log("Success get tasks");

                SetTasks(mres.Tasks);

                Logger.Log("Success load tasks");
            }
            catch (Exception mex)
            {
                UIHelper.HideLoader();
                Logger.Log(mex);
                UIHelper.ShowError(mex);
            }
            finally
            {
                UIHelper.HideLoader();
            }
        }

        private void ShowChatsWindow()
        {
            Logger.Log("ctrlTimeLine > ShowChatsWindow (NOT IMPLEMENTED)");
        }

        #endregion

        #region Public methods

        public async System.Threading.Tasks.Task LoadTasks()
        {
            await SetTasks(WPSuite.SelectedProjectId);
        }

        public void SetTasks(IEnumerable<Task> task)
        {
            try
            {
                Loaded = true;

                _tasks = task.Where(t => t.StartHour.HasValue);

                ctrlTimeLineRowHeader.SuspendLayout();

                ctrlTimeLineRowHeader.ClearItems();
                ctrlTimeLineTasks.ClearItems();

                ctrlTimeLineRowHeader.SetTasks(_tasks, ctrlTimeLineTasks);

                int mheight = ctrlTimeLineRowHeader.ResizeControls();

                ctrlTimeLineTasks.PerformResizeHeigh(Math.Max(mheight, ctrlTimeLineTasks.ClientSize.Height));

                ctrlTimeLineTasks.RepositionControls(ctrlTimeLineRowHeader);
                ctrlTimeLineTasks.ExpandAll(false, WPSuite.ConnectedUserId);
                ctrlTimeLineTasks.SetExpanded(WPSuite.ConnectedUserId, true);
            }
            finally
            {
                ctrlTimeLineRowHeader.ResumeLayout();
            }
        }

        public void ExpandAll()
        {
            ctrlTimeLineTasks.ExpandAll(false, WPSuite.ConnectedUserId);
            ctrlTimeLineTasks.SetExpanded(WPSuite.ConnectedUserId, true);
        }

        #endregion

    }
}
