using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using WProject.UiLibrary.Style;
using WProject.UiLibrary.Theme;

namespace WProject.UiLibrary.Controls
{
    [Flags]
    public enum ValidateGuiMode : uint
    {
        NotEmpty = 1,
        MinimLength = 2,
        IntegerFormat = 4,
        DecimalFormat = 8
    }

    public partial class WpUserControl : WpStyledControl
    {
        #region Fields

        readonly IList<GuiValidator> _validateControls;

        #endregion

        #region Properties

        public virtual string StyleKey => WpThemeConstants.WPSTYLE_DEFAULT_USER_CONTROL;
        public bool OwnStyle { get; set; }

        #endregion

        #region Constructors

        protected WpUserControl()
        {
            _validateControls = new List<GuiValidator>();

            InitializeComponent();
        }

        #endregion

        #region Overrides of UserControl

        protected override void OnLoad(EventArgs e)
        {
            SetStyle();
            base.OnLoad(e);
        }

        #endregion

        #region Public methods

        public void AddToValidate(TextBox txt, ValidateGuiMode mode, string name = "", int minLen = 0, int numericMin = 0, int numericMax = 0 )
        {
            _validateControls.Add(new GuiValidator
            {
                TextBox = txt,
                Mode = mode,
                Name = name,
                MinLength = minLen,
                NumericMin = numericMin,
                NumericMax = numericMax,
            });
        }

        public string ValidateGui()
        {
            foreach (GuiValidator mv in _validateControls)
            {
                if (mv.Mode.HasFlag(ValidateGuiMode.NotEmpty) && string.IsNullOrEmpty(mv.TextBox.Text))
                    return mv.Name + " cannot be empty";

                if(mv.Mode.HasFlag(ValidateGuiMode.MinimLength) && mv.TextBox.Text.Length < mv.MinLength)
                    return $"Minimum length for {mv.Name} is {mv.MinLength}";

                int mint;

                if (mv.Mode.HasFlag(ValidateGuiMode.IntegerFormat) &&
                    !int.TryParse(mv.TextBox.Text,
                                  NumberStyles.Any,
                                  System.Threading.Thread.CurrentThread.CurrentCulture,
                                  out mint))
                    return mv.Name + " is not well formated number";

                decimal mdec;

                if (mv.Mode.HasFlag(ValidateGuiMode.DecimalFormat) &&
                    !decimal.TryParse(mv.TextBox.Text,
                                      NumberStyles.Any,
                                      System.Threading.Thread.CurrentThread.CurrentCulture,
                                      out mdec))
                    return mv.Name + " is not well formated decimal";
            }

            return string.Empty;
        }

        public virtual void SetStyle()
        {
            UiStyle ms = OwnStyle ? Style : null;
            try
            {
                ms = ms ??
                     WpThemeReader.GetUiStyle(StyleKey) ??
                     WpThemeReader.GetUiStyle(WpThemeConstants.WPSTYLE_DEFAULT_USER_CONTROL);

                //ms?.NormalStyle?.SetByControl(this);
            }
            finally
            {
                Style = ms;
            }
        }

        #endregion
    }

    internal class GuiValidator
    {
        public TextBox TextBox { get; set; }
        public ValidateGuiMode Mode { get; set; }
        public int MinLength { get; set; }
        public int NumericMin { get; set; }
        public int NumericMax { get; set; }
        public string Name { get; set; }
    }
}
