using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using WProject.UiLibrary.Annotations;

namespace WProject.UiLibrary.Style
{
    public enum StyleType
    {
        Normal,
        Hover,
        Click,
        Selected,
        None
    }

    [Serializable]
    //[TypeConverter(typeof(UiStyleEditorTypeConverter))]
    public class UiStyle : INotifyPropertyChanged
    {
        #region Fields

        private Style _normalStyle;
        private Style _hoverStyle;
        private Style _clickStyle;
        private Style _selectedStyle;

        #endregion
        
        #region Properties
        private bool IsDefault { get; set; }

        //[Category("Style")]
        //[TypeConverter(typeof (ExpandableObjectConverter))]
        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Style NormalStyle
        {
            get
            {
                return _normalStyle;
            }
            set
            {
                if (Equals(value, _normalStyle))
                    return;
                _normalStyle = value;
                OnPropertyChanged(nameof(NormalStyle));
            }
        }

        //[Category("Style")]
        //[TypeConverter(typeof (ExpandableObjectConverter))]
        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Style HoverStyle
        {
            get
            {
                return _hoverStyle;
            }
            set
            {
                if (Equals(value, _hoverStyle))
                    return;
                _hoverStyle = value;
                OnPropertyChanged(nameof(HoverStyle));
            }
        }

        //[Category("Style")]
        //[TypeConverter(typeof (ExpandableObjectConverter))]
        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Style ClickStyle
        {
            get
            {
                return _clickStyle;
            }
            set
            {
                if (Equals(value, _clickStyle))
                    return;
                _clickStyle = value;
                OnPropertyChanged(nameof(ClickStyle));
            }
        }

        //[Category("Style")]
        //[TypeConverter(typeof (ExpandableObjectConverter))]
        [ReadOnly(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Style SelectedStyle
        {
            get
            {
                return _selectedStyle;
            }
            set
            {
                if (Equals(value, _selectedStyle))
                    return;
                _selectedStyle = value;
                OnPropertyChanged(nameof(SelectedStyle));
            }
        }

        public static UiStyle DefaultStyle { get; set; }
        public static UiStyle DefaultHoverStyle { get; set; }

        #endregion

        #region Constructors

        static UiStyle()
        {
            DefaultStyle = new UiStyle
            {
                NormalStyle = new Style(),
                IsDefault = true
            };
            DefaultHoverStyle = new UiStyle
            {
                NormalStyle = new Style(),
                HoverStyle = new Style
                {
                    BackColor = Color.LightGray
                },
                IsDefault = true
            };
        }

        public UiStyle()
        {
            NormalStyle = new Style();
        }

        #endregion

        #region Overrides of Object

        public override string ToString() => IsDefault ? "Default" : NormalStyle?.ToString() ?? string.Empty;

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Public methods

        public UiStyle Clone()
        {
            return Clone(this);
        }

        private static UiStyle Clone(UiStyle style)
        {
            return new UiStyle
            {
                NormalStyle = style?.NormalStyle?.Clone(),
                HoverStyle = style?.HoverStyle?.Clone(),
                ClickStyle = style?.ClickStyle?.Clone(),
                SelectedStyle = style?.SelectedStyle?.Clone(),
                IsDefault = style?.IsDefault ?? false
            };
        }

        #endregion
    }

    [Serializable]
    [TypeConverter(typeof(UiStyleEditorTypeConverter))]
    [Editor(typeof(StyleEditor), typeof(UITypeEditor))]
    public class Style : INotifyPropertyChanged
    {
        #region Fields

        private Font _font;
        private Color _foreColor;
        private Color _backColor;
        private Color? _borderColor;
        private Padding _padding;
        private Padding _margin;
        private float? _borderWidth;
        private Cursor _cursor;

        #endregion
        
        #region Properties

        public Font Font
        {
            get
            {
                return _font;
            }
            set
            {
                if (Equals(value, _font))
                    return;
                _font = value;
                OnPropertyChanged(nameof(Font));
            }
        }

        public Color ForeColor
        {
            get
            {
                return _foreColor;
            }
            set
            {
                if (value.Equals(_foreColor))
                    return;
                _foreColor = value;
                OnPropertyChanged(nameof(ForeColor));
            }
        }

        public Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                if (value.Equals(_backColor))
                    return;
                _backColor = value;
                OnPropertyChanged(nameof(BackColor));
            }
        }

        public Padding Padding
        {
            get
            {
                return _padding;
            }
            set
            {
                if (value.Equals(_padding))
                    return;
                _padding = value;
                OnPropertyChanged(nameof(Padding));
            }
        }

        public Padding Margin
        {
            get
            {
                return _margin;
            }
            set
            {
                if (value.Equals(_margin))
                    return;
                _margin = value;
                OnPropertyChanged(nameof(Margin));
            }
        }

        public Color? BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                if (value.Equals(_borderColor))
                    return;
                _borderColor = value;
                OnPropertyChanged(nameof(BorderColor));
            }
        }

        public float? BorderWidth
        {
            get
            {
                return _borderWidth;
            }
            set
            {
                if (value == _borderWidth)
                    return;
                _borderWidth = value;
                OnPropertyChanged(nameof(BorderWidth));
            }
        }

        public Cursor Cursor
        {
            get
            {
                return _cursor;
            }
            set
            {
                if (Equals(value, _cursor))
                    return;
                _cursor = value;
                OnPropertyChanged(nameof(Cursor));
            }
        }

        #endregion

        #region Constructors

        public Style()
        {
            Padding = new Padding(0);
            Margin = new Padding(3);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 12f);
            ForeColor = Color.Black;
            BorderColor = null;
            BorderWidth = null;
            Cursor = Cursors.Default;
        }

        #endregion

        #region Overrides of Object

        public override string ToString() => $"{Font.Name} ({Font.Size}px), Color : {ForeColor} (BackColor : {BackColor})";

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Public methods

        public void SetByControl(Control control)
        {
            Font = control.Font;
            ForeColor = control.ForeColor;
            BackColor = control.BackColor;
            Padding = control.Padding;
            Margin = control.Margin;
            BorderColor = null;
            Cursor = control.Cursor;
        }
        
        public Style Clone()
        {
            return Clone(this);
        }

        public static Style Clone(Style style)
        {
            return new Style
            {
                _font = style.Font,
                _foreColor = style.ForeColor,
                _backColor = style.BackColor,
                _margin = style.Margin,
                _padding = style.Padding,
                _borderColor = style.BorderColor,
                _borderWidth = style.BorderWidth,
                _cursor = style.Cursor,
            };
        }

        #endregion

    }
}
