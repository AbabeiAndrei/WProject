using System;
using System.Drawing;
using System.Windows.Forms;
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.GenericLibrary.WinApi;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Style;
using WProject.UiLibrary.Theme;
using WProject.WebApiClasses.Classes;

namespace WProject.Controls
{
    partial class ctrlHeader
    {
        private System.ComponentModel.IContainer components = null;
        private WpPanel pnlTop;
        private WpPictureBox pbAvatar;
        private WpPictureBox pbNotifications;
        private WpPictureBox pbSearch;
        private WpPictureBox pbLogo;
        private WpDropDown<Project> ddProjects;
        private WpLabel lblDashBoard;
        private WpLabel lblTimeLine;
        private WpLabel lblViews;
        private WpLabel lblChats;
        private WpLabel lblAdmin;
        private WpLabel lblHelp;
        private FlowLayoutPanel flwLinks;
        private WpLabel _selectedLabel;
        private WpTextBox txtSearch;

        private ctrlNotificationWindow ctrlNotificationWindow;
        private ctrlUserWindow ctrlUserWindow;

        
        private void InitializeComponent()
        {
            SuspendLayout();

            pnlTop = new WpPanel
            {
                Dock = DockStyle.Top,
                Height = 25,
                Name = nameof(pnlTop)
            };
            FlowLayoutPanel mficons = new FlowLayoutPanel()
            {
                Width = 150,
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Right,
                Padding = new Padding(0),
                Name = nameof(mficons)
            };
            pbAvatar = new WpPictureBox()
            {
                Size = new Size(24, 24),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand,
                Image = Properties.Resources.dummy_avatar,
                OwnStyle = true,
                Style = new UiStyle()
                {
                    NormalStyle = new Style
                    {
                        Margin = Padding.Empty
                    }
                },
                Name = nameof(pbAvatar)
            };
            pbNotifications = new WpPictureBox()
            {
                Size = new Size(20, 20),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand,
                Name = nameof(pbNotifications)
            };
            pbSearch = new WpPictureBox()
            {
                Size = new Size(20, 20),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand,
                Name = nameof(pbSearch)
            };
            txtSearch = new WpTextBox
            {
                Visible = false,
                Size = new Size(150, 20),
                Font = WpThemeFonts.DefaultSearchFont,
                Name = nameof(txtSearch)
            };
            mficons.Controls.AddRange(new Control[] { pbAvatar, pbNotifications, pbSearch, txtSearch });
            
            pbLogo = new WpPictureBox()
            {
                Size = new Size(26, 20),
                Location = new Point(-6, 2),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = ImageHelper.SetBrightness(Properties.Resources.Logo, 1.5f),
                Name = nameof(pbSearch)
            };

            pbAvatar.Click += pbAvatar_Click;
            pbAvatar.MouseEnter += pbAvatar_MouseEnter;
            pbAvatar.MouseLeave += pbAvatar_MouseLeave;

            pbSearch.MouseEnter += pbSearch_MouseEnter;
            pbSearch.MouseLeave += pbSearch_MouseLeave;

            pbNotifications.MouseEnter += pbNotifications_MouseEnter;
            pbNotifications.MouseLeave += pbNotifications_MouseLeave;

            pnlTop.Controls.Add(mficons);
            pnlTop.Controls.Add(pbLogo);

            flwLinks = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 25,
                Padding = new Padding(6, 0, 6, 6),
                Name = nameof(flwLinks)
            };

