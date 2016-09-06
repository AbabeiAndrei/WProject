using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WProject.UiLibrary.Components
{
    public partial class GraphicalOverlay : Component
    {
        #region Fields

        private Control _owner;

        #endregion

        #region Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control Owner
        {
            get
            {
                return _owner;
            }
            set
            {
                // The owner form cannot be set to null.
                if (value == null)
                    throw new ArgumentNullException();

                // The owner form can only be set once.
                if (_owner != null)
                    throw new InvalidOperationException();

                // Save the form for future reference.
                _owner = value;

                // Handle the form's Resize event.
                _owner.Resize += OwnerResize;

                // Handle the Paint event for each of the controls in the form's hierarchy.
                ConnectPaintEventHandlers(_owner);
            }
        }

        #endregion

        #region Events

        public event EventHandler<PaintEventArgs> Paint;

        #endregion

        #region Constructors

        public GraphicalOverlay()
        {
            InitializeComponent();
        }

        public GraphicalOverlay(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region Event handlers

        private void OwnerResize(object sender, EventArgs e)
        {
            _owner.Invalidate(true);
        }

        private void Control_ControlAdded(object sender, ControlEventArgs e)
        {
            ConnectPaintEventHandlers(e.Control);
        }

        private void Control_Paint(object sender, PaintEventArgs e)
        {
            Control control = sender as Control;
            Point location;

            if (control == null)
                return;

            if (control == _owner)
                location = control.Location;
            else
            {
                location = _owner.PointToClient(control.Parent.PointToScreen(control.Location));

                location += new Size((control.Width - control.ClientSize.Width)/2,
                                     (control.Height - control.ClientSize.Height)/2);
            }

            if (control != _owner)
                e.Graphics.TranslateTransform(-location.X, -location.Y);

            OnPaint(sender, e);
        }

        #endregion

        #region Private methods

        private void ConnectPaintEventHandlers(Control control)
        {
            // Connect the paint event handler for this control.
            // Remove the existing handler first (if one exists) and replace it.
            control.Paint -= Control_Paint;
            control.Paint += Control_Paint;

            control.ControlAdded -= Control_ControlAdded;
            control.ControlAdded += Control_ControlAdded;

            // Recurse the hierarchy.
            foreach (Control child in control.Controls)
                ConnectPaintEventHandlers(child);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Paint?.Invoke(sender, e);
        }

        #endregion

    }
}
