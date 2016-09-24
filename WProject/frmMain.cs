using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using WProject.Classes;
using WProject.Controls;
using WProject.GenericLibrary.Constants;
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Style;
using WProject.UiLibrary.Theme;

namespace WProject
{
    public sealed partial class frmMain : Form
    {
        #region Fields

        private WpForm _form;

        #endregion

        #region Constructors

        public frmMain()
        {
            InitializeComponent();
            Text = GeneralConstants.APPLICATION_NAME;
            ctrlHeader = new ctrlHeader
            {
                Dock = DockStyle.Top,
                Height = 50,
                Name = nameof(ctrlHeader),
                //Visible = false //todo ??? nu mai afiseaza lista dupa schimbarea vizibilitatii
                Enabled = false
            };
            UIHelper.HeaderControl = ctrlHeader;

            ctrlMainPanel = new ctrlMainPanel
            {
                Dock = DockStyle.Fill,
                Name = nameof(ctrlMainPanel),
                Visible = false
            };
            ctrlLoginControl = new ctrlLoginControl
            {
                Dock = DockStyle.Fill,
                Name = nameof(ctrlLoginControl)
            };

            Controls.Add(ctrlMainPanel);
            Controls.Add(ctrlHeader);
            Controls.Add(ctrlLoginControl);

            ctrlLoginControl.OnLoggedConfirmed = OnLoggedConfirmed;

            UIHelper.MainPanel = ctrlMainPanel;
            UIHelper.MainForm = this;

            InitOverlayForm();
        }

        private void InitOverlayForm()
        {
            _form = new WpForm
            {
                Location = new Point(0, 0),
                BackColor = Color.Gray,
                Opacity = 0.2,
                FormBorderStyle = FormBorderStyle.None,
                ShowInTaskbar = false,
                AutoScaleMode = AutoScaleMode.None
            };
        }

        #endregion

        #region Overrides of Form

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsHelper.DrawShadow(e.Graphics,
                                      GraphicsHelper.GetRectPath(new Rectangle(-100, -100, Width + 150, ctrlHeader.Bottom + 103)),
                                      WpThemeColors.Shadow,
                                      -7);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Dispose(true);

            UIHelper.CloseApplication();

            base.OnClosing(e);
        }
        
        protected override async void OnLoad(EventArgs e)
        {
            try
            {
                UIHelper.ShowLoader("Connecting to server..");
                if (!await Module.InitApplicationData())
                {
                    UIHelper.ShowError("CANNOT INITIATE COMUNICATION TO SERVER");
                    UIHelper.CloseApplication();
                    return;
                }

                if (!Connection.Connection.ConnectionIsAlive)
                {
                    UIHelper.ShowError("CANNOT CONNECT TO REMOTE SERVER");
                    UIHelper.CloseApplication();
                }
                UIHelper.HideLoader();
            }
            catch (Exception mex)
            {
                UIHelper.HideLoader();
                UIHelper.ShowError(mex);
            }
            finally
            {
                base.OnLoad(e);
            }
        }

        protected override void WndProc(ref Message msg)
        {
            try
            {
                if (msg.Msg != WMConstants.WM_SYSCOMMAND)
                    return;

                if (msg.WParam == new IntPtr(WMConstants.SC_MAXIMIZE) || 
                    msg.WParam == new IntPtr(WMConstants.SC_RESTORE) || 
                    msg.WParam == new IntPtr(WMConstants.SC_MINIMIZE))
                    OnSizeChanged(EventArgs.Empty);
            }
            finally
            {
                base.WndProc(ref msg);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams mcp = base.CreateParams;
                //cp.ExStyle |= WinApi.WS_EX_COMPOSITED; // Turn on WS_EX_COMPOSITED
                mcp.ExStyle |= GenericLibrary.WinApi.Constants.WS_EX_COMPOSITED;
                //cp.ExStyle |= 0x00080000; //  Turn on WS_EX_LAYERED    | WS_EX_CLIPSIBLINGS
                //cp.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                return mcp;
            }
        }

        #endregion

        #region Overrides of Control

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            if (_form == null)
                return;

            _form.Location = PointToScreen(Point.Empty);
        }
        
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (_form == null)
                return;

            _form.Size = ClientSize;
            Refresh();
        }

        #endregion

        #region Private methods

        private async void OnLoggedConfirmed()
        {
            if (WPSuite.ConnectedUser == null)
            {
                UIHelper.ShowError("User not found! Something wrong happened");
                Logger.Log("User is null!!! (OnLoggedConfirmed : frmMain)");
                return;
            }

            Logger.Log("Logged : " + WPSuite.ConnectedUser.Name);
            try
            {
                UIHelper.ShowLoader("Get user data...");

                SuspendLayout();

                await ctrlHeader.LoadData();

                ctrlHeader.Visible = true;
                ctrlHeader.Enabled = true;

                ctrlMainPanel.Visible = true;

                ctrlLoginControl.Visible = false;

                UIHelper.HideLoader();
            }
            catch (Exception mex)
            {
                UIHelper.HideLoader();
                Logger.Log(mex);
                UIHelper.ShowError(mex);
            }
            finally
            {
                ResumeLayout();
            }
        }

        #endregion

        #region Public methods

        public void ShowOverlay(bool show = true)
        {
            if(show)
                _form?.Show(this);
            else
                _form.Hide();
        }

        #endregion

    }
}
