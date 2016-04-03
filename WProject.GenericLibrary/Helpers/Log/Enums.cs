using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.GenericLibrary.Helpers.Log
{

    public enum LogEntryType : short
    {
        Info,
        Alert,
        Warning,
        Error,
        InternalException,
        Exception,
        Audit,
        Other,
        Unknow
    }

    public enum LogActionType
    {
        Read,
        Create,
        Update,
        Delete,
        Execute,
        Audit,
        Call,
        Other,
        Unknow
    }
}
