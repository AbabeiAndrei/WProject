using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WProject.BusinessLibrary;
using WProject.Library.Helpers.Utils.Db;
using WProject.WebApiClasses.AjaxClasses;

namespace WProject
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var muc = Cache.Get(GenericLibrary.Constants.CacheConstants.USER_CACHE);
            if (muc != null)
                Server.Transfer("Dashboard.aspx");
            if (Page.IsPostBack)
            {
                User mu = null;
                try
                {
                    mu = DatabaseFactory.Login(txtEmail.Text, txtPass.Text);
                }
                catch
                {
                    
                }
                if(mu == null)
                    return;

                Cache.Insert(GenericLibrary.Constants.CacheConstants.USER_CACHE, mu.Id);
                Server.Transfer("Dashboard.aspx");
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static string ExecuteLogin(string email, string pass)
        {
            try
            {
                var mu = DatabaseFactory.Login(email, pass);
                return JsonConvert.SerializeObject(new AjaxLoginReponse
                {
                    Success = true
                });
            }
            catch (Exception mex)
            {
                return JsonConvert.SerializeObject(new AjaxLoginReponse
                {
                    Error = mex.Message,
                    Success = false
                });
            }
        }

        [System.Web.Services.WebMethod]
        public static string PasswordLost(string email)
        {
            try
            {
                if(Library.Helpers.Utils.Users.RecoverPassword(email))
                    return JsonConvert.SerializeObject(new AjaxRecoverPasswordReponse
                    {
                        Success = true,
                        Message = "A link was sent to " + email + "\nFollow the instruction from mail."
                    });
                throw new Exception("Email not found, please try again!");
            }
            catch (Exception mex)
            {
                return JsonConvert.SerializeObject(new AjaxRecoverPasswordReponse
                {
                    Error = mex.Message,
                    Success = false
                });
            }
        }
    }
}