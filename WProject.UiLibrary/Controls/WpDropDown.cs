using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

using WProject.GenericLibrary.Helpers.Extensions;
using WProject.GenericLibrary.Helpers.Log;
using WProject.GenericLibrary.WinApi;
using WProject.UiLibrary.Classes;
using WProject.UiLibrary.Designer;
using WProject.UiLibrary.Designer.Convertors;
using WProject.UiLibrary.Helpers;
using WProject.UiLibrary.Style;
using WProject.UiLibrary.Theme;

namespace WProject.UiLibrary.Controls
{
    public class WpDropDown : WpDropDown<string>
    {
        #region Overrides of WpDropDown<string>

        [Category("Data")]
        [TypeConverter(typeof(CsvConverter))]
        [Editor(@"System.Windows.Forms.Design.StringCollectionEditor,System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public new IList<string> Items
        {
            get
            {
                return base.Items;
            }
            set
            {
                base.Items = value;
            }
        }

        #endregion
    }

    [Designer(typeof(WpDropDownControlDesigner))]
    public partial class WpDropDown<T> : WpStyledControl 
    {
        #region Statics

        public static UiStyle DefaultStyle;
        public static UiStyle DefaultItemStyle;

        #endregion

        #region Fields

        private const int MAX_ITEMS_CONTINER_HEIGHT = 440;
        private const int MIN_ITEMS_CONTINER_HEIGHT = 10;

        private ObservableCollection<T> _items;
        private Brush _foreBrush;
        private Func<T, object> _sortMember;
        private WpPanel frmItemsContainer;
        private UiStyle _itemStyle;
        private int _selectedIndex;
        private Func<T, string> _displayMember;
        private Func<T, object> _valueMember;
        private bool _showImage;
        private Func<T, Image> _imageMember;

        #endregion

        #region Properties

        [Category("Data")]
        [TypeConverter(typeof(CsvConverter))]
        public virtual IList<T> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = new ObservableCollection<T>(value);
                InitStuff();
            }
        }

        [Category("Style")]
        public virtual UiStyle ItemStyle
        {
            get
            {
                return _itemStyle;
            }
            set
            {
                _itemStyle = value;
                CreateItems();
                Parent?.Refresh();
            }
        }

        [Category("Style")]
        public virtual bool ShowImage
        {
            get
            {
                return _showImage;
            }
            set
            {
                _showImage = value;
                Refresh();
            }
        }

        [Browsable(false)]
        public virtual Func<T, Image> ImageMember
        {
            get
            {
                return _imageMember;
            }
            set
            {
                _imageMember = value;
                CreateItems();
                Refresh();
            }
        }

        [Browsable(false)]
        public virtual Func<T, string> DisplayMember
        {
            get
            {
                return _displayMember;
            }
            set
            {
                _displayMember = value;
                CreateItems();
            }
        }

        [Browsable(false)]
        public virtual Func<T, object> ValueMember
        {
            get
            {
                return _valueMember;
            }
            set
            {
                _valueMember = value;
                CreateItems();
            }
        }

        [Browsable(false)]
        public virtual Func<T, object> SortMember
        {
            get
            {
                return _sortMember;
            }
            set
            {
                _sortMember = value;
                if (_sortMember != null)
                    Items = Items.OrderBy(t => _sortMember.Invoke(t)).ToList();
                else
                    InitStuff();
            }
        }

