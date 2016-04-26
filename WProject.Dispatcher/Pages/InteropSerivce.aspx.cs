using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WProject.Dispatcher.Connection;
using WProject.WebApiClasses.MessanginCenter;

namespace WProject.Dispatcher.Pages
{
    public partial class InteropSerivce : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static MessagingCenterResponse Process(MessagingCenterPackage package)
        {
            return Module.CenterConnection.CallServiceMethod(package);
        }
    }
}