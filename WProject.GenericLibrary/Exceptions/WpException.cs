using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WProject.GenericLibrary.Exceptions
{
    public class WpException : Exception
    {
        public int ErrorCode { get; protected set; }
        public string Metadata { get; set; }

        public WpException()
        {
        }

        public WpException(int errorCode)
        {
            ErrorCode = errorCode;
        }

        public WpException(string message) : base(message)
        {
        }

        public WpException(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public WpException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public WpException(int errorCode, string message, Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        protected WpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
