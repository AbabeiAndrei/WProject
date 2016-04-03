using System;
using System.Drawing;
using System.Windows.Forms;
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.Properties;

using WProject.UiLibrary;
using WProject.UiLibrary.Theme;

namespace WProject.Controls.MainPageControls
{
    public partial class ctrlStatusBar : WpUserControl
    {
        #region Fields

        private int _chats;

        #endregion

        #region Properties

        public bool ShowSoundIcon
        {
            get
            {
                return pbSounds.Visible;
            }
            set
            {
                pbSounds.Visible = value;
            }
        }

        public bool ShowChatsIcon
        {
            get
            {
                return pbMessages.Visible;
            }
            set
            {
                pbMessages.Visible = value;
            }
        }

        public bool IsMuted
        {
            get
            {
                return Settings.Default.IsMuted;
            }
            set
            {
                Settings.Default.IsMuted = value;

                pbSounds.Image = value
                                     ? Resources.volume_off_s
                                     : Resources.volume_on_s;

                Settings.Default.Save();
            }
        }

        public int Chats
        {
            get
            {
                return _chats;
            }
            set
            {
                _chats = value;

                pbMessages.Image = ImageHelper.SetNumber(Resources.chat_s,
                                                         value,
                                                         WpThemeColors.Red,
                                                         WpThemeColors.White,
                                                         new Font(WpThemeFonts.SEGOE_UI, 6f),
                                                         9);
            }
        }

        public Action OnChatsClick { get; set; }

        public Action OnSoundClick { get; set; }

        #endregion

        #region Constructors

        public ctrlStatusBar()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void ctrlStatusBar_Load(object sender, EventArgs e)
        {
            lbl1.Text =
                lbl2.Text =
                lbl3.Text =
                lbl4.Text =
                lbl5.Text = string.Empty;

            IsMuted = Settings.Default.IsMuted;
            Chats = 0;
        }

        private void pbSounds_Click(object sender, EventArgs e)
        {
            if (OnSoundClick != null)
                OnSoundClick();
            else
                IsMuted = !IsMuted;
        }

        private void pbMessages_Click(object sender, EventArgs e)
        {
            OnChatsClick?.Invoke();
        }

        #endregion

        #region Overrides of WpStyledControl

        public override void ApplyStyle()
        {
            base.ApplyStyle();

            BackColor = WpThemeColors.Blue;
            ForeColor = WpThemeColors.White;

            if (pbMessages == null)
                return;
            
            pbMessages.Cursor = Cursors.Hand;
            pbSounds.Cursor = Cursors.Hand;
        }

        #endregion

        #region Public methods

        public void SetTexts(params string[] texts)
        {
            if (texts == null)
            {
                lbl1.Text =
                    lbl2.Text =
                    lbl3.Text =
                    lbl4.Text =
                    lbl5.Text = string.Empty;
                return;
            }

            lbl1.Text = texts.Length > 0
                            ? texts[0]
                            : string.Empty;
            lbl2.Text = texts.Length > 1
                            ? texts[1]
                            : string.Empty;
            lbl3.Text = texts.Length > 2
                            ? texts[2]
                            : string.Empty;
            lbl4.Text = texts.Length > 3
                            ? texts[0]
                            : string.Empty;
            lbl5.Text = texts.Length > 4
                            ? texts[5]
                            : string.Empty;
        }

        #endregion
    }
}
