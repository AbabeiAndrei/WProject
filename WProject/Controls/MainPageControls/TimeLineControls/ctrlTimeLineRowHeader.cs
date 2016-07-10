using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.UiLibrary.Controls;

namespace WProject.Controls.MainPageControls.TimeLineControls
{
    public partial class ctrlTimeLineRowHeader : WpUserControl
    {
        #region Constructrors

        public ctrlTimeLineRowHeader()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides of WpUserControl

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


        }

        #endregion
    }
}
