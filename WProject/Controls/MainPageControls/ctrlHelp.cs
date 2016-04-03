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
    public partial class ctrlHelp : MainPageControl
    {
        #region Constructors

        public ctrlHelp()
        {
            InitializeComponent();
        }

        #endregion

        #region Implementation of IMainPageControl

        public override Pages Page => Pages.Help;

        #endregion

        #region Overrides of MainPageControl

        public override bool CanChangeProject => false;

        public override void SetProject(Project project)
        {
            Logger.Log("ctrlHelp > " + project.Name);
        }

        #endregion
    }
}
