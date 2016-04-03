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
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.Interfaces;
using WProject.WebApiClasses.Classes;

namespace WProject.Controls.MainPageControls
{
    public partial class ctrlViews : MainPageControl
    {
        #region Constructors

        public ctrlViews()
        {
            InitializeComponent();

            StatusBarVisibility = new StatusBarVisbility
            {
                ShowChatsIcon = false
            };
        }

        #endregion

        #region Implementation of IMainPageControl

        public override Pages Page => Pages.Views;

        #endregion

        #region Overrides of MainPageControl

        public override void SetProject(Project project)
        {
            SetViewsForProject(project);
        }

        public override StatusBarVisbility StatusBarVisibility { get; }
        
        #endregion

        #region Private methods

        private void SetViewsForProject(Project project)
        {
            Logger.Log("ctrlViews > " + project.Name);
        }

        #endregion

    }
}
