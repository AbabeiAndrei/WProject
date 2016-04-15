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
using WProject.GenericLibrary.Helpers.Extensions;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.Properties;
using WProject.UiLibrary;
using WProject.UiLibrary.Annotations;
using WProject.UiLibrary.Classes;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Helpers;
using WProject.UiLibrary.Style;
using WProject.UiLibrary.Theme;
using WProject.WebApiClasses.Classes;
using WProject.WebApiClasses.Data;

namespace WProject.Controls.MainPageControls.DashboardControls
{
    public partial class ctrlDashBoardBacklogItemControl : WpUserControl
    {
        #region Fields

        private Backlog _backlog;
        private Brush _ownBrush;

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
            InitializeComponent();

            ddUsers.DisplayMember = user => user?.Name;
            ddUsers.ValueMember = user => user?.Id;
            ddUsers.ImageMember = user => user?.Avatar?.GetImage();
            ddUsers.Items = SimpleCache.GetAll<User>().UnionAtStart(new [] { User.None}).ToList();

            ddStates.DisplayMember = item => item?.Name;
            ddStates.ValueMember = item => item?.Id;
            ddStates.Items = SimpleCache.GetAll<DictItem>()
                                        .Where(di => di.Type == Constants.DictItemCodes[DictItemType.BacklogState])
                                        .OrderBy(di => di.Order)
                                        .ThenBy(di => di.Id)
                                        .ToList();
            ddStates.SelectedItemChanged += DdStatesOnSelectedItemChanged;

            SetDropDownStyles();
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
            DefaultSize = new Size(220, 160);
        }

        #endregion

        #region Overrides of WpStyledControl

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if(_backlog?.AssignedToId == null)
                    return;

                Brush mbrush = _ownBrush ?? 
                               (_backlog.AssignedToId.Value == WPSuite.ConnectedUserId
                                       ? BacklogColorBarBrushYellow
                                       : BacklogColorBarBrushGray);

                e.Graphics.FillRectangle(mbrush, new Rectangle(0, 0, UIHelper.BACKLOG_COLOR_BAR_WIDTH, Height));
            }
            finally
            {
                base.OnPaint(e);
            }
        }

        #endregion

        #region Overrides of WpUserControl

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Padding = Padding.SetPadding(UIHelper.BACKLOG_COLOR_BAR_WIDTH, Direction.Left);
        }

        #endregion

        #region Events

        private async void DdStatesOnSelectedItemChanged(object sender, SelectedItemChangeHandlerArgs args)
        {
            try
            {
                Logger.Log($"Change state for backlog {_backlog.Id} from {_backlog.State?.Code} to {ddStates.SelectedItem?.Code}");
                var mres = await WebCallFactory.ChangeBacklogState(_backlog.Id, ddStates.SelectedItem?.Code);

                if (mres.Error)
                    throw mres.Exception;

                Logger.Log("Success!");
            }
            catch
            {
                ddStates.SelectedItemChanged -= DdStatesOnSelectedItemChanged;
                ddStates.SelectedIndex = args.OldSelectedIndex;
                ddStates.SelectedItemChanged += DdStatesOnSelectedItemChanged;
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

            if(_backlog.Type?.Color != null)
                _ownBrush = new SolidBrush(_backlog.Type.Color.Value);
        }

        private void SetDropDownStyles()
        {
            ddUsers.Style = new UiStyle
            {
                NormalStyle = new Style
                {
                    BackColor = Color.Transparent,
                    ForeColor = Color.Black,
                    Padding = Padding.SetPadding(3, Direction.Up)
                },
                HoverStyle = new Style
                {
                    BackColor = Color.Transparent,
                    ForeColor = Color.Black,
                    Padding = Padding.SetPadding(3, Direction.Up),
                    BorderColor = WpThemeColors.Teal,
                    BorderWidth = 1f,
                    Cursor = Cursors.Hand
                }
            };

            ddStates.Style = ddUsers.Style.Clone();
        }


        #endregion

    }
}
