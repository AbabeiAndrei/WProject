using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.UiLibrary.Interfaces;
using WProject.UiLibrary.Style;
using WProject.UiLibrary.Theme;

namespace WProject.UiLibrary.Controls
{
    public class WpButton : Button, ISelectableControl, IStylable
    {
        #region Implementation of ISelectableControl

        public event SelectedChangedHandler SelectedChanged;
        public bool Selected { get; set; }

        #endregion

        #region Implementation of IThemeable

        public void ApplyStyle()
        {
            ApplyTheme(this, WpThemeReader.GetUiStyle(WpThemeConstants.WPSTYLE_BUTTON));
        }

        #endregion

        #region Public methods

        public static void ApplyTheme(WpButton button, UiStyle style)
        {
            button.BackColor = style.NormalStyle.BackColor;
            button.ForeColor = style.NormalStyle.ForeColor;
            button.Font = style.NormalStyle.Font;
        }

        #endregion

    }
}
