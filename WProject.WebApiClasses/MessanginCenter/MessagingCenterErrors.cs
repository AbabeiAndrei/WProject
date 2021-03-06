﻿using System;
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

        public const int ERROR_REGISTER_TASK_STATE_TASK_NOT_FOUND = 11;
        public const int ERROR_REGISTER_TASK_STATE_STATE_NOT_FOUND = 12;
        public const int ERROR_REGISTER_TASK_STATE_SAVE_CONTEXT = 13;

        public const int ERROR_REGISTER_BACKLOG_STATE_BACKLOG_NOT_FOUND = 14;
        public const int ERROR_REGISTER_BACKLOG_STATE_STATE_NOT_FOUND = 15;
        public const int ERROR_REGISTER_BACKLOG_STATE_SAVE_CONTEXT = 16;

        public const int ERROR_GET_TASK_NOT_FOUND = 17;

        public const int ERROR_ATTACH_FILE_TO_TASK_TASK_ATTACHEMENT_IS_NULL = 18;
        public const int ERROR_ATTACH_FILE_TO_TASK_TASK_SAVE_CONTEXT = 19;

        public const int ERROR_COMMENT_TO_TASK_COMMENT_IS_NULL = 20;
        public const int ERROR_COMMENT_TO_TASK_SAVE_CONTEXT = 21;
    }
}