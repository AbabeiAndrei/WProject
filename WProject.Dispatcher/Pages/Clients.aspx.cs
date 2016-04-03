using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WProject.Dispatcher.Connection;

namespace WProject.Dispatcher.Pages
{
    public partial class Clients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                SetClients();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            SetClients();
        }

        private void SetClients()
        {
            var ml = MessagingCenter.WpClients
                                    .Select(c => $"{c.Name} - {c.ConnectionId} - {c.Ip}")
                                    .ToList();

            txtConnections.Text = string.Join("\n", ml);

            lblConections.Text = "Number of active connections : " + ml.Count;
        }

        protected void btnClean_Click(object sender, EventArgs e)
        {
            MessagingCenter.ClearClients();
            SetClients();
        }
    }
}