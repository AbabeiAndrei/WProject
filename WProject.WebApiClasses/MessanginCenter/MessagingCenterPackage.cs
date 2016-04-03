using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WProject.WebApiClasses.MessanginCenter
{
    public class MessagingCenterPackage
    {
        public string Method { get; set; }

        public string Content { get; set; }

        public MessagingAddress FromAddress { get; set; }
    }
}