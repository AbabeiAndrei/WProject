using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.GenericLibrary.Exceptions;

namespace WProject.GenericLibrary.Helpers.Log
{
    public static class Logger
    {
        public static bool WriteToConsole { get; set; }
        public static bool WriteToFile { get; set; }
        public static bool WriteToDiagnostics { get; set; }
        public static string FileLogPath { get; set; }

        public static void Log(string log)
        {
            if(WriteToConsole)
                ConsoleLogger.Log(log);
            if(WriteToDiagnostics)
                DiagnosticLogger.Log(log);
            if (WriteToFile)
                FileLogger.Log(log, FileLogPath);
        }

        public static void Log(Exception exception)
        {
            WpException mwpex = exception as WpException;
            if (mwpex != null)
            {
                Log(mwpex);
                return;
            }

            if (WriteToConsole)
                ConsoleLogger.Log(exception);
            if (WriteToDiagnostics)
                DiagnosticLogger.Log(exception);
            if (WriteToFile)
                FileLogger.Log(exception, FileLogPath);
        }

        public static void Log(WpException exception)
        {
            if (WriteToConsole)
                ConsoleLogger.Log(exception);
            if (WriteToDiagnostics)
                DiagnosticLogger.Log(exception);
            if (WriteToFile)
                FileLogger.Log(exception, FileLogPath);
        }

        public static void Log(LogEntryType type, LogActionType action, string log)
        {
            if (WriteToConsole)
                ConsoleLogger.Log(type, action, log);
            if (WriteToDiagnostics)
                DiagnosticLogger.Log(type, action, log);
            if (WriteToFile)
                FileLogger.Log(type, action, log, string.Empty, FileLogPath);
        }

        public static void Log(LogEntryType type, LogActionType action, string log, string metadata)
        {
            if (WriteToConsole)
                ConsoleLogger.Log(type, action, log, metadata);
            if (WriteToDiagnostics)
                DiagnosticLogger.Log(type, action, log, metadata);
            if (WriteToFile)
                FileLogger.Log(type, action, log, metadata, FileLogPath);
        }
    }
}
