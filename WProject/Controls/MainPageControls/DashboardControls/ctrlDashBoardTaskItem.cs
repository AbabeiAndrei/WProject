using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WProject.Classes;
using WProject.UiLibrary;
using WProject.UiLibrary.Theme;
using WProject.WebApiClasses.Classes;

namespace WProject.Controls.MainPageControls.DashboardControls
{
    public partial class ctrlDashBoardTaskItem : WpUserControl
    {
        #region Fileds

        private readonly Task _task;

        public new static Size DefaultSize { get; protected set; }

        #endregion

        #region Constructors

        public ctrlDashBoardTaskItem()
        {
            InitializeComponent();
        }

        public ctrlDashBoardTaskItem(Task task) 
            : this()
        {
            _task = task;
        }

        static ctrlDashBoardTaskItem()
        {
            DefaultSize = new Size(150, 70);
        }

        #endregion

        #region Overrides of WpStyledControl

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if(_task == null)
                return;

            Color mbandColor, mbackColor, mborderColor = WpThemeColors.Gray;
                
            if (_task.AssignedToId.GetValueOrDefault() == WPSuite.ConnectedUser.Id)
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

            using (Pen mp = new Pen(mborderColor))
                e.Graphics.DrawRectangle(mp, 0, 0, Width - 1, Height - 1);

            using (Brush mb = new SolidBrush(mbandColor))
                e.Graphics.FillRectangle(mb, 0, 0, 6, Height);

            e.Graphics.DrawString(_task.Name, 
                                  WpThemeFonts.DefaultTaskNameFont,
                                  Brushes.Black,
                                  new RectangleF(10, 8, Width - 20, Height - 40));
        }

        #endregion
    }
}
