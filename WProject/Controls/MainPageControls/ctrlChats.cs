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
using WProject.Controls.MainPageControls;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.WebApiClasses.Classes;

namespace WProject.Controls.MainPageControls
{
    public partial class ctrlChats : MainPageControl
    {
        #region Constructors

        public ctrlChats()
        {
            InitializeComponent();

            StatusBarVisibility = new StatusBarVisbility
            {
                ShowChatsIcon = false
            };
        }

        #endregion

        #region Implementation of IMainPageControl

        public override Pages Page => Pages.Chats;

        #endregion

        #region Overrides of MainPageControl

        public override void SetProject(Project project)
        {
            ShowChatsForProject(project);
        }
        
        public override StatusBarVisbility StatusBarVisibility { get; }
        
        #endregion

        #region Private methods

        private void ShowChatsForProject(Project project)
        {
            Logger.Log("ctrlChats > " + project.Name);
        }

        #endregion

    }
}
