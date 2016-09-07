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
using WProject.GenericLibrary.Constants;
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.Properties;
using WProject.UiLibrary;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Theme;
using WProject.WebApiClasses.Classes;

namespace WProject.Controls
{
    public partial class ctrlHeader : WpUserControl
    {
        #region Fields

        private Image _userAvatar;

        #endregion
        
        #region Properties

        public Project SelectedProject => ddProjects?.SelectedItem;

        public bool IsSearchActive => txtSearch?.Visible ?? false;

        public bool IsNotificationWindowOpened => ctrlNotificationWindow?.Visible ?? false;

        public bool IsUserProfileWindowOpened => ctrlUserWindow?.Visible ?? false;

        public Image UserAvatar => _userAvatar;

        public int NotificationNumber => ctrlNotificationWindow?.Notification?.Count ?? 0;

        public string SearchText => txtSearch?.Text ?? string.Empty;

        public bool CanChangeProject
        {
            get
            {
                return ddProjects?.Enabled ?? false;
            }
            set
            {
                if (ddProjects != null)
                    ddProjects.Enabled = value;
            }
        }

        #endregion

        #region Events

        public event SelectedItemChangeHandler OnProjectSelectionChanged
        {
            add
            {
                if (ddProjects != null)
                    ddProjects.SelectedItemChanged += value;
            }
            remove
            {
                if (ddProjects != null)
                    ddProjects.SelectedItemChanged -= value;
            }
        }

        #endregion

        #region Constructors

        public ctrlHeader()
        {
            InitializeComponent();

            ddProjects = new WpDropDown<Project>
            {
                Name = UIHelper.ApplicationName,
                Style = WpThemeReader.GetUiStyle(WpThemeConstants.WPSTYLE_DROPDOWN_LIST),
                ItemStyle = WpThemeReader.GetUiStyle(WpThemeConstants.WPSTYLE_DROPDOWN_LIST_ITEM),
                DisplayMember = p => p?.Name,
                ValueMember = p => p.Id,
                Size = new Size(120, 20),
                Location = new Point(pbLogo.Right + 8, 0)
            };

            pnlTop.Controls.Add(ddProjects);

            lblDashBoard.Tag = Pages.DashBoard;
            lblTimeLine.Tag = Pages.TimeLine;
            lblViews.Tag = Pages.Views;
            lblChats.Tag = Pages.Chats;
            lblAdmin.Tag = Pages.Admin;
            lblHelp.Tag = Pages.Help;

            lblDashBoard.Click += OnLabelNavClick;
            lblTimeLine.Click += OnLabelNavClick;
            lblViews.Click += OnLabelNavClick;
            lblChats.Click += OnLabelNavClick;
            lblAdmin.Click += OnLabelNavClick;
            lblHelp.Click += OnLabelNavClick;

            ddProjects.SelectedItemChanged += (sender, args) =>
            {
                WPSuite.SelectedProject = ddProjects.SelectedItem;

                Settings.Default.LastSelectedProjectId = ddProjects.SelectedItem?.Id ?? 0;

                Settings.Default.Save();

                UIHelper.MainPanel
                        .SelectedControlPage
                        .SetProject(ddProjects.SelectedItem);
            };
        }

        #endregion
        
        #region Events

        private void pbSearch_MouseEnter(object sender, EventArgs e)
        {
            pbSearch.Image = Resources.search_s.SetOpacity(1f);
        }

        private void pbSearch_MouseLeave(object sender, EventArgs e)
        {
            pbSearch.Image = Resources.search_s.SetOpacity(0.5f);
        }

        private void pbNotifications_MouseEnter(object sender, EventArgs e)
        {
            pbNotifications.Image = Resources.note_s.SetOpacity(1f);
        }

        private void pbNotifications_MouseLeave(object sender, EventArgs e)
        {
            pbNotifications.Image = Resources.note_s.SetOpacity(0.5f);
        }

        private void pbAvatar_Click(object sender, EventArgs e)
        {

        }

        private void pbAvatar_MouseEnter(object sender, EventArgs e)
        {
            //pbAvatar.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pbAvatar_MouseLeave(object sender, EventArgs e)
        {
            //pbAvatar.BorderStyle = BorderStyle.None;
        }

        private void OnLabelNavClick(object sender, EventArgs eventArgs)
        {
            var mc = sender as WpLabel;

            if (mc?.Tag is Pages)
                UIHelper.MainPanel.ShowPage((Pages) mc.Tag);
        }

        #endregion

        #region Public methods

        public void SetPage(Pages page)
        {
            _selectedLabel = flwLinks.Controls
                                     .OfType<WpLabel>()
                                     .Where(l => l?.Tag is Pages)
                                     .FirstOrDefault(l => (Pages) l.Tag == page);

            flwLinks.Refresh();
        }

        public async System.Threading.Tasks.Task LoadData()
        {
            if (WPSuite.ConnectedUser == null)
                return;

            Logger.Log("Get all projects");

            var mres = await WebCallFactory.GetAllProjects(WPSuite.ConnectedUser.Id);

            if (mres.Error)
            {
                Logger.Log("Error getting projects");
                Logger.Log(mres.Exception);
                UIHelper.ShowError(mres.Exception);
            }
            else
            {
                var mp = mres.Projects.ToList();
                Logger.Log($"{mp.Count} projects found");
                ddProjects.Items = mp;
            }

            ddProjects.Enabled = ddProjects.Items.Count > 1;

            var mi = ddProjects.Items.ToList().FindIndex(p => p.Id == Settings.Default.LastSelectedProjectId);
            if(mi >= 0)
                ddProjects.SelectedIndex = mi;
            else if (ddProjects.Items.Count > 0)
                ddProjects.SelectedIndex = 0;

            pbSearch.Image = Resources.search_s.SetOpacity(0.5f);
            pbNotifications.Image = Resources.note_s.SetOpacity(0.5f);
            
            _userAvatar = (WPSuite.ConnectedUser?.Avatar?.Content != null
                               ? ImageHelper.Convert(WPSuite.ConnectedUser?.Avatar?.Content)
                               : !string.IsNullOrEmpty(WPSuite.ConnectedUser?.Avatar?.Url)
                                     ? await ImageHelper.DownloadImageAsync(WPSuite.ConnectedUser?.Avatar?.Url)
                                     : null) ?? Resources.dummy_avatar;
            
            pbAvatar.Image = _userAvatar;
        }

        #endregion

    }
}
