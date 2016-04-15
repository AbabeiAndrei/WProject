using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.GenericLibrary.WinApi;
using WProject.UiLibrary.Theme;

namespace WProject.UiLibrary.Controls
{
    public class WpTextBox : TextBox
    {
        #region Fields

        private WpButton _clearButton;
        private bool _clearWasVisible;
        private Button _leftButton;

        #endregion
        
        #region Properties

        public event EventHandler OnClearClick;

        public bool ShowClear
        {
            get
            {
                return _clearButton.Visible;
            }
            set
            {
                _clearButton.Visible = value;
            }
        }

        public Button LeftButton
        {
            get
            {
                return _leftButton;
            }
            set
            {
                if (value == null)
                {
                    SetButton();
                    ShowClear = _clearWasVisible;
                    Controls.Remove(_leftButton);
                    _leftButton = null;
                    return;
                }

                _leftButton = value;

                _clearWasVisible = ShowClear;
                Controls.Add(_leftButton);
                _leftButton.Cursor = Cursors.Default;
                ShowClear = false;
                SetButton();
            }
        }

        #endregion

        #region Constructors

        public WpTextBox()
        {
            _clearButton = new WpButton
            {
                Visible = false,
                Text = "X",
                Cursor = Cursors.Default,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    BorderSize = 0,
                    MouseOverBackColor = WpThemeColors.Blue
                }
            };
            _clearButton.SizeChanged += (o, e) => OnResize(e);
            _clearButton.Click += OnClearButtonOnClick;
            Controls.Add(_clearButton);
        }

        #endregion
        
        #region Events

        private void OnClearButtonOnClick(object o, EventArgs e)
        {
            Clear();
            OnClearClick?.Invoke(this, EventArgs.Empty);
        }

        #endregion
        
        #region Overrides of Control

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetButton();
        }

        private void SetButton()
        {
            var mb = LeftButton ?? _clearButton;

            if(!mb.Visible)
                return;

            mb.Size = new Size(Height, Height);
            mb.Location = new Point(ClientSize.Width - Height, -1);

            User32.SendMessage(Handle, Constants.EM_SETMARGINS, (IntPtr)2, (IntPtr)(mb.Width << 16));
        }

        #endregion
    }
}
