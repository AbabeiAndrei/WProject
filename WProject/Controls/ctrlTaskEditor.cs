using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.Classes;
using WProject.GenericLibrary.Helpers.Extensions;
using WProject.Helpers;
using WProject.UiLibrary.Classes;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Theme;
using Task = WProject.WebApiClasses.Classes.Task;
using WProject.WebApiClasses.Classes;

namespace WProject.Controls 
{
    public partial class ctrlTaskEditor : WpUserControl
    {
        #region Fields

        private Task _task;

        #endregion

        #region Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Task Task
        {
            get
            {
                return _task;
            }
            set
            {
                _task = value;
                SetTaskData();
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Action OnFullScreen { get; set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Action OnClose { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Action<Task> OnSave { get; set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Action OnFollow { get; set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Action OnPrint { get; set; }

        #endregion

        #region Constructors

        public ctrlTaskEditor()
        {
            InitializeComponent();
        }

        public ctrlTaskEditor(Task task)
            : this()
        {
            _task = task;
            SetTaskData();
        }

        #endregion

        #region Overrides of WpStyledControl

        public override void ApplyStyle()
        {
            base.ApplyStyle();

            if (pnlLeftDock != null)
                pnlLeftDock.BackColor = WpThemeColors.Amber;
        }

        #endregion

        #region Overrides of WpUserControl

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            txtName.LeftButton = btnCopy;
        }

        #endregion

        #region Events

        private void wpButtonCopy_Click(object sender, EventArgs e)
        {
            if (_task != null)
                Clipboard.SetText(_task.FullName);
        }

        #endregion

        #region Private methods

        private void SetTaskData()
        {
            nudPriority.Value = Task.Priority ?? 1;
            txtLeft.Text = Task.RemainingWork.If(v => v.HasValue, v => v.GetValueOrDefault().ToString(), v => string.Empty);
            lblTask.Text = $"Task {Task.Id}";
            txtName.Text = Task.Name;
            txtDetails.Text = Task.Description;
            if (Task.Comments != null)
                ttComents.Messages = Task.Comments.Select(c => Convertors.Convert(c, c.UserId == WPSuite.ConnectedUserId)).ToList();

            if (Task.Discusion != null)
                ttDiscution.Messages = Task.Discusion.Select(c => Convertors.Convert(c, c.UserId == WPSuite.ConnectedUserId)).ToList();

            if (Task.Attachments != null)
                flAttachments.Files = Task.Attachments.Select(f => Convertors.Convert(f.File)).ToList();
        }

        #endregion

        #region Events

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            OnFullScreen?.Invoke();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnClose?.Invoke();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();

            OnClose?.Invoke();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnFollow_Click(object sender, EventArgs e)
        {
            OnFollow?.Invoke();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            OnPrint?.Invoke();
        }

        #endregion

    }
}
