using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WProject.DataAccess;
using WProject.GenericLibrary;
using WProject.GenericLibrary.Constants;
using WProject.GenericLibrary.Exceptions;
using WProject.Library.Helpers;
using WProject.Library.Helpers.Utils.Db;

namespace WProject
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Suite.SessionUser == null)
                try
                {
                    using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                    {
                        var muc = Cache.Get(GenericLibrary.Constants.CacheConstants.USER_CACHE);
                        if (muc == null)
                            throw new WpException(WpErrors.USER_NOT_LOGGED_IN);
                        int muid = (int)muc;
                        Suite.SessionUser = User.GetById(muid, mctx);
                        if (Suite.SessionUser == null)
                            throw new WpException(WpErrors.USER_NOT_FOUND);
                    }
                }
                catch
                {
                    Server.Transfer("Login.aspx");
                }
            userAvatar.AlternateText = Suite.SessionUser?.Name ?? string.Empty;
            userAvatar.ImageUrl = Suite.SessionUser?.Avatar?.Url ?? Constants.Defaults.Avatar;
        }
    }
}