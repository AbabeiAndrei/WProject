using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.GenericLibrary.Helpers;
using WProject.UiLibrary.Classes;
using WProject.UiLibrary.Controls.SpecificControls.InnerControls;
using WProject.UiLibrary.Theme;

namespace WProject.UiLibrary.Controls.SpecificControls
{
    public partial class WpFileLoader : WpUserControl
    {
        #region Fields

        private bool _canCheckItems;
        private bool _canSaveItem;
        private bool _canDeleteItem;
        private ObservableCollection<FileItem> _files;

        #endregion

        #region Properties

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowNumberOfFiles
        {
            get
            {
                return lblCount?.Visible ?? true;
            }
            set
            {
                if (lblCount != null)
                    lblCount.Visible = value;
            }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowCheckAll
        {
            get
            {
                return btnSelectAll?.Visible ?? true;
            }
            set
            {
                if (btnSelectAll != null)
                    btnSelectAll.Visible = value;
            }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowDeleteSelected
        {
            get
            {
                return btnDeleteAll?.Visible ?? true;
            }
            set
            {
                if (btnDeleteAll != null)
                    btnDeleteAll.Visible = value;
            }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowSaveSelected
        {
            get
            {
                return btnSaveAll?.Visible ?? true;
            }
            set
            {
                if (btnSaveAll != null)
                    btnSaveAll.Visible = value;
            }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowUpload
        {
            get
            {
                return btnUpload?.Visible ?? true;
            }
            set
            {
                if (btnUpload != null)
                    btnUpload.Visible = value;
            }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool CanCheckItems
        {
            get
            {
                return _canCheckItems;
            }
            set
            {
                _canCheckItems = value;
                SetItemsData();
            }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool CanSaveItem
        {
            get
            {
                return _canSaveItem;
            }
            set
            {
                _canSaveItem = value;
                SetItemsData();
            }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool CanDeleteItem
        {
            get
            {
                return _canDeleteItem;
            }
            set
            {
                _canDeleteItem = value;
                SetItemsData();
            }
        }

        [Category("Behavior")]
        [DefaultValue(false)]
        public bool CustomUploader { get; set; }

        [Category("Behavior")]
        [DefaultValue("")]
        public string FileDialogFiltre
        {
            get
            {
                return fdUpload?.Filter ?? string.Empty;
            }
            set
            {
                if (fdUpload != null)
                    fdUpload.Filter = value;
            }
        }

        [Category("Data")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<FileItem> Files
        {
            get
            {
                return _files;
            }
            set
            {
                if (value == null)
                    _files = null;
                else
                {
                    _files = new ObservableCollection<FileItem>(value);
                    _files.CollectionChanged += FilesOnCollectionChanged;
                }
                SetItems();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<FileItem> SelectedFiles => SelectedItems.Select(wp => wp.File);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<WpFileItem> Items => pnlFiles.Controls.OfType<WpFileItem>();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<WpFileItem> SelectedItems => pnlFiles.Controls.OfType<WpFileItem>().Where(wp => wp.Checked);

        [Category("Items")]
        public event WpFileItemEventHandler OnCheckItem;

        [Category("Items")]
        public event WpFileItemEventHandler OnSaveItem;

        [Category("Items")]
        public event WpFileItemEventHandler OnInfoItem;

        [Category("Items")]
        public event WpFileItemEventHandler OnDeleteItem;

        [Category("Action")]
        public event EventHandler OnCheckAll;

        [Category("Action")]
        public event EventHandler OnDeleteAll;

        [Category("Action")]
        public event EventHandler OnSaveAll;

        [Category("Action")]
        public event EventHandler OnUpload;

        [Category("Action")]
        public event FileItemEventHandler OnFileUploaded;

        #endregion

        #region Constructors

        public WpFileLoader()
        {
            InitializeComponent();

            _canCheckItems = true;
            _canSaveItem = true;
            _canDeleteItem = true;

            _files = new ObservableCollection<FileItem>();
            _files.CollectionChanged += FilesOnCollectionChanged;
        }

        public WpFileLoader(IEnumerable<FileItem> files)
            : this()
        {
            if (files == null)
                return;

            _files = new ObservableCollection<FileItem>(files);
            _files.CollectionChanged += FilesOnCollectionChanged;

            SetItems();
        }

        #endregion

        #region Overrides of WpStyledControl

        public override void ApplyStyle()
        {
            base.ApplyStyle();

            if (btnSelectAll != null && btnDeleteAll != null && btnSaveAll != null && btnUpload != null)
                btnSelectAll.BackColor =
                    btnDeleteAll.BackColor =
                    btnSaveAll.BackColor =
                    btnUpload.BackColor = WpThemeColors.Blue;
        }

        #endregion

        #region Events

        private void FilesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    pnlFiles.Controls.AddRange(e.NewItems.OfType<FileItem>().Select(CreateWpFileItemControl).ToArray());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (FileItem mitem in e.OldItems.OfType<FileItem>())
                    {
                        var mc = Items.FirstOrDefault(i => i.File.Equals(mitem));

                        if (mc != null)
                            pnlFiles.Controls.Remove(mc);
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    ClearItems();
                    break;
                default:
                    SetItems();
                    return;
            }

            SetLabelInfo();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            var mallChecked = Items.All(wfi => wfi.Checked);

            foreach (WpFileItem mitem in Items)
                mitem.Checked = !mallChecked;

            OnCheckAll?.Invoke(this, EventArgs.Empty);
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            OnDeleteAll?.Invoke(this, EventArgs.Empty);
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            OnSaveAll?.Invoke(this, EventArgs.Empty);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OnUpload?.Invoke(this, EventArgs.Empty);

            if (CustomUploader)
                return;

            if (ParentForm != null)
                fdUpload.ShowDialog(ParentForm);
            else
                fdUpload.ShowDialog();
        }

        private void fdUpload_FileOk(object sender, CancelEventArgs e)
        {
            var mfile = new FileItem(fdUpload.FileName);

            OnFileUploaded?.Invoke(this, mfile);
        }

        private void lblCount_VisibleChanged(object sender, EventArgs e)
        {
            if (!DesignMode)
                SetLabelInfo();
        }

        #endregion

        #region Private methods

        private void SetItemsData()
        {
            foreach (WpFileItem mitem in pnlFiles.Controls.OfType<WpFileItem>())
            {
                if (mitem.ShowCheck != CanCheckItems)
                    mitem.ShowCheck = CanCheckItems;

                if (mitem.ShowSave != CanSaveItem)
                    mitem.ShowSave = CanSaveItem;

                if (mitem.ShowDelete != CanDeleteItem)
                    mitem.ShowDelete = CanDeleteItem;
            }
        }

        private void SetItems()
        {
            ClearItems();

            if (Files == null)
                return;

            pnlFiles.Controls.AddRange(Files.Select(CreateWpFileItemControl).ToArray());

            SetLabelInfo();
        }

        private Control CreateWpFileItemControl(FileItem file)
        {
            WpFileItem mc = new WpFileItem(file)
            {
                Dock = DockStyle.Top
            };

            mc.OnCheckChanged += (sender, args) =>
            {
                SetLabelInfo();
                OnCheckItem?.Invoke(sender, sender as WpFileItem);
            };
            mc.OnSaveClick += (sender, args) => OnSaveItem?.Invoke(sender, sender as WpFileItem);
            mc.OnInfoClick += (sender, args) => OnInfoItem?.Invoke(sender, sender as WpFileItem);
            mc.OnDeleteClick += (sender, args) => OnDeleteItem?.Invoke(sender, sender as WpFileItem);

            return mc;
        }

        private void ClearItems(bool dispose = true)
        {
            if (dispose)
                foreach (IDisposable mdisposable in pnlFiles.Controls.OfType<IDisposable>())
                    mdisposable.Dispose();

            pnlFiles.Controls.Clear();
        }

        private void SetLabelInfo()
        {
            const string ZERO_BITES = "0 b";

            if (!lblCount.Visible)
                return;

            var msitems = SelectedFiles.ToList();
            var mscount = msitems.Count;
            string msstring = string.Empty;
            string mssizestring = string.Empty;

            if (mscount > 0)
            {
                msstring = mscount + "/";
                try
                {
                    if (DesignMode)
                        mssizestring = ZERO_BITES;
                    else
                        mssizestring = Utils.FormatToSize(msitems.Select(fi => fi.Size).DefaultIfEmpty(0).Sum()) + "/";
                }
                catch
                {
                    mssizestring = ZERO_BITES;
                }
            }

            string mfiles = "files";
            string mfsize;

            try
            {
                if (DesignMode)
                    mfsize = ZERO_BITES;
                else
                    mfsize = Utils.FormatToSize(Files.Select(fi => fi.Size).DefaultIfEmpty(0).Sum());
            }
            catch (Exception)
            {
                mfsize = ZERO_BITES;
            }

            int mcount = Files.Count;

            if (mcount == 1)
                mfiles = "file";

            lblCount.Text = $"{msstring}{mcount} {mfiles} ({mssizestring}{mfsize})";
        }

        #endregion

        #region Public methods

        public void ScrollToBottom()
        {
            pnlFiles.ScrollToBottom();
        }

        #endregion
    }
}
