using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WProject.BusinessLibrary;
using WProject.GenericLibrary;
using WProject.GenericLibrary.Exceptions;
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
                    var muc = Cache.Get(GenericLibrary.Constants.CacheConstants.USER_CACHE);
                    if (muc == null)
                        throw new WpException(WpErrors.USER_NOT_LOGGED_IN);
                    int muid = (int)muc;
                    LoggedUser = BusinessLibrary.User.GetById(muid, mctx);
                    if(LoggedUser == null)
                        throw  new WpException(WpErrors.USER_NOT_FOUND);

                    lblName.Text = "Welcome " + LoggedUser.Name;
                }
            }
            catch
            {
                Server.Transfer("Login.aspx");
            }
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Cache.Remove(GenericLibrary.Constants.CacheConstants.USER_CACHE);
            Server.Transfer("Login.aspx");
        }
    }
}