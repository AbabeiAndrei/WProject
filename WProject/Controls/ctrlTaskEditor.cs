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
using WProject.Controls.MainPageControls.Task_Editor_Controls;
using WProject.GenericLibrary.Constants;
using WProject.GenericLibrary.Helpers;
using WProject.GenericLibrary.Helpers.Extensions;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.UiLibrary.Classes;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Controls.SpecificControls;
using WProject.UiLibrary.Theme;
using Task = WProject.WebApiClasses.Classes.Task;
using WProject.WebApiClasses.Classes;
using WProject.WebApiClasses.Data;
using WProject.WebApiClasses.MessanginCenter;

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
        public Func<Task, System.Threading.Tasks.Task> OnSave { get; set; }
        
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

            AddToValidate(txtName, ValidateGuiMode.NotEmpty, "Task name");
        }

        public ctrlTaskEditor(int taskId)
            : this()
        {
            _taskId = taskId;
        }

        public ctrlTaskEditor(Task task)
            : this()
        {
            _taskId = task?.Id ?? 0;

            _task = task;
        }

        #endregion

        #region Overrides of WpStyledControl

        public override void ApplyStyle()
        {
            base.ApplyStyle();

            if (pnlLeftDock != null)
                pnlLeftDock.BackColor = WpThemeColors.Amber;

            if(btnCopy != null)
                ApplyStyleToAllButtons(this, btnCopy.Name);
        }

        #endregion

        #region Overrides of WpUserControl

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            txtName.LeftButton = btnCopy;

            LoadGeneral();
            await LoadTask();
        }

        private void LoadGeneral()
        {
            ddUser.Items = SimpleCache.GetAll<User>()
                                      .InsertAt(User.None)
                                      .ToList();
            ddUser.DisplayMember = user => user.Name;
            ddUser.ValueMember = user => user.Id;
            ddUser.ShowImage = true;
            ddUser.ImageMember = user => user.Avatar?.GetImage();

            ddState.Items = SimpleCache.GetAll<DictItem>().Where(di => di.Type == DictItem.Types.TaskState).ToList();
            ddState.DisplayMember = dict => dict.Name;
            ddState.ValueMember = dict => dict.Id;

            txtViewLink.LeftButton = btnCopyViewLink;
            txtEditLink.LeftButton = btnCopyEditLink;
            txtBasicViewLink.LeftButton = btnCopyBasicViewLink;
            txtDiscutionLink.LeftButton = btnCopyDiscutionLink;

            flAttachments.ShowCheckAll =
                flAttachments.ShowDeleteSelected =
                flAttachments.ShowNumberOfFiles =
                flAttachments.ShowSaveSelected =
                flAttachments.ShowUpload = true;
        }

        private async System.Threading.Tasks.Task LoadTask()
        {
            
            try
            {
                UIHelper.ShowLoader("LOAD TASK", ParentForm);

                if (_taskId == 0)
                {
                    if (ParentForm != null)
                        ParentForm.Text = "New task";
                }
                else
                {
                    if (ParentForm != null)
                        ParentForm.Text = $"Edit task {_taskId}";

                    var mres = await WebCallFactory.GetTask(_taskId);

                    if (mres.Error)
                        throw mres.Exception;

                    _task = mres.Task;
                }
                SetTaskData();
                UIHelper.HideLoader();
            }
            catch (Exception mex)
            {
                UIHelper.HideLoader();
                Logger.Log(mex);
                UIHelper.ShowError(mex);
            }
            finally
            {
                UIHelper.HideLoader();
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (await TaskSave() && OnSave != null)
                await OnSave(_task);
        }

        private async void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (await TaskSave())
                btnClose.PerformClick();
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

        private async void ttComents_OnSend(object sender, SendMessageEventArgs e)
        {
            var mt = sender as WpTextThread;

            if (mt == null)
                return;

            var mtc = new TaskComment
            {
                UserId = WPSuite.ConnectedUserId,
                TaskId = _taskId,
                Text = e.Text
            };

            try
            {
                Logger.Log($"Send commnet to dispatcher for task {_taskId}");
                var mres = await WebCallFactory.PostCommentOnTask(mtc);

                if (mres.Error)
                    throw mres.Exception;

                Logger.Log("Comment send with success!");

                mt.Messages.Add(Convertors.Convert(mres.TaskComment, true));
            }
            catch (Exception mex)
            {
                UIHelper.ShowError(mex);
                Logger.Log(mex);
            }
        }

        private async void flAttachments_OnFileUploaded(object sender, FileItemEventArgs args)
        {
            var mt = sender as WpFileLoader;

            if (mt == null)
                return;

            var mf = System.IO.File.ReadAllBytes(args.FileItem.FilePath);

            var mtc = new TaskAttachement
            {
                TaskId = _taskId,
                AttachedBy = WPSuite.ConnectedUserId,
                File = new File
                {
                    Size = args.FileItem.Size,
                    Name = args.FileItem.Name,
                    CreatedById = WPSuite.ConnectedUserId,
                    Extension = args.FileItem.Extension,
                    Content = mf
                }
            };

            try
            {
                Logger.Log($"Send file to dispatcher for task {_taskId}");
                var mres = await WebCallFactory.AttachFileToTask(mtc);

                if (mres.Error)
                    throw mres.Exception;

                Logger.Log("File send with success!");

                mt.Files.Add(Convertors.Convert(mres.TaskAttachement.File));
            }
            catch (Exception mex)
            {
                UIHelper.ShowError(mex);
                Logger.Log(mex);
            }
        }

        private void btnCopyViewLink_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtViewLink.Text);
        }

        private void btnCopyEditLink_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtEditLink.Text);
        }

        private void btnCopyBasicViewLink_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtBasicViewLink.Text);
        }

        private void btnCopyDiscutionLink_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtDiscutionLink.Text);
        }

        private void chkView_OnCheckChanged(object sender, EventArgs e)
        {
            txtViewLink.Enabled = chkView.Checked;
        }

        private void chkEdit_OnCheckChanged(object sender, EventArgs e)
        {
            txtEditLink.Enabled = chkEdit.Checked;
        }

        private void chkBasicView_OnCheckChanged(object sender, EventArgs e)
        {
            txtBasicViewLink.Enabled = chkBasicView.Checked;
        }

        private void chkDiscution_OnCheckChanged(object sender, EventArgs e)
        {
            txtDiscutionLink.Enabled = chkDiscution.Checked;
        }

        private void btnViewGenerate_Click(object sender, EventArgs e)
        {
            //todo
            txtViewLink.Text = Connection.Connection.WebUrl + "/" + Guid.NewGuid().ToString("N");
        }

        private void btnEditGenerate_Click(object sender, EventArgs e)
        {
            //todo
            txtEditLink.Text = Connection.Connection.WebUrl + "/" + Guid.NewGuid().ToString("N");
        }

        private void btnBasicViewGenerate_Click(object sender, EventArgs e)
        {
            //todo
            txtBasicViewLink.Text = Connection.Connection.WebUrl + "/" + Guid.NewGuid().ToString("N");
        }

        private void btnDiscutionGenerate_Click(object sender, EventArgs e)
        {
            //todo
            txtDiscutionLink.Text = Connection.Connection.WebUrl + "/" + Guid.NewGuid().ToString("N");
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
                lblTask.Text = Task.Id != 0 
                                    ? $"Task {Task.Id}"
                                    : "New task";
                txtName.Text = Task.Name;
                txtDetails.Text = Task.Description;

                if (Task.Comments != null)
                    ttComents.Messages = Task.Comments.Select(c => Convertors.Convert(c, c.UserId == WPSuite.ConnectedUserId)).ToList();

                if (Task.Discusion != null)
                    ttDiscution.Messages = Task.Discusion.Select(c => Convertors.Convert(c, c.UserId == WPSuite.ConnectedUserId)).ToList();

                if (Task.Attachments != null)
                    flAttachments.Files = Task.Attachments.Select(f => Convertors.Convert(f.File)).ToList();

                if(Task.Changes != null)
                    tpHistory.Controls.AddRange(Task.Changes.GroupBy(tc => tc.ChangeStamp).Select(CreateTaskChangeControl).ToArray());

                if(Task.AssignedToId.HasValue)
                    ddUser.SetSelectedItem(u => u.Id == Task.AssignedToId);

                ddState.SetSelectedItem(di => di.Id == Task.StateId);
            }
            finally
            {
                ResumeLayout();
                Refresh();
            }

        }

        private static Control CreateTaskChangeControl(IEnumerable<TaskHistory> th)
        {
            return new ctrlTaskHistoryItem(th)
            {
                Dock = DockStyle.Top
            };
        }

        private Task GenerateTask()
        {
            //throw new NotImplementedException();

            return _task;
        }
        
        private void MakeBindingsToEntity()
        {
            Task.Name = txtName.Text;
            Task.StateId = ddState.SelectedItem.Id;

            var mownedBy = ddUser.SelectedItem?.Id ?? 0;
            Task.AssignedToId = mownedBy != 0
                                    ? mownedBy
                                    : (int?) null;

            Task.Priority = nudPriority.Value != 0
                                ? (int)nudPriority.Value
                                : (int?) null;

            Task.RemainingWork = Utils.TryIntParse(txtLeft.Text, null);

            Task.Description = txtDetails.Text;
            Task.UpdatedById = WPSuite.ConnectedUserId;
        }

        private async Task<bool> TaskSave()
        {
            try
            {
                UIHelper.ShowLoader("Save task");

                var mvalid = ValidateGui();
                if (!string.IsNullOrEmpty(mvalid))
                {
                    UIHelper.ShowError(mvalid);
                    return false;
                }

                MakeBindingsToEntity();

                var mres = await WebCallFactory.SaveTask(Task);

                if (mres.Error)
                {
                    Logger.Log(mres.Exception);
                    UIHelper.ShowError(mres.Exception);
                    return false;
                }

                Logger.Log("Task saved");

                _task = mres.Task;
                SetTaskData();

                UIHelper.HideLoader();
                return true;
            }
            catch (Exception mex)
            {
                Logger.Log(mex);
                UIHelper.HideLoader();
                UIHelper.ShowError(mex);
                return false;
            }
            finally
            {
                UIHelper.HideLoader();
            }
        }

        #endregion

    }
}
