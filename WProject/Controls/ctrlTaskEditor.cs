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
using WProject.Connection;
using WProject.GenericLibrary.Helpers.Extensions;
using WProject.GenericLibrary.Helpers.Log;
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
        private bool _fullScreen;
        private int _taskId;

        #endregion

        #region Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Task Task => GenerateTask();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Action<FullScreenEventArgs> OnFullScreen { get; set; }
        
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
        public Action OnPrintTask { get; set; }

        public override bool FullScreen
        {
            get
            {
                return base.FullScreen;
            }
            set
            {
                base.FullScreen = value;

                btnFullScreen.Image = FullScreen 
                                        ? Properties.Resources.fullscreen_exit_s
                                        : Properties.Resources.fullscreen_arrow_s;
            }
        }

        #endregion

        #region Constructors

        public ctrlTaskEditor()
        {
            InitializeComponent();
        }

        public ctrlTaskEditor(int taskId)
            : this()
        {
            _taskId = taskId;
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

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            txtName.LeftButton = btnCopy;

            await LoadTask();
        }

        private async System.Threading.Tasks.Task LoadTask()
        {
            if(_taskId == 0)
                return;

            try
            {
                var mres = await WebCallFactory.GetTask(_taskId);

                if (mres.Error)
                    throw mres.Exception;

                _task = mres.Task;
                SetTaskData();
            }
            catch (Exception mex)
            {
                Logger.Log(mex);
                UIHelper.ShowError(mex);
            }
        }

        #endregion

        #region Events

        private void wpButtonCopy_Click(object sender, EventArgs e)
        {
            if (_task != null)
                Clipboard.SetText(_task.FullName);
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            var mfsEveArgs = new FullScreenEventArgs();
            OnFullScreen?.Invoke(mfsEveArgs);

            if (mfsEveArgs.Handled)
                return;

            FullScreen = !FullScreen;
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
            OnPrintTask?.Invoke();
        }

        #endregion

        #region Private methods

        private void SetTaskData()
        {
            try
            {
                SuspendLayout();
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
            finally
            {
                ResumeLayout();
                Refresh();
            }

        }

        private Task GenerateTask()
        {
            //throw new NotImplementedException();

            return _task;
        }


        #endregion

    }
}