        [Browsable(false)]
        public virtual int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                SelectItem(value);
            }
        }
        
        [Browsable(false)]
        public virtual T SelectedItem => _items != null && _items.Count > SelectedIndex ? _items[SelectedIndex] : default(T);

        [Browsable(false)]
        public virtual object SelectedValue => ValueMember?.Invoke(SelectedItem) ?? SelectedItem;

        [Browsable(false)]
        public new virtual string Text => DisplayMember?.Invoke(SelectedItem) ?? SelectedItem?.ToString() ?? string.Empty;

        [Browsable(false)]
        public virtual bool ItemContainerIsOpen => frmItemsContainer?.Visible ?? false;

        [Browsable(false)]
        public virtual Func<T, Control> CustomControl { get; set; }

        #endregion

        #region Events

        public event SelectedItemChangeHandler SelectedItemChanged;

        #endregion
        
        #region Constructors

        public WpDropDown()
        {
            InitializeComponent();

            _items = new ObservableCollection<T>(Enumerable.Empty<T>());
            base.Style = DefaultStyle;
            _itemStyle = DefaultItemStyle;
        }
        
        public WpDropDown(IEnumerable<T> list) 
            : this()
        {
            _items = new ObservableCollection<T>(list);
        }

        static WpDropDown()
        {
            DefaultStyle = UiStyle.DefaultStyle;
            DefaultItemStyle = UiStyle.DefaultHoverStyle;
        }

        #endregion

        #region Overrides of Control

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if(!ItemContainerIsOpen)
                OpenItemsContainer();
        }
        
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (ParentForm != null && frmItemsContainer != null)
                User32.SetParent(frmItemsContainer.Handle, ParentForm.Handle);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, Font.Height, specified);
        }

        #endregion

        #region Overrides of WpBaseUserControl

        protected override void OnLoad(EventArgs e)
        {
            DoubleBuffered = true;
            base.OnLoad(e);
            Refresh();
        }

        #endregion

        #region Overrides of WpStyledControl

        public override UiStyle Style
        {
            get
            {
                return base.Style;
            }
            set
            {
                base.Style = value;
                Refresh();
            }
        }

        protected override void OnStyleChanged(EventArgs e)
        {
            _foreBrush = new SolidBrush(ForeColor);
            Refresh();
            base.OnStyleChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                int mtextDrawLeft = CurrentStyle.Padding.Left;

                if (ShowImage)
                    mtextDrawLeft += Height;

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.CompositingQuality = CompositingQuality.AssumeLinear;

                if (ShowImage && ImageMember != null)
                {
                    var mimage = ImageMember(SelectedItem);
                    if(mimage != null)
                        e.Graphics.DrawImage(mimage, 
                                             new RectangleF(CurrentStyle.Padding.Left,
                                                            CurrentStyle.Padding.Top - 4,
                                                            Height - CurrentStyle.Padding.Right,
                                                            Height - CurrentStyle.Padding.Bottom));
                }

                e.Graphics.DrawString(Text.DefaultIfEmpty(Name),
                                      Font,
                                      Enabled
                                          ? _foreBrush ?? new SolidBrush(ForeColor)
                                          : new SolidBrush(WpThemeColors.DisableControl),
                                      new RectangleF(mtextDrawLeft,
                                                     CurrentStyle.Padding.Top - 4,
                                                     Width - CurrentStyle.Padding.Right,
                                                     Height - CurrentStyle.Padding.Bottom));
            }
            finally
            {
                base.OnPaint(e);
            }
        }

        #endregion

        #region Private methods

        private void InitStuff()
        {
            _items.CollectionChanged += ItemsOnCollectionChanged;
            CreateItems();
            Refresh();
        }

        private void ItemsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            CreateItems();
        }

        private void CreateItems()
        {
            if (ItemContainerIsOpen)
                CloseItemsContainer();

            if (frmItemsContainer != null && !frmItemsContainer.IsDisposed)
            {
                foreach (Control mcontrol in frmItemsContainer.Controls)
                    mcontrol.Dispose();

                frmItemsContainer.Controls.Clear();
                frmItemsContainer.Dispose();
            }

            frmItemsContainer = new WpPanel
            {
                MaximumSize = new Size(Width, MAX_ITEMS_CONTINER_HEIGHT),
                MinimumSize = new Size(Width, Height),
                AutoScroll = true,
                OwnStyle = true,
                Style = WpThemeReader.GetUiStyle(WpThemeConstants.WPSTYLE_DROPDOWN_LIST_BACK_PANEL),
                Visible = false
            };
            /*frmItemsContainer.Style.NormalStyle.BackColor = ItemStyle?.NormalStyle?.BackColor ?? Color.White;
            frmItemsContainer.Style.NormalStyle.BorderColor = */
            //frmItemsContainer.ApplyStyle();

            frmItemsContainer.Leave += (sender, args) => CloseItemsContainer();
            frmItemsContainer.MouseClickOutside += (sender, args) => CloseItemsContainer();

            if (ParentForm != null)
            {
                ParentForm.Deactivate += OnParentFormDezactivate;
                
                User32.SetParent(frmItemsContainer.Handle, ParentForm.Handle);
            }

            frmItemsContainer.Controls.AddRange(_items.Select(CreateItem).ToArray());
            
            frmItemsContainer.Height = frmItemsContainer.Controls.Cast<Control>().Sum(c => c.Height) + 6;
        }

        private Control CreateItem(T item, int index)
        {
            Control ml = CustomControl?.Invoke(item) ?? CreateDefaultControl(item);

            ml.TabIndex = index;
            if(CustomControl == null)
                ml.Click += (sender, args) => SelectItem((sender as WpLabel)?.TabIndex ?? 0);

            return ml;
        }

        private Control CreateDefaultControl(T item)
        {
            var mlbl = new WpLabel
            {
                Style = ItemStyle.Clone(),
                StyleType = StyleType.Normal,
                Text = DisplayMember?.Invoke(item) ?? item?.ToString() ?? string.Empty,
                Tag = ValueMember?.Invoke(item) ?? item,
                Dock = DockStyle.Top
            };

            if (ShowImage && ImageMember != null)
            {

                var mimg = ImageMember(item);
                if(mlbl.Style != null)
                {
                    if(mlbl.Style.NormalStyle != null)
                        mlbl.Style.NormalStyle.Padding = mlbl.Style.NormalStyle.Padding.SetPadding(Height, Direction.Left);
                    if (mlbl.Style.ClickStyle != null)
                        mlbl.Style.ClickStyle.Padding = mlbl.Style.ClickStyle.Padding.SetPadding(Height, Direction.Left);
                    if (mlbl.Style.HoverStyle != null)
                        mlbl.Style.HoverStyle.Padding = mlbl.Style.HoverStyle.Padding.SetPadding(Height, Direction.Left);
                    if (mlbl.Style.SelectedStyle != null)
                        mlbl.Style.SelectedStyle.Padding = mlbl.Style.SelectedStyle.Padding.SetPadding(Height, Direction.Left);
                    mlbl.ApplyStyle();
                }
                if (mimg != null)
                    mlbl.Paint += (sender, args) => args.Graphics.DrawImage(mimg, new RectangleF(0, 0, Height, Height));
            }

            return mlbl;
        }

        private void SelectItem(int index)
        {
            var moldIndex = _selectedIndex;
            _selectedIndex = index;
            Refresh();
            CloseItemsContainer();

            SelectedItemChanged?.Invoke(this, new SelectedItemChangeHandlerArgs
            {
                OldSelectedIndex = moldIndex,
                NewSelectedIndex = index
            });
        }

        #endregion
        
        #region Public methods

        public void CloseItemsContainer()
        {
            if (frmItemsContainer != null)
                frmItemsContainer.Visible = false;

            ParentForm?.Focus();
            ParentForm?.BringToFront();
        }

        public void OpenItemsContainer()
        {
            if (frmItemsContainer == null || frmItemsContainer.IsDisposed || frmItemsContainer.ParentForm == null)
                CreateItems();

            if (frmItemsContainer == null)
                return;
            frmItemsContainer.Location = ParentForm?.PointToClient(Parent.PointToScreen(Location)) ?? Point.Empty;

            foreach (WpLabel mlabel in frmItemsContainer.Controls.OfType<WpLabel>().OrderBy(l => l.TabIndex))
                frmItemsContainer.Controls.SetChildIndex(mlabel, Math.Max(frmItemsContainer.Controls.Count - 1 - mlabel.TabIndex, 0));

            var mc = frmItemsContainer.Controls.OfType<WpLabel>().FirstOrDefault(l => l.TabIndex == SelectedIndex);
            if (mc != null)
            {
                mc.SendToBack();
                frmItemsContainer.ScrollControlIntoView(mc);
            }

            frmItemsContainer.Visible = true;
            frmItemsContainer.BringToFront();
            
        }

        public void SetSelectedItem(Predicate<T> predicate)
        {
            if(predicate == null || Items == null)
                return;

            for (int midx = 0; midx < Items.Count; midx++)
                if(predicate(Items[midx]))
                {
                    SelectedIndex = midx;
                    return;
                }
        }

        #endregion

        #region Events

        private void OnParentFormDezactivate(object sender, EventArgs e)
        {
            CloseItemsContainer();
        }

        #endregion

    }

    public delegate void SelectedItemChangeHandler(object sender, SelectedItemChangeHandlerArgs args);
}
