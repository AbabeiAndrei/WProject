using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.WebApiClasses.AjaxClasses
{
    public class AjaxLoginReponse
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public int TimeError { get; set; }

        public AjaxLoginReponse()
        {
            //Default time out for error message
            TimeError = 3000;
        }
    }
}
