using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.VisualStyles;
using WProject.UiLibrary.Theme;

namespace WProject.UiLibrary.Controls
{
    [Designer(typeof(WpPanelControlDesigner))]
    public class WpPanel : WpUserControl
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Panel InnerPanel { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TableLayoutPanel InnerTableLayout { get; set; }

        public new bool DoubleBuffered
        {
            get
            {
                return base.DoubleBuffered;
            }
            set
            {
                base.DoubleBuffered = value;
            }
        }

        public WpPanel()
        {
            InnerPanel = new Panel();
            InnerTableLayout = new TableLayoutPanel();

            if(DesignMode)
                BorderStyle = BorderStyle.FixedSingle;
        }

        public void ScrollToBottom()
        {
            using (Control c = new Control{ Parent = this, Dock = DockStyle.Bottom })
            {
                ScrollControlIntoView(c);
                c.Parent = null;
            }
        }
    }

    public class WpPanelControlDesigner : ParentControlDesigner
    {

        public override void Initialize(IComponent component)
        {

            base.Initialize(component);

            WpPanel myPanel = component as WpPanel;
            if (myPanel == null)
                return;

            EnableDesignMode(myPanel.InnerPanel, "InnerPanel");
            EnableDesignMode(myPanel.InnerTableLayout, "InnerTableLayout");
        }

    }
}
