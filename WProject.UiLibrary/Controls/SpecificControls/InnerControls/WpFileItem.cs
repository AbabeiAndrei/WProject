using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WProject.UiLibrary.Classes;
using WProject.UiLibrary.Helpers;
using WProject.UiLibrary.Properties;
using WProject.UiLibrary.Theme;
using Utils = WProject.GenericLibrary.Helpers.Utils;

namespace WProject.UiLibrary.Controls.SpecificControls.InnerControls
{
    public partial class WpFileItem : WpUserControl
    {
        #region Fields

        private FileItem _file;

        #endregion

        #region Properties

        [DefaultValue(true)]
        [Category("Appearance")]
        public virtual bool ShowSave
        {
            get
            {
                return btnSave.Visible;
            }
            set
            {
                btnSave.Visible = value;
            }
        }

        [DefaultValue(true)]
        [Category("Appearance")]
        public virtual bool ShowDelete
        {
            get
            {
                return btnDelete.Visible;
            }
            set
            {
                btnDelete.Visible = value;
            }
        }

        [DefaultValue(true)]
        [Category("Appearance")]
        public virtual bool ShowCheck
        {
            get
            {
                return chkChecked.Visible;
            }
            set
            {
                chkChecked.Visible = value;
            }
        }

        [DefaultValue(true)]
        [Category("Appearance")]
        public virtual bool Checked
        {
            get
            {
                return chkChecked.Checked;
            }
            set
            {
                chkChecked.Checked = value;
            }
        }

        [Category("Data")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual FileItem File
        {
            get
            {
                return _file;
            }
            set
            {
                _file = value;
                SetFile();
            }
        }

        [Category("Internals")]
        public event EventHandler OnSaveClick;

        [Category("Internals")]
        public event EventHandler OnInfoClick;

        [Category("Internals")]
        public event EventHandler OnDeleteClick;

        [Category("Internals")]
        public event EventHandler OnCheckChanged;

        #endregion

        #region Constructors

        public WpFileItem()
        {
            InitializeComponent();
        }

        public WpFileItem(FileItem file)
            : this()
        {
            _file = file;
            SetFile();
        }

        #endregion

        #region Overrides of WpStyledControl

        public override void ApplyStyle()
        {
            base.ApplyStyle();

            if (btnSave != null && btnDelete != null && btnInfo != null)
                btnSave.BackColor =
                    btnDelete.BackColor =
                    btnInfo.BackColor = WpThemeColors.Blue;

            Margin = Margin.SetPadding(10, Direction.Down);

            OwnStyle = true;
        }

        #endregion

        #region Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSaveClick?.Invoke(this, EventArgs.Empty);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            OnInfoClick?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OnDeleteClick?.Invoke(this, EventArgs.Empty);
        }

        private void chkChecked_OnCheckChanged(object sender, EventArgs e)
        {
            OnCheckChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Private methods

        private void SetFile()
        {
            lblName.Text = File?.FullName ?? string.Empty;
            lblSize.Text = Utils.FormatToSize(File?.Size ?? 0);
            lblCreatedBy.Text = "Uploaded by : " + (File?.CreatedBy ?? string.Empty);
            pbIcon.Image = File?.Icon ?? Resources.default_file_icon;
        }

        #endregion

    }
}
