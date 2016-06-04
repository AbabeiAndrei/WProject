using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace WProject.Connection
{
    public class WebService : IDisposable
    {
        public const int DEFAULT_TIMEOUT = 5000;

        public string Url { get; set; }
        public int TimeOut { get; set; }

        public WebService()
        {
            Url = string.Empty;
            TimeOut = DEFAULT_TIMEOUT;
        }

        public WebService(string url)
            : this()
        {
            Url = url;
        }

        /*public async Task<string> InvokeAsync(string method, params object[] parameters)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("Pages/InteropService/Process");

                // HTTP POST
                var gizmo = new Product() { Name = "Gizmo", Price = 100, Category = "Widget" };
                response = await client.PostAsync("api/products", gizmo);
                if (response.IsSuccessStatusCode)
                {
                    Uri gizmoUrl = response.Headers.Location;

                    // HTTP PUT
                    gizmo.Price = 80;   // Update price
                    response = await client.PutAsJsonAsync(gizmoUrl, gizmo);

                    // HTTP DELETE
                    response = await client.DeleteAsync(gizmoUrl);
                }
            }
        }
        */
        #region Implementation of IDisposable

        public void Dispose()
        {
            
        }

        #endregion
    }
}