            lblDashBoard = new WpLabel
            {
                Text = "Dashboard",
                Style = WpThemeReader.GetUiStyle(WpThemeConstants.TOP_HEADER_LABEL),
                AutoSize = true,
                Name = nameof(lblDashBoard)
            };
            lblTimeLine = new WpLabel
            {
                Text = "Timeline",
                Style = WpThemeReader.GetUiStyle(WpThemeConstants.TOP_HEADER_LABEL),
                AutoSize = true,
                Name = nameof(lblTimeLine)
            };
            lblViews = new WpLabel
            {
                Text = "Views",
                Style = WpThemeReader.GetUiStyle(WpThemeConstants.TOP_HEADER_LABEL),
                AutoSize = true,
                Name = nameof(lblViews)
            };
            lblChats = new WpLabel
            {
                Text = "Chats",
                Style = WpThemeReader.GetUiStyle(WpThemeConstants.TOP_HEADER_LABEL),
                AutoSize = true,
                Name = nameof(lblChats)
            };
            lblAdmin = new WpLabel
            {
                Text = "Admin",
                Style = WpThemeReader.GetUiStyle(WpThemeConstants.TOP_HEADER_LABEL),
                AutoSize = true,
                Name = nameof(lblAdmin)
            };
            lblHelp = new WpLabel
            {
                Text = "Help",
                Style = WpThemeReader.GetUiStyle(WpThemeConstants.TOP_HEADER_LABEL),
                AutoSize = true,
                Name = nameof(lblHelp)
            };
            flwLinks.Controls.Add(lblDashBoard);
            flwLinks.Controls.Add(lblTimeLine);
            flwLinks.Controls.Add(lblViews);
            flwLinks.Controls.Add(lblChats);
            flwLinks.Controls.Add(lblAdmin);
            flwLinks.Controls.Add(lblHelp);

            lblDashBoard.Click += RefreshFlow;
            lblTimeLine.Click += RefreshFlow;
            lblViews.Click += RefreshFlow;
            lblChats.Click += RefreshFlow;
            lblAdmin.Click += RefreshFlow;
            lblHelp.Click += RefreshFlow;

            ctrlNotificationWindow = new ctrlNotificationWindow
            {
                Visible = false,
                Size = new Size(250, 400),
                Name = nameof(ctrlNotificationWindow),
                Location = new Point(pbNotifications.Right - 250, pbNotifications.Bottom)
            };

            ctrlUserWindow = new ctrlUserWindow
            {
                Visible = false,
                Size = new Size(350, 300),
                Name = nameof(ctrlUserWindow),
                Location = new Point(pbAvatar.Right - 350, pbAvatar.Bottom)
            };

            _selectedLabel = lblDashBoard;

            var mb = new SolidBrush(WpThemeColors.Yellow);

            flwLinks.Paint += (sender, args) =>
            {
                if(_selectedLabel == null)
                    return;

                args.Graphics.FillRectangle(mb, 
                                            new Rectangle(_selectedLabel.Left, 
                                                          Math.Min(_selectedLabel.Bottom, flwLinks.Height) - 2,
                                                          _selectedLabel.Width,
                                                          4));
                GraphicsHelper.DrawShadow(args.Graphics,
                                          GraphicsHelper.GetRectPath(new Rectangle(-100, -100, Width + 150, 103)),
                                          WpThemeColors.Shadow,
                                          -9);
            };

            Controls.Add(flwLinks);
            Controls.Add(pnlTop);

            ResumeLayout();
        }

        private void RefreshFlow(object sender, EventArgs eventArgs)
        {
            _selectedLabel = sender as WpLabel;
            flwLinks.Refresh();
        }

        #region Overrides of WpUserControl

        public override string StyleKey => WpThemeConstants.WPSTYLE_HEADER;

        public override void ApplyStyle()
        {
            base.ApplyStyle();
            if (pnlTop == null)
                return;

            //var ms = WpThemeReader.GetUiStyle(WpThemeConstants.WPSTYLE_HEADER);

            pnlTop.Style = WpThemeReader.GetUiStyle(WpThemeConstants.WPSTYLE_HEADER_TOP);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (ParentForm != null)
            {
                User32.SetParent(ctrlNotificationWindow.Handle, ParentForm.Handle);
                User32.SetParent(ctrlUserWindow.Handle, ParentForm.Handle);
            }
            base.OnLoad(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #endregion
    }
}
