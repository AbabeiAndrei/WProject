using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Microsoft.Owin.Builder;

namespace WProject.Dispatcher
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public WebApiApplication()
        {
            
        }

        #region Overrides of HttpApplication

        public override void Init()
        {
            base.Init();
        }

        #endregion

        protected void Application_Start()
        {
            Module.InitConnection();
        }

        protected void Application_End()
        {
            Module.CloseConnection();
        }
    }
}
