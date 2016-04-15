using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.Controls.MainPageControls;
using WProject.Helpers;
using WProject.Interfaces;
using WProject.UiLibrary;
using WProject.UiLibrary.Controls;

namespace WProject.Controls
{
    public partial class ctrlMainPanel : WpUserControl
    {
        #region Fields

        private readonly IDictionary<Pages, MainPageControl> _controls;

        #endregion

        #region Properties

        public Pages SelectedPage { get; private set; }

        public MainPageControl SelectedControlPage => GetPage(SelectedPage);

        #endregion

        #region Constructors

        public ctrlMainPanel()
        {
            InitializeComponent();

            _controls = new Dictionary<Pages, MainPageControl>
            {
                {
                    Pages.DashBoard, new ctrlDashBoard()
                },
                {
                    Pages.TimeLine, new ctrlTimeLine()
                },
                {
                    Pages.Queries, new ctrlQueries()
                },
                {
                    Pages.Views, new ctrlViews()
                },
                {
                    Pages.Chats, new ctrlChats()
                },
                {
                    Pages.Admin, new ctrlAdmin()
                },
                {
                    Pages.Help, new ctrlHelp()
                }
            };

            UIHelper.StatusBar = new ctrlStatusBar
            {
                Dock = DockStyle.Bottom
            };

            Controls.Add(UIHelper.StatusBar);
            Controls.AddRange(_controls.Values.OfType<Control>().ToArray());
            UIHelper.StatusBar.SendToBack();

            ShowPage(Pages.DashBoard);
        }

        #endregion

        #region Overrides of WpUserControl

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                ShowPage(Pages.DashBoard);
            }
            finally
            {
                base.OnLoad(e);
            }
        }

        #endregion

        #region Public methods

        public void ShowPage(Pages page)
        {
            if (!_controls.ContainsKey(page))
            {
                UIHelper.HeaderControl.SetPage(SelectedPage);
                return;
            }

            if (_controls.ContainsKey(SelectedPage))
                _controls[SelectedPage].Visible = false;

            SelectedPage = page;

            _controls[SelectedPage].Visible = true;

            UIHelper.HeaderControl.CanChangeProject = _controls[SelectedPage].CanChangeProject;
            UIHelper.StatusBar.Visible = _controls[SelectedPage].StatusBarVisibility?.Visible ?? false;
            UIHelper.StatusBar.ShowChatsIcon = _controls[SelectedPage].StatusBarVisibility?.ShowChatsIcon ?? false;
            UIHelper.StatusBar.ShowSoundIcon = _controls[SelectedPage].StatusBarVisibility?.ShowSoundIcon ?? false;
            UIHelper.StatusBar.OnChatsClick = _controls[SelectedPage].StatusBarVisibility?.OnChatsClick;
            UIHelper.StatusBar.OnSoundClick = _controls[SelectedPage].StatusBarVisibility?.OnSoundClick;
            UIHelper.StatusBar.SetTexts(_controls[SelectedPage].StatusBarTexts);
        }

        public MainPageControl GetPage(Pages page)
        {
            return _controls.ContainsKey(page)
                       ? _controls[page]
                       : null;
        }

        #endregion
    }
}
