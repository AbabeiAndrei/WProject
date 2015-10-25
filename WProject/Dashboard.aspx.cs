using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WProject.BusinessLibrary;
using WProject.Library.Helpers.Utils.Db;

namespace WProject
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private User LoggedUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (WModel mctx = DatabaseFactory.NewDbWpContext)
                {
                    int muid = (int)Page.Session["user_id"];
                    LoggedUser = BusinessLibrary.User.GetById(muid, mctx);
                    if(LoggedUser == null)
                        throw  new Exception("USE NOT FOUND");

                    lblName.Text = "Welcome " + LoggedUser.Name;
                }
            }
            catch (Exception mexception)
            {
                lblName.Text = mexception.Message;
            }
            ;
        }
    }
}