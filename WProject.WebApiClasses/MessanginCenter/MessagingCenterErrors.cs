using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace WProject.WebApiClasses.MessanginCenter
{
    public static class MessagingCenterErrors
    {
        public const int NO_ERROR = 0;
        public const int UNKNOW_ERROR = 1;

        public const int ERROR_MESSANGING_CENTERE_PACKAGE_IS_NULL = 2;
        public const int ERROR_MESSANGING_CENTERE_NO_METHOD_REQUESTED = 3;
        public const int ERROR_MESSANGING_CENTERE_METHOD_NOT_FOUND = 4;
        public const int ERROR_MESSANGING_CENTERE_DURING_THE_EXECUTION = 5;

        public const int ERROR_LIMIT_CONNECTIONS_REACHED = 6;

        public const int ERROR_MESSANGING_CENTER_CONTENT_IS_EMPTY = 7;

        public const int ERROR_USER_OR_PASS_WRONG = 8;
        public const int ERROR_USER_IS_EXPIRED = 9;
        public const int ERROR_USER_IS_SUSPENDED = 10;
    }
}