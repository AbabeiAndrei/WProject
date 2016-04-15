using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WProject.UiLibrary.Controls
{
    public class WpButton : Button, ISelectableControl
    {
        #region Implementation of ISelectableControl

        public event SelectedChangedHandler SelectedChanged;
        public bool Selected { get; set; }

        #endregion
    }
}
