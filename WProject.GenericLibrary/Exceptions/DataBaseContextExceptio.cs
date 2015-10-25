using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.GenericLibrary.Exceptions
{
    public class DataBaseContextException : Exception
    {
        public int Number { get; set; }
        
        public DataBaseContextException(int number) 
            : this(number, string.Empty)
        {
        }

        public DataBaseContextException(int number, string message) 
            : this(number, message, null)
        {
        }

        public DataBaseContextException(int number, string message, Exception innerException) 
            : base(message, innerException)
        {
            Number = number;
        }
    }
}
