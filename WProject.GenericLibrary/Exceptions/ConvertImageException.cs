using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.GenericLibrary.Exceptions
{
    public class ConvertImageException : Exception
    {
        public ConvertImageException()
        {
        }

        public ConvertImageException(string message) : base(message)
        {
        }

        public ConvertImageException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
