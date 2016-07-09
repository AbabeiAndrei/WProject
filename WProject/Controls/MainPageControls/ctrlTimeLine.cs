using System.Drawing;
using System.Windows.Forms;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.Interfaces;
using WProject.WebApiClasses.Classes;

namespace WProject.Controls.MainPageControls
{
    public sealed partial class ctrlTimeLine : MainPageControl
    {
        #region Constructors

        public ctrlTimeLine()
        {
            InitializeComponent();

            StatusBarVisibility.Visible = false;
        }

        #endregion

        #region Implementation of IMainPageControl

        public override Pages Page => Pages.TimeLine;

        #endregion

        #region Overrides of MainPageControl
        
        public override void SetProject(Project project)
        {
            SetTimeLineForProject(project);
        }
        
        protected override void OnStatusBarChatClick()
        {
            ShowChatsWindow();
        }

        #endregion

        #region Private methods

        private void SetTimeLineForProject(Project project)
        {
            Logger.Log("ctrlTimeLine > " + project.Name);
        }

        private void ShowChatsWindow()
        {
            Logger.Log("ctrlTimeLine > ShowChatsWindow (NOT IMPLEMENTED)");
        }

        #endregion

    }
}
