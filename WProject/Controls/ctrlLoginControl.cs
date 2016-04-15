using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.Classes;
using WProject.Connection;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.Properties;
using WProject.UiLibrary;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Theme;
using ConnectionState = WProject.Connection.ConnectionState;

namespace WProject.Controls
{
    public partial class ctrlLoginControl : WpUserControl
    {
        #region Fields

        private Brush _bkBrush;
        private int _tmrPhase;

        #endregion

        #region Properties

        public Action OnLoggedConfirmed { get; set; }

        #endregion

        #region Constructors

        public ctrlLoginControl()
        {
            InitializeComponent();

            _bkBrush = new SolidBrush(Color.FromArgb(20, WpThemeColors.Blue));

            Connection.Connection.ConnectionStateChanged += ConnectionOnConnectionStateChanged;
        }

        #endregion

        #region Events

        private void ctrlLoginControl_Load(object sender, EventArgs e)
        {
            AddToValidate(txtUser, ValidateGuiMode.NotEmpty);
            AddToValidate(txtPass, ValidateGuiMode.NotEmpty);

            if (!Settings.Default.RememberMeChecked || string.IsNullOrEmpty(Settings.Default.LastUser))
                return;

            chkRemeber.Checked = true;
            txtUser.Text = Settings.Default.LastUser;
            txtPass.Text = Settings.Default.LastPass;

            tmrLoadAnimation.Start();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var ms = ValidateGui();
            if (!string.IsNullOrEmpty(ms))
            {
                UIHelper.ShowError(ms);
                return;
            }

            SaveRemeberMe();

            try
            {
                UIHelper.ShowLoader("Check login informations...");

                var mres = await WebCallFactory.ExecuteLogin(txtUser.Text, txtPass.Text);

                if (mres.Error)
                    throw mres.Exception;

                WPSuite.ConnectedUser = mres.User;

                OnLoggedConfirmed?.Invoke();

                UIHelper.HideLoader();
            }
            catch (Exception mex)
            {
                UIHelper.HideLoader();
                UIHelper.ShowError(mex);
            }
        }

        private void txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && btnLogin.Enabled)
                btnLogin.PerformClick();
        }

        private void ctrlLoginControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(_bkBrush,
                                     lblUser.Left - 15,
                                     0,
                                     txtUser.Right - lblUser.Left + 25,
                                     btnLogin.Bottom + 15);
        }

        private void ConnectionOnConnectionStateChanged(ConnectionStateChangedArgs args)
        {
            if(args.NewState != ConnectionState.Connected)
                return;

            tmrLoadAnimation.Stop();
            btnLogin.Text = "Login";
            btnLogin.Enabled = true;
        }

        #endregion

        #region Private methods

        private void SaveRemeberMe()
        {
            Settings.Default.RememberMeChecked = chkRemeber.Checked;
            Settings.Default.LastUser = chkRemeber.Checked ? txtUser.Text : string.Empty;
            Settings.Default.LastPass = chkRemeber.Checked ? txtPass.Text : string.Empty;

            Settings.Default.Save();
        }

        #endregion

        private void tmrLoadAnimation_Tick(object sender, EventArgs e)
        {
            _tmrPhase++;
            switch (_tmrPhase)
            {
                case 0:
                    btnLogin.Text = "dp";
                    break;
                case 1:
                    btnLogin.Text = "qb";
                    break;
                case 2:
                    btnLogin.Text = "pd";
                    break;
                case 3:
                    btnLogin.Text = "bq";
                    break;
                default:
                    btnLogin.Text = "dp";
                    _tmrPhase = 0;
                    break;
            }
        }
    }
}
