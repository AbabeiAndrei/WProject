using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WProject.GenericLibrary.Helpers.Log;

namespace WProject.UiLibrary.Controls
{
    public partial class WpLoaderControl : WpUserControl
    {
        #region Fields

        private string _text;

        #endregion

        #region Constructors

        public WpLoaderControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides of UserControl

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                //cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return cp;
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            if (lblText != null)
                lblText.BackColor = BackColor;
            if (pbLoader != null)
                pbLoader.BackColor = BackColor;
            base.OnBackColorChanged(e);
        }

        #endregion

        #region Overrides of ScrollableControl

        protected override void OnVisibleChanged(EventArgs e)
        {
            try
            {
                if (pbLoader.Enabled != Visible)
                    pbLoader.Enabled = Visible;
            }
            finally
            {
                base.OnVisibleChanged(e);
            }
        }

        #endregion

        #region Public methods

        public void SetLoaderText(string text)
        {
            if (text == _text)
                return;

            _text = text;

            lblText.Text = text;
        }

        #endregion

    }
}
