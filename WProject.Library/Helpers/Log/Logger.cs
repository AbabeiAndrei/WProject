using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.GenericLibrary.Exceptions;
using WProject.GenericLibrary.Helpers.Log;

namespace WProject.Library.Helpers.Log
{
    public static class Logger
    {
        public static bool WriteInConsole { get; set; }
        public static bool WriteInDb { get; set; }
        public static bool WriteInFile { get; set; }
        public static bool WriteInDiagnostics { get; set; }
        public static string LogFilePath { get; set; }

        static Logger()
        {
            WriteInConsole = true;
            WriteInDb = true;
            WriteInFile = false;
            LogFilePath = string.Empty;
        }

        public static void Log(string log)
        {
            if(WriteInConsole)
                ConsoleLogger.Log(log);
            if (WriteInDiagnostics)
                DiagnosticLogger.Log(log);
            if (WriteInDb)
                DbLog.Log(log);
            if (WriteInFile)
                FileLogger.Log(log, LogFilePath);
        }

        public static void Log(Exception exception)
        {
            if (WriteInConsole)
                ConsoleLogger.Log(exception);
            if (WriteInDiagnostics)
                DiagnosticLogger.Log(exception);
            if (WriteInDb)
                DbLog.Log(exception);
            if (WriteInFile)
                FileLogger.Log(exception, LogFilePath);
        }

        public static void Log(WpException exception)
        {
            if (WriteInConsole)
                ConsoleLogger.Log(exception);
            if (WriteInDiagnostics)
                DiagnosticLogger.Log(exception);
            if (WriteInDb)
                DbLog.Log(exception);
            if (WriteInFile)
                FileLogger.Log(exception, LogFilePath);
        }

        public static void Log(LogEntryType type, LogActionType action, string log)
        {
            if (WriteInConsole)
                ConsoleLogger.Log(type, action, log);
            if (WriteInDiagnostics)
                DiagnosticLogger.Log(type, action, log);
            if (WriteInDb)
                DbLog.Log(type, action, log);
            if (WriteInFile)
                FileLogger.Log(type, action, log, string.Empty, LogFilePath);
        }

        public static void Log(LogEntryType type, LogActionType action, string log, string metadata)
        {
            if (WriteInConsole)
                ConsoleLogger.Log(type, action, log, metadata);
            if (WriteInDiagnostics)
                DiagnosticLogger.Log(type, action, log, metadata);
            if (WriteInDb)
                DbLog.Log(type, action, log, metadata);
            if (WriteInFile)
                FileLogger.Log(type, action, log, metadata, LogFilePath);
        }
    }
}
