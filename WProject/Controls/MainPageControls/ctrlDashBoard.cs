using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.Classes;
using WProject.Connection;
using WProject.Controls.MainPageControls.DashboardControls;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.Interfaces;
using WProject.Properties;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Style;
using WProject.UiLibrary.Theme;
using WProject.WebApiClasses.Classes;
using Task = System.Threading.Tasks.Task;

namespace WProject.Controls.MainPageControls
{
    public partial class ctrlDashBoard : MainPageControl
    {
        #region Fields

        private ctrlDashBoardSprings _springs;
        private ctrlDashBoardTasks _tasks;

        #endregion

        #region Properties

        public ctrlDashBoardTasks TasksControl => _tasks;

        #endregion

        #region Constructors

        public ctrlDashBoard()
        {
            InitializeComponent();

            _springs = new ctrlDashBoardSprings
            {
                Dock = DockStyle.Left
            };
            _tasks = new ctrlDashBoardTasks
            {
                Dock = DockStyle.Fill
            };
            WpPanel mpnlSeparator = new WpPanel
            {
                Dock = DockStyle.Left,
                Style = new UiStyle
                {
                    NormalStyle = new Style
                    {
                        BackColor = WpThemeColors.Blue
                    }
                },
                OwnStyle = true,
                Width = 10
            };

            _springs.RetractionChanged += visible => mpnlSeparator.Visible = visible;
            _springs.SelectedSpringOrCategoryChaged += SpringsOnSelectedSpringOrCategoryChaged;

            Controls.Add(_tasks);
            Controls.Add(mpnlSeparator);
            Controls.Add(_springs);
        }

        private async void SpringsOnSelectedSpringOrCategoryChaged(Spring spring, Category category)
        {
            WPSuite.SelectedSpring = spring;
            WPSuite.SelectedCategory = category;

            Settings.Default.LastSelectedSpringId = spring?.Id ?? 0;
            Settings.Default.LastSelectedCategoryId = category?.Id ?? 0;

            Settings.Default.Save();

            _tasks.CanAddBacklog = Settings.Default.LastSelectedCategoryId != 0;

            await _tasks.LoadTasks(spring, category);
        }

        #endregion
        
        #region Implementation of IMainPageControl

        public override Pages Page => Pages.DashBoard;

        #endregion

        #region Overrides of MainPageControl

        public override void SetProject(Project project)
        {
            ShowDashBoardForProject(project);
        }

        protected override async void OnStatusBarChatClick()
        {
            await ShowChatWindow();
        }

        public override string[] StatusBarTexts => new[]
        {
            GetCountTasks(WebApiClasses.Classes.Task.States.TO_DO_CODE, "in to do"),
            GetCountTasks(WebApiClasses.Classes.Task.States.IN_PROGRESS_CODE, "in progress"),
            GetCountTasks(WebApiClasses.Classes.Task.States.DONE_CODE, "done")
        };

        #endregion

        #region Private methods

        private async void ShowDashBoardForProject(Project project)
        {
            Logger.Log("ctrlDashBoard > " + project.Name);
            await _springs.SetProject(project);
        }
        
        private async System.Threading.Tasks.Task ShowChatWindow()
        {
            Logger.Log("ctrlDashBoard > Show chat window");
            try
            {
                var mr = await WebCallFactory.TestMethod();

                Logger.Log(mr.ErrorCode > 0 ? mr.Error : mr.Content);
            }
            catch (Exception mex)
            {
                Logger.Log(mex);
            }
        }

        private string GetCountTasks(string taskState, string state)
        {
            var mcount = _tasks.BacklogControls
                               .Where(bc =>
                               {
                                   var mstate = bc?.State;
                                   if (mstate == null)
                                       return false;

                                   return mstate.Code == Backlog.States.BCK_STATE_TO_DO ||
                                          mstate.Code == Backlog.States.BCK_STATE_IN_PROGR;
                               })
                               .SelectMany(bc => bc.TaskControls)
                               .Count(tc => tc.OwnedBy?.Id == WPSuite.ConnectedUserId &&
                                            tc.State?.Code == taskState);

            if (mcount == 0)
                return "No task " + state;

            string mtask = "tasks";

            if (mcount == 1)
                mtask = "task";

            return $"{mcount} {mtask} {state}";
        }

        #endregion

        #region Public methods

        public async Task RefreshTasks()
        {
            await _tasks.LoadTasks(WPSuite.SelectedSpring, WPSuite.SelectedCategory);
        }

        #endregion

    }
    
}
