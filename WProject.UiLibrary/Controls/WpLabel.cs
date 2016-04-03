using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.UiLibrary.Style;

namespace WProject.UiLibrary.Controls
{
    public class WpLabel : Label, ISelectableControl
    {
        #region Fields

        private StyleType _styleType;
        private UiStyle _style;

        #endregion

        #region Properties

        public UiStyle Style
        {
            get
            {
                return _style;
            }
            set
            {
                _style = value;
                OnStyleChanged();
            }
        }

        public StyleType StyleType
        {
            get
            {
                return _styleType;
            }
            set
            {
                _styleType = value;
                ApplyStyle();
            }
        }

        #endregion

        #region Contstructors

        public WpLabel()
        {
            StyleType = StyleType.Normal;
            ISelectableControl msc = this as ISelectableControl;
            if (msc != null)
                msc.SelectedChanged +=
                    (sender, args) => StyleType = args.Selected ? StyleType.Selected : StyleType.Normal;
        }

        #endregion

        #region Public methods

        public void ApplyStyle()
        {
            if (Style == null)
                return;

            switch (StyleType)
            {
                case StyleType.Normal:
                case StyleType.None:
                    ApplyStyle(Style.NormalStyle);
                    break;
                case StyleType.Hover:
                    ApplyStyle(Style.HoverStyle);
                    break;
                case StyleType.Click:
                    ApplyStyle(Style.ClickStyle);
                    break;
                case StyleType.Selected:
                    ApplyStyle(Style.SelectedStyle);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion

        #region Protected methods

        protected void OnStyleChanged()
        {
            ApplyStyle();
            StyleChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Private methods

        private void ApplyStyle(Style.Style style)
        {
            if(style == null)
                return;
            Font = style.Font;
            ForeColor = style.ForeColor;
            BackColor = style.BackColor;
            Padding = style.Padding;
            Margin = style.Margin;
            Cursor = style.Cursor;
        }

        #endregion

        #region Overrides of Control

        protected override void OnMouseClick(MouseEventArgs e)
        {
            StyleType = StyleType.Click;
            base.OnMouseClick(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            StyleType = StyleType.Hover;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            StyleType = StyleType.Normal;
            base.OnMouseLeave(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            StyleType = StyleType.Hover;
            base.OnMouseUp(e);
        }

        #endregion

        #region Events

        public new event EventHandler StyleChanged;

        #endregion

        #region Implementation of ISelectableControl

        public event SelectedChangedHandler SelectedChanged;

        private bool _selected;

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                SelectedChanged?.Invoke(this, new SelectedChangedHandlerArgs(_selected));
                StyleType = _selected ? StyleType.Selected : StyleType.Normal;
            }
        }

        #endregion
    }
}
