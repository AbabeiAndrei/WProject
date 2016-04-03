using System;
using WProject.GenericLibrary.Exceptions;

namespace WProject.WebApiClasses.MessanginCenter
{
    public class MessagingCenterResponse
    {
        public string Content { get; set; }
        public int ErrorCode { get; set; }
        public string Error { get; set; }
        public string Metadata { get; set; }
        public Exception Exception { get; set; }

        public MessagingCenterResponse()
        {
            Error = string.Empty;
            Content = string.Empty;
            Metadata = string.Empty;
        }

        public static MessagingCenterResponse Empty { get;}

        static MessagingCenterResponse()
        {
            Empty = new MessagingCenterResponse();
        }

        public static MessagingCenterResponse CreateError(WpException exception)
        {
            return new MessagingCenterResponse
            {
                Content = string.Empty,
                ErrorCode = exception.ErrorCode,
                Error = exception.Message,
                Metadata = exception.Metadata,
                Exception = exception
            };
        }
    }
}