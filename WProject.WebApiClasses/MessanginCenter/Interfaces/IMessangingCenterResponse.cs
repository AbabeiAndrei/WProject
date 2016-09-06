using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.WebApiClasses.MessanginCenter
{
    public interface IMessangingCenterResponse
    {
        Exception Exception { get; set; }

        bool Error { get; set; }
    }
}
