using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WProject.DataAccess;
using WProject.GenericLibrary.Exceptions;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Library.Helpers.Utils.Db;

namespace WProject.Library.Helpers.Log
{
    public static class DbLog
    {
        public static void Log(string log)
        {
            using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                Log(LogEntryType.Unknow, LogActionType.Unknow, log, string.Empty, mctx);
        }

        public static void Log(string log, wpContext context)
        {
            Log(LogEntryType.Unknow, LogActionType.Unknow, log, string.Empty, context);
        }

        public static void Log(Exception exception)
        {
            using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                Log(LogEntryType.Exception,
                    LogActionType.Unknow,
                    exception.Message,
                    JsonConvert.SerializeObject(exception),
                    mctx);
        }

        public static void Log(Exception exception, wpContext context)
        {
            Log(LogEntryType.Exception,
                LogActionType.Unknow,
                exception.Message,
                JsonConvert.SerializeObject(exception),
                context);
        }

        public static void Log(WpException exception)
        {
            using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                Log(LogEntryType.InternalException,
                    LogActionType.Unknow,
                    exception.Message,
                    JsonConvert.SerializeObject(exception),
                    mctx);
        }

        public static void Log(WpException exception, wpContext context)
        {
            Log(LogEntryType.Exception,
                LogActionType.Unknow,
                exception.Message,
                JsonConvert.SerializeObject(exception),
                context);
        }

        public static void Log(LogEntryType type, LogActionType action, string log)
        {
            using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                Log(type, action, log, string.Empty, mctx);
        }

        public static void Log(LogEntryType type, LogActionType action, string log, wpContext context)
        {
            Log(type, action, log, string.Empty, context);
        }

        public static void Log(LogEntryType type, LogActionType action, string log, string metadata)
        {
            using (wpContext mctx = DatabaseFactory.NewDbWpContext)
                Log(type, action, log, metadata, mctx);

        }

        public static void Log(LogEntryType type, LogActionType action, string log, string metadata, wpContext context)
        {
            try
            {
                context.Add(new DataAccess.Log
                {
                    
                });
            }
            catch (Exception mex)
            {//todo
                Console.WriteLine(mex);
            }
        }
    }
}
