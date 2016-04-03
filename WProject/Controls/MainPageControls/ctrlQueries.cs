using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.WebApiClasses.Classes;

namespace WProject.Controls.MainPageControls
{
    public partial class ctrlQueries : MainPageControl
    {
        #region Constructors

        public ctrlQueries()
        {
            InitializeComponent();
        }

        #endregion

        #region Implementation of IMainPageControl

        public override Pages Page => Pages.Queries;

        #endregion

        #region Overrides of MainPageControl

        public override bool CanChangeProject => false;

        public override void SetProject(Project project)
        {
            Logger.Log("ctrlQueries > " + project.Name);
        }

        protected override void OnStatusBarChatClick()
        {
            ShowChatsWindow();
        }

        #endregion
        
        #region Private methods

        private void ShowChatsWindow()
        {
            Logger.Log("ctrlQueries > ShowChatsWindow (NOT IMPLEMENTED)");
        }

        #endregion

    }
}
