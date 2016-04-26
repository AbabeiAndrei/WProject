using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WProject.Controls
{
    public partial class ChildForm : Form
    {
        private Color _borderColor;
        private float _borderWidth;
        private Pen _borderPen;
        private Brush _borderBrush;
        private bool _drawBorder;
        private int _titleHeight;
        private int __drawBorder => _borderWidth > 0 ? (int) Math.Ceiling(_borderWidth/2) : 0;

        public virtual Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                _borderPen = new Pen(_borderColor, _borderWidth);
                Refresh();
            }
        }

        public virtual float BorderWidth
        {
            get
            {
                return _borderWidth;
            }
            set
            {
                _borderWidth = value;
                _borderPen = new Pen(_borderColor, _borderWidth);
                Refresh();
            }
        }

        public virtual bool DrawBorder
        {
            get
            {
                return _drawBorder;
            }
            set
            {
                _drawBorder = value;
            }
        }

        public virtual int TitleHeight
        {
            get
            {
                return _titleHeight;
            }
            set
            {
                _titleHeight = value;
                Refresh();
            }
        }

        public Pen BorderPen => _borderPen ?? (_borderPen = new Pen(_borderColor, _borderWidth));

        public Brush BorderBrush => _borderBrush ?? (_borderBrush = new SolidBrush(_borderColor));

        public Rectangle DrawBorderRect => new Rectangle(DrawBorder ? __drawBorder - 1 : 0,
                                                         DrawBorder ? __drawBorder - 1 : 0, 
                                                         DrawBorder ? Width - __drawBorder: Width, 
                                                         DrawBorder ? Height - __drawBorder: Height);

        public ChildForm()
        {
            InitializeComponent();

            _borderWidth = 1f;
            _borderColor = Color.Transparent;
            _titleHeight = 8;
            _drawBorder = false;
        }

        public ChildForm(Color borderColor)
            : this()
        {
            _borderColor = borderColor;
            _drawBorder = true;
            _borderPen = new Pen(_borderColor, _borderWidth);
        }

        public ChildForm(Color borderColor, float borderWidth)
            : this(borderColor)
        {
            _borderWidth = borderWidth;
            _drawBorder = true;
            _borderPen = new Pen(_borderColor, _borderWidth);
        }
    }
}
