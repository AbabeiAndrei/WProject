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

        public event Action<int, Color> BacklogMouseEnter;

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
                BacklogMouseEnter?.Invoke(BacklogId, WpThemeColors.Amber.SetOpacity(80));
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
                BacklogMouseEnter?.Invoke(BacklogId, WpThemeColors.White.SetOpacity(80));
            }
            finally
            {
                base.OnMouseLeave(e);
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

        #endregion

    }
}
