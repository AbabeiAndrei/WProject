using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.GenericLibrary.WinApi;

namespace WProject.UiLibrary.Controls
{
    public class WpForm : Form
    {
        public bool DropShadow { get; set; }
        #region Overrides of Form

        //protected override bool ShowWithoutActivation => true;

        /*protected override CreateParams CreateParams
        {
            get
            {
                CreateParams baseParams = base.CreateParams;

                baseParams.ExStyle |= WS_EX_NOACTIVATE |
                                      WS_EX_TOOLWINDOW;

                return baseParams;
            }
        }*/
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if(DropShadow)
                    cp.ClassStyle |= Constants.CS_DROPSHADOW;
                return cp;
            }
        }
        #endregion

        public WpForm()
        {

        }
    }
}
