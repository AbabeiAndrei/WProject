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
using WProject.WebApiClasses.Classes;
using WProject.WebApiClasses.Data;
using Task = System.Threading.Tasks.Task;

namespace WProject.Controls
{
    public partial class ctrlBacklogEditor : WpUserControl
    {
        #region Fields
        
        private Backlog _backlog;

        #endregion

        #region Properties
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Func<Backlog, Task> OnSave { get; set; }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Action OnClose { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Action<FullScreenEventArgs> OnFullScreen { get; set; }
        
        public override bool FullScreen
        {
            get
            {
                return base.FullScreen;
            }
            set
            {
                base.FullScreen = value;

                btnMaximize.Image = FullScreen
                                        ? Properties.Resources.fullscreen_exit_s
                                        : Properties.Resources.fullscreen_arrow_s;
            }
        }

        public Backlog Backlog => _backlog;

        #endregion

        #region Constructors

        public ctrlBacklogEditor()
        {
            InitializeComponent();

            AddToValidate(txtName, ValidateGuiMode.NotEmpty, "Backlog name");
        }

        public ctrlBacklogEditor(Backlog backlog)
            : this()
        {
            SetBacklog(backlog);
        }

        #endregion

        #region Overrides of WpStyledControl

        public override void ApplyStyle()
        {
            base.ApplyStyle();

            if (btnCopy != null)
                ApplyStyleToAllButtons(this, btnCopy.Name);

            UIHelper.SetStylForDropDowns(ddUser, ddState);
        }

        #endregion

        #region Overrides of WpUserControl

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadGeneral();
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

            ddState.Items = SimpleCache.GetAll<DictItem>().Where(di => di.Type == DictItem.Types.BacklogState).ToList();
            ddState.DisplayMember = dict => dict.Name;
            ddState.ValueMember = dict => dict.Id;

            txtName.LeftButton = btnCopy;
        }

        #endregion

        #region Events handlers

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnFavorite_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnUndo_Click(object sender, EventArgs e)
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (await BacklogSave() && OnSave != null)
                await OnSave(_backlog);
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            var mfsEveArgs = new FullScreenEventArgs();
            OnFullScreen?.Invoke(mfsEveArgs);

            if (mfsEveArgs.Handled)
                return;

            FullScreen = !FullScreen;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ParentForm?.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (_backlog != null)
                Clipboard.SetText(_backlog.FullName);
        }

        #endregion

        #region Private methods

        private void SetBacklogData()
        {
            if(_backlog == null)
                return;

            if(ParentForm != null)
                ParentForm.Text = _backlog.Id != 0 
                                    ? $"Edit backlog {_backlog.Id}" 
                                    : "Create new backlog";

            lblBacklogId.Text = _backlog.Id != 0
                                    ? $"Backlog {_backlog.Id}"
                                    : "Create backlog";

            txtName.Text = _backlog.Name;
            txtDesc.Text = _backlog.Description;

            if(_backlog.AssignedToId.HasValue)
                ddUser.SetSelectedItem(u => u.Id == _backlog.AssignedToId.Value);

            ddState.SetSelectedItem(di => di.Id == _backlog.StateId);
        }
        
        private void MakeBindingsToEntity()
        {
            Backlog.Name = txtName.Text;
            Backlog.StateId = ddState.SelectedItem.Id;

            var mownedBy = ddUser.SelectedItem?.Id ?? 0;
            Backlog.AssignedToId = mownedBy != 0
                                    ? mownedBy
                                    : (int?)null;
            /*
            Backlog.Priority = nudPriority.Value != 0
                                ? (int)nudPriority.Value
                                : (int?)null;*/

            //Backlog.RemainingWork = Utils.TryIntParse(txtLeft.Text, null);

            Backlog.Description = txtDesc.Text;
            //Backlog.UpdatedById = WPSuite.ConnectedUserId;
        }

        private async Task<bool> BacklogSave()
        {
            try
            {
                UIHelper.ShowLoader("Save backlog");

                var mvalid = ValidateGui();
                if (!string.IsNullOrEmpty(mvalid))
                {
                    UIHelper.ShowError(mvalid);
                    return false;
                }

                MakeBindingsToEntity();

                var mres = await WebCallFactory.SaveBacklog(Backlog);

                if (mres.Error)
                {
                    Logger.Log(mres.Exception);
                    UIHelper.ShowError(mres.Exception);
                    return false;
                }

                Logger.Log("Task saved");

                _backlog = mres.Backlog;
                SetBacklogData();

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

        #region Public methods

        public void SetBacklog(Backlog backlog)
        {
            _backlog = backlog;
            SetBacklogData();
        }

        #endregion

    }
}
