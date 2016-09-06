using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.WebApiClasses.MessanginCenter
{
    public interface IResponse
    {
        string Content { get; }
        int ErrorCode { get; }
        string Error { get; }
    }
}
