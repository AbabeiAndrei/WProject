using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace WProject.UiLibrary.Designer
{
    public class WpDropDownControlDesigner : ControlDesigner
    {
        public WpDropDownControlDesigner()
        {
            base.AutoResizeHandles = true;
        }
        public override SelectionRules SelectionRules => SelectionRules.LeftSizeable | SelectionRules.RightSizeable | SelectionRules.Moveable;
    }
}
