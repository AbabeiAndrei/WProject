using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using WProject.UiLibrary.Theme;

namespace WProject.UiLibrary.Controls
{
    [Designer(typeof(WpPanelControlDesigner))]
    public class WpPanel : WpUserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel InnerPanel { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TableLayoutPanel InnerTableLayout { get; set; }
    }

    public class WpPanelControlDesigner : ParentControlDesigner
    {

        public override void Initialize(IComponent component)
        {

            base.Initialize(component);

            WpPanel myPanel = component as WpPanel;
            EnableDesignMode(myPanel.InnerPanel, "InnerPanel");
            EnableDesignMode(myPanel.InnerTableLayout, "InnerTableLayout");

        }

    }
}
