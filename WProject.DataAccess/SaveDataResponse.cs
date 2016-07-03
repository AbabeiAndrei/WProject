using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.DataAccess
{
    public class SaveDataResponse
    {
        public bool Success { get; set; }
        public Exception Exception { get; set; }

        public SaveDataResponse()
        {
            Success = true;
        }

        public SaveDataResponse(Exception exception)
        {
            Success = false;
            Exception = exception;
        }
    }
}
