using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.UiLibrary.Theme;

namespace WProject.UiLibrary.Controls
{
    public partial class WpPictureBox : WpUserControl
    {
        #region Fields

        private Image _image;
        private PictureBoxSizeMode _sizeMode;

        #endregion
        
        #region Properties

        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                Refresh();
            }
        }

        public PictureBoxSizeMode SizeMode
        {
            get
            {
                return _sizeMode;
            }
            set
            {
                _sizeMode = value;
                Refresh();
            }
        }

        #endregion

        #region Constructors

        public WpPictureBox()
        {
            InitializeComponent();
        }

        #endregion
        
        #region Overrides of Control

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image != null)
            {
                switch (SizeMode)
                {
                    case PictureBoxSizeMode.Normal:
                        e.Graphics.DrawImage(Image, Point.Empty);
                        break;
                    case PictureBoxSizeMode.Zoom:   //todo zoom
                    case PictureBoxSizeMode.StretchImage:
                        e.Graphics.DrawImage(Image, new Rectangle(0, 0, Width, Height));
                        break;
                    case PictureBoxSizeMode.AutoSize:
                        Size = Image.Size;
                        e.Graphics.DrawImage(Image, Point.Empty);
                        break;
                    case PictureBoxSizeMode.CenterImage:
                        var mp = new Point(Size - Image.Size);
                        e.Graphics.DrawImage(Image, new Point(mp.X / 2, mp.Y / 2));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            base.OnPaint(e);
        }

        #endregion

        #region Overrides of WpUserControl

        public override string StyleKey => WpThemeConstants.WPSTYLE_PICTURE_BOX_STYLE;
        
        public override void SetStyle()
        {
            Style = OwnStyle ? Style :  WpThemeReader.GetUiStyle(StyleKey);
        }

        #endregion
    }
}
