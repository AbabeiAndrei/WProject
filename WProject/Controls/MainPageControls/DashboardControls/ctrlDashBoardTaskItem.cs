using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WProject.Classes;
using WProject.GenericLibrary.Helpers.Extensions;
using WProject.Helpers;
using WProject.UiLibrary;
using WProject.UiLibrary.Helpers;
using WProject.UiLibrary.Style;
using WProject.UiLibrary.Theme;
using WProject.WebApiClasses.Classes;
using WProject.WebApiClasses.Data;

namespace WProject.Controls.MainPageControls.DashboardControls
{
    public partial class ctrlDashBoardTaskItem : WpUserControl
    {
        #region Fileds

        private readonly Task _task;
        private Brush _ownBrush;

        public new static Size DefaultSize { get; protected set; }

        #endregion

        #region Properties

        public Task Task => _task;

        #endregion

        #region Constructors

        public ctrlDashBoardTaskItem()
        {
            InitializeComponent();

            ddUsers.DisplayMember = user => user?.Name;
            ddUsers.ValueMember = user => user?.Id;
            ddUsers.ImageMember = user => user?.Avatar?.GetImage();
            ddUsers.Items = SimpleCache.GetAll<User>().UnionAtStart(new[] { User.None }).ToList();

            SetDropDownStyles();
        }

        public ctrlDashBoardTaskItem(Task task) 
            : this()
        {
            _task = task;

            SetTaskData();
        }
        
        static ctrlDashBoardTaskItem()
        {
            DefaultSize = new Size(180, 100);
        }

        #endregion

        #region Overrides of WpStyledControl

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if(Task == null)
                return;

            Color mbandColor, mbackColor, mborderColor = WpThemeColors.Gray;
                
            if (Task.AssignedToId.GetValueOrDefault() == WPSuite.ConnectedUser.Id)
            {
                mbandColor = WpThemeColors.Yellow;
                mbackColor = WpThemeColors.LightYellow;
            }
            else
            {
                mbandColor = WpThemeColors.Gray;
                mbackColor = WpThemeColors.LightGray;
            }

            using (Brush mb = new SolidBrush(mbackColor))
                e.Graphics.FillRectangle(mb, ClientRectangle);

            if(_ownBrush == null)
                using (Brush mb = new SolidBrush(mbandColor))
                    e.Graphics.FillRectangle(mb, 0, 0, UIHelper.TASK_COLOR_BAR_WIDTH, Height);
            else
                e.Graphics.FillRectangle(_ownBrush, 0, 0, UIHelper.TASK_COLOR_BAR_WIDTH, Height);

            using (Pen mp = new Pen(mborderColor))
                e.Graphics.DrawRectangle(mp, 0, 0, Width - 1, Height - 1);

            e.Graphics.DrawString(Task.Name, 
                                  WpThemeFonts.DefaultTaskNameFont,
                                  Brushes.Black,
                                  new RectangleF(10, 8, Width - 20, Height - 40));
        }

        #endregion

        #region Private methods

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
        }

        private void SetTaskData()
        {
            if (Task == null)
                return;

            if (Task.AssignedToId.HasValue)
                ddUsers.SetSelectedItem(u => u.Id == Task.AssignedToId.Value);
            else
                ddUsers.SelectedIndex = 0;

            if (Task.Type?.Color != null)
                _ownBrush = new SolidBrush(Task.Type.Color.Value);
        }

        #endregion

    }
}
