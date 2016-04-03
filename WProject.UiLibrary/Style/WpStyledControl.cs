using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Controls.Base;

namespace WProject.UiLibrary.Style
{
    public class WpStyledControl : WpBaseUserControl
    {
        #region Fields

        private StyleType _styleType;
        private UiStyle _style;
        private Pen _borderPen;

        #endregion

        #region Properties

        [Category("Style")]
        public virtual UiStyle Style
        {
            get
            {
                return _style;
            }
            set
            {
                _style = value;
                if(_style != null)
                    _style.PropertyChanged += (sender, args) => OnStyleChanged();
                OnStyleChanged();
            }
        }

        [Browsable(false)]
        public virtual StyleType StyleType
        {
            get
            {
                return _styleType;
            }
            set
            {
                if(_styleType == value)
                    return;
                _styleType = value;
                ApplyStyle();
            }
        }

        public virtual Style CurrentStyle => GetStyleFromType(StyleType);

        #endregion

            #region Contstructors

        protected WpStyledControl()
        {
            _styleType = StyleType.Normal;
            // ReSharper disable once SuspiciousTypeConversion.Global
            ISelectableControl msc = this as ISelectableControl;
            if (msc != null)
                msc.SelectedChanged +=
                    (sender, args) => StyleType = args.Selected ? StyleType.Selected : StyleType.Normal;

            _style = UiStyle.DefaultStyle;
            _style.PropertyChanged += (sender, args) => OnStyleChanged();
            OnStyleChanged();

            ApplyStyle(_style.NormalStyle);

            // ReSharper disable once VirtualMemberCallInContructor
            DoubleBuffered = true;
        }

        #endregion

        #region Public methods

        public virtual void ApplyStyle()
        {
            if (Style == null)
                return;

            /*switch (StyleType)
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
            }*/

            ApplyStyle(GetStyleFromType(StyleType));

            Refresh();
            if(DesignMode)
                Parent?.Refresh();
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

        private void ApplyStyle(Style style)
        {
            if(style == null)
                return;
            Font = style.Font;
            ForeColor = style.ForeColor;
            BackColor = style.BackColor;
            Padding = style.Padding;
            Margin = style.Margin;
            if (style.BorderColor.HasValue)
            {
                float mfpenWidth = style.BorderWidth.GetValueOrDefault(1f);
                int mpw = (int)Math.Floor(mfpenWidth);
                if (_borderPen == null)
                    Padding = new Padding(Padding.Left + mpw, 
                                          Padding.Top + mpw, 
                                          Padding.Right + mpw, 
                                          Padding.Bottom + mpw);

                _borderPen = new Pen(style.BorderColor.Value, mfpenWidth);
            }
            else
            {
                if (_borderPen != null)
                    Padding = style.Padding;
                _borderPen = null;
            }
            Cursor = style.Cursor ?? Cursors.Default;
            Refresh();
        }

        private Style GetStyleFromType(StyleType styleType)
        {

            switch (styleType)
            {
                case StyleType.Normal:
                case StyleType.None:
                    return Style.NormalStyle;
                case StyleType.Hover:
                    return Style.HoverStyle;
                case StyleType.Click:
                    return Style.ClickStyle;
                case StyleType.Selected:
                    return Style.SelectedStyle;
                default:
                    throw new ArgumentOutOfRangeException();

            }
        }

        #endregion

        #region Overrides of Control

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if(Enabled && Style?.ClickStyle != null)
                StyleType = StyleType.Click;
            base.OnMouseDown(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (Enabled && Style?.HoverStyle != null)
                StyleType = StyleType.Hover;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (Enabled && Style?.NormalStyle != null)
                StyleType = StyleType.Normal;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (Enabled && Style?.HoverStyle != null)
                StyleType = StyleType.Hover;
            base.OnMouseUp(e);
        }
        
        protected override void OnEnabledChanged(EventArgs e)
        {
            if(StyleType != StyleType.Normal && Style?.NormalStyle != null)
                StyleType = StyleType.Normal;
            base.OnEnabledChanged(e);
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            if(_borderPen != null)
                e.Graphics.DrawRectangle(_borderPen, 0f, 0f, Width - _borderPen.Width, Height - _borderPen.Width);

            base.OnPaint(e);
        }
        
        #endregion

        #region Events

        public new event EventHandler StyleChanged;

        #endregion
    }
}