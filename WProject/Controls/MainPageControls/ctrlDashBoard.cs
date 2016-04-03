using System;
using System.Drawing;
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

namespace WProject.Controls.MainPageControls
{
    public partial class ctrlDashBoard : MainPageControl
    {
        #region Fields

        private ctrlDashBoardSprings _springs;
        private ctrlDashBoardTasks _tasks;

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
            "0 Tasks in queue",
            "1 Task in progress",
            "25 Tasks completed today"
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

        #endregion
    }
    
}
