using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.UiLibrary.Helpers;
using WProject.UiLibrary.Properties;

namespace WProject.UiLibrary.Controls
{
    [DefaultEvent("OnCheckChanged")]
    public class WpCheckBox : WpLabel
    {
        #region Fields

        private bool _checked;

        #endregion

        #region Properties

        [Category("Appearance")]
        [DefaultValue(false)]
        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                if(_checked == value)
                    return;

                _checked = value;
                Refresh();

                OnCheckChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        [Category("Action")]
        public event EventHandler OnCheckChanged;
        
        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Not used in checkBox")]
        private new bool Selected
        {
            get
            {
                return base.Selected;
            }
            set
            {
                base.Selected = value;
            }
        }

        #endregion

        #region Overrides of Control

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            DoubleBuffered = true;
        }

        protected override void OnClick(EventArgs e)
        {
            Checked = !Checked;
            base.OnClick(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            
            Padding = Padding.SetPadding(Height + 4, Direction.Left);
        }
        
        #endregion

        #region Overrides of Label

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.DrawImage(GetCheck(), new Rectangle(2, 2, Height - 4, Height - 4));
        }

        private Image GetCheck()
        {
            if(Checked)
                if (Height <= 24)
                    return Resources.check_box_s;
                else if (Height <= 48)
                    return Resources.check_box_m;
                else
                    return Resources.check_box_l;
            if (Height <= 24)
                return Resources.blank_check_box_s;
            if (Height <= 48)
                return Resources.blank_check_box_m;

            return Resources.blank_check_box_l;
        }

        #endregion
    }
}
