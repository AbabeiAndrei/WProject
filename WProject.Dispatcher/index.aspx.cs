using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WProject.DataAccess;
using WProject.GenericLibrary.Helpers.Extensions;
using WProject.Library.Helpers.Utils.Db;

namespace WProject.Dispatcher
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblServer.Text = GetStatusText("Server");
            try
            {
                using (DatabaseFactory.NewDbWpContext)
                    lblMysql.Text = GetStatusText("MySql");
            }
            catch(Exception mex)
            {
                lblMysql.Text = GetStatusText("MySql", mex.Message);
            }
            if (Module.CenterConnection != null)
                lblSignalR.Text = GetStatusText("SignalR");
            else
                lblSignalR.Text = GetStatusText("SignalR", "Connection not created");
        }

        private static string GetStatusText(string element, string error = null)
        {
            return "<div class=\"item\">" +
                   "<div class=\"status "+ string.IsNullOrEmpty(error).If("green", "red") + "\"></div>" +
                   "<span class=\"status\">" + element + GetError(error) + "</span>" +
                   "</div>";
        }

        private static string GetError(string error)
        {
            return string.IsNullOrEmpty(error)
                       ? string.Empty
                       : " [" + error + "]";
        }
    }
}