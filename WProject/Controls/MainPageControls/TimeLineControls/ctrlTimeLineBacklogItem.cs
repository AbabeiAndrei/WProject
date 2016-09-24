    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
    using WProject.GenericLibrary.Helpers.Drawing;
    using WProject.Helpers;
    using WProject.UiLibrary.Controls;
    using WProject.UiLibrary.Theme;
    using Task = WProject.WebApiClasses.Classes.Task;

namespace WProject.Controls.MainPageControls.TimeLineControls
{
    public partial class ctrlTimeLineBacklogItem : WpUserControl
    {
        #region Constants

        private const int RIBON_WIDTH = 8;

        #endregion

        #region Fields

        private Color _ribbonColor;

        private static readonly StringFormat _defaultDrawStringFormat = new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center
        };

        #endregion

        #region Properties

        public int BacklogId { get; set; }

        public int UserId { get; set; }

        public Color RibbonColor
        {
            get
            {
                return _ribbonColor;
            }
            set
            {
                _ribbonColor = value;

                Invalidate(new Rectangle(0, 0, RIBON_WIDTH, Height));
                Update();
            }
        }

        #endregion

        #region Events

        public event Action<int, int, Color> BacklogMouseEnter;

        #endregion
        
        #region Overrides of UserControl

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;

                Invalidate(new Rectangle(RIBON_WIDTH, 0, Width - RIBON_WIDTH, Height));
                Update();
            }
        }

        #endregion

        #region Constructors

        public ctrlTimeLineBacklogItem()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides of WpStyledControl

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                using (Brush mb = new SolidBrush(RibbonColor))
                    e.Graphics.FillRectangle(mb, new Rectangle(Padding.Left, Padding.Top, RIBON_WIDTH, Height));

                using (Brush mb = new SolidBrush(ForeColor))
                    e.Graphics.DrawString(Text, 
                                          Font, 
                                          mb, 
                                          new RectangleF(Padding.Left + RIBON_WIDTH + 2, Padding.Top, Width - RIBON_WIDTH - Padding.Horizontal, Height));
            }
            finally
            {
                base.OnPaint(e);
            }
        }
        
        protected override void OnMouseEnter(EventArgs e)
        {
            try
            {
                BacklogMouseEnter?.Invoke(BacklogId, UserId, WpThemeColors.Amber.SetOpacity(80));
            }
            finally
            {
                base.OnMouseEnter(e);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            try
            {
                BacklogMouseEnter?.Invoke(BacklogId, UserId, WpThemeColors.White.SetOpacity(80));
            }
            finally
            {
                base.OnMouseLeave(e);
            }
        }
        
        #endregion

        #region Overrides of Control

        protected override void OnClick(EventArgs e)
        {
            try
            {
                var mcontrol = UIHelper.MainPanel.SelectedControlPage as ctrlTimeLine;

                if(mcontrol == null)
                    return;

                var mbacklog = mcontrol.Tasks.FirstOrDefault(b => b.BacklogId == BacklogId)?.Backlog;

                if(mbacklog != null)
                    UIHelper.ShowBackLogEditor(mbacklog, async b => await mcontrol.LoadTasks());
            }
            finally
            { 
                base.OnClick(e);
            }
        }

        #endregion

        #region Public methods

        public int CalculateSize()
        {
            using (var mgfx = CreateGraphics())
            {
                var ms = mgfx.MeasureString(Text,
                                            Font,
                                            new Size(Width - RIBON_WIDTH - Padding.Horizontal, Height),
                                            _defaultDrawStringFormat);

                return (int) ms.Height;
            }
        }

        public void ClearItems()
        {

        }

        #endregion
    }
}
