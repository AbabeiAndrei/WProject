using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.GenericLibrary.Exceptions;

namespace WProject.GenericLibrary.Helpers.Log
{
    public static class DiagnosticLogger
    {
        public static void Log(string log)
        {
            WriteLog(log);
        }

        public static void Log(Exception exception)
        {
            WriteLog($"Exception : {exception.Message}\n" +
                     $"StackTrace : {exception.StackTrace}\n");
        }

        public static void Log(WpException exception)
        {
            WriteLog($"Error code : {exception.ErrorCode}\n" +
                     $"Exception : {exception.Message}\n" +
                     $"StackTrace : {exception.StackTrace}\n");
        }

        public static void Log(LogEntryType type, LogActionType action, string log)
        {
            WriteLog($"LogEntryType: {type}\n" +
                     $"LogActionType : {action}\n" +
                     $"Log : {log}\n");
        }

        public static void Log(LogEntryType type, LogActionType action, string log, string metadata)
        {
            WriteLog($"LogEntryType: {type}\n" +
                     $"LogActionType : {action}\n" +
                     $"Log : {log}\n" +
                     $"Metadata : {metadata}");
        }

        private static void WriteLog(string text)
        {
            System.Diagnostics.Debug.WriteLine($"LOG [{DateTime.Now.ToString("G")}] > {text}");
        }
    }
}
