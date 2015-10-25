using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}