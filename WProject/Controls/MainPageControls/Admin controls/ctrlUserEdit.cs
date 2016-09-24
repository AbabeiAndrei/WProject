using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.Connection;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.UiLibrary.Controls;
using WProject.WebApiClasses.Classes;
using Task = System.Threading.Tasks.Task;

namespace WProject.Controls.MainPageControls.Admin_controls
{
    public partial class ctrlUserEdit : WpUserControl
    {
        private User _user;

        public Func<User, Task> AfterSave { get; set; }

        public ctrlUserEdit()
        {
            InitializeComponent();

            AddToValidate(txtName, ValidateGuiMode.NotEmpty, "Name");
            AddToValidate(txtPass, ValidateGuiMode.NotEmpty, "Pass");
        }

        public ctrlUserEdit(User user) 
            : this()
        {
            _user = user;
        }

        private void ctrlUserEdit_Load(object sender, EventArgs e)
        {
            InitStuff();
        }

        private void InitStuff()
        {
            chkAdvanceSettings.Visible = _user != null && _user.Id != 0;
        }

        private void chkAdvanceSettings_OnCheckChanged(object sender, EventArgs e)
        {
            btnDelete.Visible = chkAdvanceSettings.Checked;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UIHelper.ShowConfirmWindow("You are about to delete user " + _user.Name + "!!",
                                       "To confirm following action please enter the name of the user below",
                                       _user.Name,
                                       () =>
                                       {
                                           _user.Deleted = true;
                                           btnSave.PerformClick(); 
                                       });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ParentForm?.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UIHelper.ShowLoader();

                var merr = ValidateGui();

                if (!string.IsNullOrEmpty(merr))
                {
                    UIHelper.ShowError(merr);
                    return;
                }

                _user.Name = txtName.Text;
                _user.Password = GenericLibrary.Helpers.Crypto.Hash.Md5(txtPass.Text);
                _user.Email = txtMail.Text;

                var mres = await WebCallFactory.SaveUser(_user);

                if (mres.Error)
                    throw mres.Exception;

                AfterSave?.Invoke(mres.User);
            }
            catch (Exception mex)
            {
                Logger.Log(mex);
                UIHelper.ShowError(mex);
            }
            finally
            {
                UIHelper.HideLoader();
            }
        }
    }
}
