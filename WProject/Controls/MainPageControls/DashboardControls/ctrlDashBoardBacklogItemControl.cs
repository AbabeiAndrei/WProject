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
using WProject.GenericLibrary.Constants;
using WProject.GenericLibrary.Helpers.Extensions;
using WProject.Properties;
using WProject.UiLibrary;
using WProject.UiLibrary.Theme;
using WProject.WebApiClasses.Classes;
using WProject.WebApiClasses.Data;

namespace WProject.Controls.MainPageControls.DashboardControls
{
    public partial class ctrlDashBoardBacklogItemControl : WpUserControl
    {
        #region Fields

        private Backlog _backlog;

        private const int BACKLOG_COLOR_BAR_WIDTH = 16;

        private static Brush BacklogColorBarBrushYellow { get; }

        private static Brush BacklogColorBarBrushGray { get; }

        #endregion

        #region Properties

        public new static Size DefaultSize { get; }

        public Backlog Backlog
        {
            get
            {
                return _backlog;
            }
            set
            {
                _backlog = value;
                SetBacklogData();
            }
        }

        #endregion
        
        #region Constructors

        public ctrlDashBoardBacklogItemControl()
        {
            InitializeComponent();//aa

            ddUsers.DisplayMember = user => user.Name;
            ddUsers.ValueMember = user => user.Id;
            ddUsers.ImageMember = user => user.Avatar?.GetImage();
            ddUsers.Items = SimpleCache.GetAll<User>().UnionAtStart(new [] { User.None}).ToList();

            ddStates.DisplayMember = item => item.Name;
            ddStates.ValueMember = item => item.Id;
            ddStates.Items = SimpleCache.GetAll<DictItem>().Where(di => di.Type == Constants.DictItemCodes[DictItemType.BacklogState]).ToList();
        }

        public ctrlDashBoardBacklogItemControl(Backlog backlog)
                :this()
        {
            _backlog = backlog;
            SetBacklogData();
        }

        static ctrlDashBoardBacklogItemControl()
        {
            BacklogColorBarBrushYellow = new SolidBrush(WpThemeColors.Orange);
            BacklogColorBarBrushGray = new SolidBrush(WpThemeColors.Gray);
            DefaultSize = new Size(230, 140);
        }

        #endregion

        #region Overrides of WpStyledControl

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if(_backlog?.AssignedToId == null)
                    return;

                Brush mbrush = _backlog.AssignedToId.Value == WPSuite.ConnectedUserId
                                   ? BacklogColorBarBrushYellow
                                   : BacklogColorBarBrushGray;

                e.Graphics.FillRectangle(mbrush, new Rectangle(0, 0, BACKLOG_COLOR_BAR_WIDTH, Height));
            }
            finally
            {
                base.OnPaint(e);
            }
        }

        #endregion

        #region Private methods

        private void SetBacklogData()
        {
            if(_backlog == null)
                return;

            lblName.Text = _backlog.Name;

            if (_backlog.AssignedToId.HasValue)
                ddUsers.SetSelectedItem(u => u.Id == _backlog.AssignedToId.Value);
            else
                ddUsers.SelectedIndex = 0;

            ddStates.SetSelectedItem(di => di.Id == _backlog.StateId);
        }

        #endregion

    }
}
