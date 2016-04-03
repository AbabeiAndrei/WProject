using System;
using WProject.Classes;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.WebApiClasses.Classes;

namespace WProject.Controls.MainPageControls
{
    public partial class ctrlAdmin : MainPageControl
    {
        #region Constructors

        public ctrlAdmin()
        {
            InitializeComponent();

            StatusBarVisibility = new StatusBarVisbility
            {
                ShowChatsIcon = false
            };
        }

        #endregion

        #region Implementation of IMainPageControl

        public override Pages Page => Pages.Admin;

        #endregion

        #region Overrides of MainPageControl

        public override StatusBarVisbility StatusBarVisibility { get; }

        public override void SetProject(Project project)
        {
            ShowSettingsForProject(project);
        }

        #endregion

        #region Private methods

        private void ShowSettingsForProject(Project project)
        {
            Logger.Log("ctrlAdmin > " + project.Name);
        }

        #endregion

    }
}
