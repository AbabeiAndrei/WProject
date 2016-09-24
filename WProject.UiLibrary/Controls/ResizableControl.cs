using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WProject.UiLibrary.Controls
{

    [Flags]
    public enum ResizeDirection : short
    {
        None = 0,
        /// <summary>
        /// Not implemented
        /// </summary>
        West = 1,
        /// <summary>
        /// Not implemented
        /// </summary>
        North = 2,
        East = 4,
        South = 8,
        All = West | North | East | South
    }

    public enum MoveDirection : short
    {
        None = 0,
        Vertical = 1,
        Horizontal = 2,
        Both = Vertical | Horizontal
    }

    public partial class ResizableControl : WpUserControl
    {
        #region Fields

        private ResizeDirection _onResizeDirection;
        private ResizeDirection _direction;
        private Point _startLocation;
        private int _snap;
        private Size _dragOffset;
        private Point _oldLocation;
        private Size _oldSize;
        private bool _drawSizeGliph;
        private bool _moved;
        private bool _resized;
        private bool _isClick;
        private int _resizezableInTime;
        private bool _lockInViewPort;
        private bool _snapToOthers;
        private int _edgeSize;
        private bool _dragable;
        private MoveDirection _moveDirection;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets if the control can be dragged (moved with mouse)
        /// </summary>
        [Category("Resize"), Description("Specifies if control can be draged."), DefaultValue(true)]
        public virtual bool Dragable
        {
            get
            {
                return _dragable;
            }
            set
            {
                _dragable = value;
            }
        }

        /// <summary>
        /// Gets or sets the direction of resize (flags)
        /// </summary>
        [Category("Resize"), Description("Specifies direction of resize."), DefaultValue(ResizeDirection.All)]
        public virtual ResizeDirection Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the direction of move (flags)
        /// </summary>
        [Category("Resize"), Description("Specifies direction of move."), DefaultValue(MoveDirection.Both)]
        public virtual MoveDirection MoveDirection
        {
            get
            {
                return _moveDirection;
            }
            set
            {
                _moveDirection = value;
            }
        }

        /// <summary>
        /// Gets or sets the edge size of resizing
        /// </summary>
        [Category("Resize"), Description("Specifies edge size for mouse"), DefaultValue(15)]
        public virtual int EdgeSize
        {
            get
            {
                return _edgeSize;
            }
            set
            {
                _edgeSize = value;
            }
        }

        /// <summary>
        /// Gets or sets if the control grid of snaping (1 = no snaping).
        /// Value must be grater or equals than 1
        /// </summary>
        [Category("Resize"), Description("Specifies snaping"), DefaultValue(5)]
        public virtual int Snap
        {
            get
            {
                return _snap;
            }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException(@"Snap", value, @"Snap must be bigger than 0 (>=1)");
                _snap = value;
            }
        }

        /// <summary>
        /// Not used (not implemented)
        /// </summary>
        [Category("Resize"), Description("Specifies snaping to other controls"), DefaultValue(false), Browsable(false)]
        public virtual bool SnapToOthers
        {
            get
            {
                return _snapToOthers;
            }
            set
            {
                _snapToOthers = value;
            }
        }

        /// <summary>
        /// Gets or sets if size gliph is drawed
        /// </summary>
        [Category("Resize"), Description("Specifies if the rezise gliph is drawed"), DefaultValue(true)]
        public virtual bool DrawSizeGliph
        {
            get
            {
                return _drawSizeGliph;
            }
            set
            {
                if (_drawSizeGliph != value)
                    Refresh();
                _drawSizeGliph = value;
            }
        }

        /// <summary>
        /// Gets or sets time after click is fired (0 means instant)
        /// </summary>
        [Category("Resize"), Description("Specifies time after click event is fired"), DefaultValue(0)]
        public virtual int ResizezableInTime
        {
            get
            {
                return _resizezableInTime;
            }
            set
            {
                if (value > 0)
                    tmrClick.Interval = value;
                _resizezableInTime = value;
            }
        }

        /// <summary>
        /// Gets or sets if user can resize outside the parent control
        /// </summary>
        [Category("Resize"), Description("Specifies if user can resize outside the parent control"), DefaultValue(0)]
        public virtual bool LockInViewPort
        {
            get
            {
                return _lockInViewPort;
            }
            set
            {
                _lockInViewPort = value;
            }
        }

        public Size MinimumSizeForResize { get; set; }

        #endregion

        #region Events

        public delegate void ControlResizeHandler(object sender, ControlResizedArgs args);

        public delegate void ControlMovedHandler(object sender, ControlMovedArgs args);

        /// <summary>
        /// Event trigered after the control was resized (not fired on Size property changed)
        /// </summary>
        public event ControlResizeHandler AfterResize;

        /// <summary>
        /// Event trigered after the control was moved (not fired on Location property changed) 
        /// </summary>
        public event ControlMovedHandler AfterMove;

        /// <summary>
        /// Event trigered when resize starts
        /// </summary>
        public event EventHandler BeginResize;

        /// <summary>
        /// Event trigered when drag starts
        /// </summary>
        public event EventHandler BeginMove;

        #endregion

        #region Constructors

        public ResizableControl()
        {
            InitializeComponent();

            _dragable = true;
            _direction = ResizeDirection.All;
            _moveDirection = MoveDirection.Both;
            _edgeSize = 15;
            _snap = 5;
            _snapToOthers = false;
            _drawSizeGliph = false;
            _resizezableInTime = 0;
            _lockInViewPort = true;

            _onResizeDirection = ResizeDirection.None;
            _isClick = false;
        }

        #endregion

        #region Events

        private void tmrClick_Tick(object sender, EventArgs e)
        {
            _isClick = false;
            tmrClick.Stop();
        }

        #endregion

        #region Overrides of UserControl

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _moved =
                _resized = false;

            //seteaza flag-ul pentru click daca se foloseste ResizezableInTime
            _isClick = ResizezableInTime > 0;

            if (ResizezableInTime > 0)
                tmrClick.Start();

            var mr = GetMouseDirection(e.Location);

            if (mr == ResizeDirection.All && Dragable)
            {
                _startLocation = e.Location;
                _oldLocation = Location;
            }
            if (e.Button == MouseButtons.Left && Direction != ResizeDirection.None)
            {
                if (mr == ResizeDirection.All && !Dragable)
                {
                    mr = ResizeDirection.None;
                    _dragOffset = Size.Empty;
                }
                else
                {
                    _dragOffset = GetOffset(GetMouseDirection(e.Location), e.Location);
                    _oldSize = Size;
                }
                _onResizeDirection = mr;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_isClick)
                return;
            if (_onResizeDirection != ResizeDirection.None)
            {
                if (_onResizeDirection == ResizeDirection.All)
                {
                    if (BeginMove != null)
                        BeginMove(this, EventArgs.Empty);
                    MoveByMouse(e.Location);
                }
                else
                {
                    if (BeginResize != null)
                        BeginResize(this, EventArgs.Empty);
                    ResizeByMouse(_onResizeDirection, e.Location, _dragOffset);
                }
            }
            if (Direction != ResizeDirection.None)
            {
                ResizeDirection mdirection = GetMouseDirection(e.Location);
                Cursor = HaveResizeDirection(mdirection) 
                            ? GetCursorForDirection(mdirection) 
                            : Cursors.Arrow;
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(!_isClick)
                if (_onResizeDirection == ResizeDirection.All && _moved)
                {
                    ApplySnapOnMove();
                    if (AfterMove != null)
                        AfterMove(this, new ControlMovedArgs(_oldLocation, Location));
                }
                else if (_onResizeDirection != ResizeDirection.None && _resized)
                {
                    ApplySnapResize(GetDirectionFromResizeDirection(_onResizeDirection));
                    if (AfterResize != null)
                        AfterResize(this, new ControlResizedArgs(_oldSize, Size));
                }

            _onResizeDirection = ResizeDirection.None;
            _moved = _resized = false;
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (DrawSizeGliph && HaveResizeDirection(ResizeDirection.South | ResizeDirection.East))
            {
                var rc = new Rectangle(Width - 16, Height - 16, 16, 16);
                ControlPaint.DrawSizeGrip(e.Graphics, BackColor, rc);
            }
            base.OnPaint(e);
        }

        #endregion

        #region Private methods

        private Cursor GetCursorForDirection(ResizeDirection direction)
        {
            if (direction == ResizeDirection.None || direction == ResizeDirection.All)
                return Cursors.Arrow;
            if (HaveResizeDirection(direction, ResizeDirection.West | ResizeDirection.North) ||
                HaveResizeDirection(direction, ResizeDirection.East | ResizeDirection.South))
                return Cursors.SizeNWSE;
            if (HaveResizeDirection(direction, ResizeDirection.West | ResizeDirection.South) ||
                HaveResizeDirection(direction, ResizeDirection.East | ResizeDirection.North))
                return Cursors.SizeNESW;
            if (HaveResizeDirection(direction, ResizeDirection.North) ||
                HaveResizeDirection(direction, ResizeDirection.South))
                return Cursors.SizeNS;
            if (HaveResizeDirection(direction, ResizeDirection.West) ||
                HaveResizeDirection(direction, ResizeDirection.East))
                return Cursors.SizeWE;

            return Cursors.Arrow;
        }

        private void MoveByMouse(Point location)
        {
            Point mloffset = location - (Size)_startLocation;
            int mnewx = Location.X + mloffset.X;
            int mnewy = Location.Y + mloffset.Y;

            //todo snap as drag

            if (LockInViewPort)
            {
                if(mnewx < 0)
                    mnewx = 0;
                if (mnewy < 0)
                    mnewy = 0;
                if(Parent != null && Parent.Width < Width + mnewx)
                    mnewx = Parent.Width - Width;
                if (Parent != null && Parent.Height < Height + mnewy)
                    mnewy = Parent.Height - Height;
            }

            if (!MoveDirection.HasFlag(MoveDirection.Horizontal))
                mnewx = Location.X;

            if (!MoveDirection.HasFlag(MoveDirection.Vertical))
                mnewy = Location.Y;

            Location = new Point(mnewx, mnewy);
            _moved = true;
        }

        private void ResizeByMouse(ResizeDirection direction, Point location, Size offset)
        {
            if (HaveResizeDirection(direction, ResizeDirection.East | ResizeDirection.South))
                if (
                        LockInViewPort && 
                        Parent != null &&
                        (
                            Parent.Width < Left + location.X + offset.Width ||
                            Parent.Height < Top + location.Y + offset.Height
                        )
                   )
                {
                    Size = new Size(Math.Min(location.X + offset.Width, Parent.Width - Left),
                                    Math.Min(location.Y + offset.Height, Parent.Height - Top));
                }
                else if (MinimumSizeForResize.Width > location.X + offset.Width ||
                         MinimumSizeForResize.Height > location.Y + offset.Height)
                    Size = new Size(Math.Max(MinimumSizeForResize.Width, location.X + offset.Width),
                                    Math.Max(MinimumSizeForResize.Height, location.Y + offset.Height));
                else 
                    Size = new Size(location.X + offset.Width, location.Y + offset.Height);
            else if (HaveResizeDirection(direction, ResizeDirection.West | ResizeDirection.North))
            {
                /*var mns = new Size(location.X + offset.Width, location.Y + offset.Height);
                Location = Location - (Size - mns);
                Size = mns;//todo*/
            }
            else if (HaveResizeDirection(direction, ResizeDirection.North | ResizeDirection.East))
            {
                /*var mns = new Size(location.X + offset.Width, location.Y + offset.Height);
                Location = Location - (Size - mns);
                Size = mns;//todo*/
            }
            else if (HaveResizeDirection(direction, ResizeDirection.West | ResizeDirection.South))
            {
                /*var mns = new Size(location.X + offset.Width, location.Y + offset.Height);
                Location = Location - (Size - mns);
                Size = mns;//todo*/
            }
            else if (HaveResizeDirection(direction, ResizeDirection.West))
            {
                /*var mns = new Size(location.X + offset.Width, location.Y + offset.Height);
                Location = Location - (Size - mns);
                Size = mns;//todo*/
            }
            else if (HaveResizeDirection(direction, ResizeDirection.North))
            {
                /*var mns = new Size(location.X + offset.Width, location.Y + offset.Height);
                Location = Location - (Size - mns);
                Size = mns;//todo*/
            }
            else if (HaveResizeDirection(direction, ResizeDirection.East))
                if (LockInViewPort && Parent != null && Parent.Width < Left + location.X + offset.Width)
                    Size = new Size(Parent.Width - Left, Height);
                else if (MinimumSizeForResize.Width > location.X + offset.Width)
                    Size = new Size(Math.Max(MinimumSizeForResize.Width, location.X + offset.Width), Height);                    
                else
                    Size = new Size(location.X + offset.Width, Height);
            else if (HaveResizeDirection(direction, ResizeDirection.South))
                if (LockInViewPort && Parent != null && Parent.Height < Top + location.Y + offset.Height)
                    Size = new Size(Width, Parent.Height - Top);
                else if (MinimumSizeForResize.Height > location.Y + offset.Height)
                    Size = new Size(Width, Math.Max(MinimumSizeForResize.Height, location.Y + offset.Height));
                else  
                    Size = new Size(Width, location.Y + offset.Height);
            else
                return;
            Refresh();
            _resized = true;
        }

        private Size GetOffset(ResizeDirection direction, Point location)
        {
            if (HaveResizeDirection(direction, ResizeDirection.East | ResizeDirection.South))
                return new Size(Width - location.X, Height - location.Y);
            return Size.Empty;
        }

        private ResizeDirection GetMouseDirection(Point location)
        {
            if (location.X <= EdgeSize && location.Y > EdgeSize && location.Y < Height - EdgeSize && Direction.HasFlag(ResizeDirection.West))
                return ResizeDirection.West;
            if (location.X <= EdgeSize && location.Y <= EdgeSize && Direction.HasFlag(ResizeDirection.West | ResizeDirection.North))
                return ResizeDirection.West | ResizeDirection.North;
            if (location.X > EdgeSize && location.Y <= EdgeSize && location.X < Width - EdgeSize && Direction.HasFlag(ResizeDirection.North))
                return ResizeDirection.North;
            if (location.X >= Width - EdgeSize && location.Y <= EdgeSize && Direction.HasFlag(ResizeDirection.North | ResizeDirection.East))
                return ResizeDirection.North | ResizeDirection.East;
            if (/*location.Y > EdgeSize && */location.X >= Width - EdgeSize && /*location.Y < Height - EdgeSize &&*/ Direction.HasFlag(ResizeDirection.East))
                return ResizeDirection.East;
            if (location.X >= Width - EdgeSize && location.Y >= Height - EdgeSize && Direction.HasFlag(ResizeDirection.East | ResizeDirection.South))
                return ResizeDirection.East | ResizeDirection.South;
            if (location.X > EdgeSize && location.Y >= Height - EdgeSize && location.X < Width - EdgeSize && Direction.HasFlag(ResizeDirection.South))
                return ResizeDirection.South;
            if (location.X <= EdgeSize && location.Y >= Height - EdgeSize && Direction.HasFlag(ResizeDirection.South | ResizeDirection.West))
                return ResizeDirection.South | ResizeDirection.West;
            return ResizeDirection.All;
        }

        private bool HaveResizeDirection(ResizeDirection direction)
        {
            return Direction == ResizeDirection.All || HaveResizeDirection(Direction, direction);
        }

        private bool HaveResizeDirection(ResizeDirection direction, ResizeDirection have)
        {
            return direction == have || (direction & have) == have;
        }

        private bool HaveDirection(FDirection direction, FDirection have)
        {
            return direction == have || (direction & have) == have;
        }

        private FDirection GetDirectionFromResizeDirection(ResizeDirection direction)
        {
            if (direction == ResizeDirection.East || direction == ResizeDirection.West)
                return FDirection.Horizontal;
            if (direction == ResizeDirection.North || direction == ResizeDirection.South)
                return FDirection.Vertical;
            return FDirection.Both;
        }

        private void ApplySnapOnMove(FDirection direction = FDirection.Both)
        {

            int msl;
            if (HaveDirection(direction, FDirection.Horizontal))
            {
                msl = Left % Snap;
                if (msl != 0)
                    Left += (Snap - msl);
            }

            if (HaveDirection(direction, FDirection.Vertical))
            {
                msl = Top % Snap;
                if (msl != 0)
                    Top += (Snap - msl);
            }
            Refresh();
        }

        private void ApplySnapResize(FDirection direction = FDirection.Both)
        {
            int msl;
            if (HaveDirection(direction, FDirection.Horizontal))
            {
                msl = Width % Snap;
                if (msl != 0)
                    Width += (Snap - msl);
            }

            if (HaveDirection(direction, FDirection.Vertical))
            {
                msl = Height % Snap;
                if (msl != 0)
                    Height += (Snap - msl);
            }
            Refresh();
        }

        #endregion

        #region Enums

        [Flags]
        private enum FDirection : short
        {
            Vertical = 0,
            Horizontal = 1,
            Both = Vertical | Horizontal
        }

        #endregion
    }

    #region Event Args

    public class ControlResizedArgs : EventArgs
    {
        /// <summary>
        /// Gets the old size of control
        /// </summary>
        public Size OldSize { get; private set; }

        /// <summary>
        /// Gets the new size of control
        /// </summary>
        public Size NewSize { get; private set; }

        public ControlResizedArgs()
        {
        }

        public ControlResizedArgs(Size oldSize, Size newSize)
        {
            OldSize = oldSize;
            NewSize = newSize;
        }
    }

    public class ControlMovedArgs : EventArgs
    {
        /// <summary>
        /// Gets the old location of control
        /// </summary>
        public Point OldLocation { get; private set; }

        /// <summary>
        /// Gets the new location of control
        /// </summary>
        public Point NewLocation { get; private set; }

        public ControlMovedArgs()
        {
        }

        public ControlMovedArgs(Point oldLocation, Point newLocation)
        {
            OldLocation = oldLocation;
            NewLocation = newLocation;
        }
    }

    #endregion
}
