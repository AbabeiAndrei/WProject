using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WProject.UiLibrary.Classes
{
    [Serializable]
    [DebuggerDisplay("SendBy : {SendBy}, Message : {Message}")]
    public class ChatMessage
    {
        public DateTime DateTime { get; set; }
        public string SendBy { get; set; }
        public string Message { get; set; }
        public bool Send { get; set; }
        public bool Empty { get; set; }

        public ChatMessage()
        {
            DateTime = DateTime.Now;
        }

        public string GetWhenSend(CultureInfo cuture = null)
        {
            var mv = DateTime.Now - DateTime;
            if (mv.TotalSeconds < 60)
                return "Just now";

            if(mv.TotalMinutes < 60)
            {
                var mmin = mv.Minutes;
                string mmin_string = "minute";
                if (mmin > 1)
                    mmin_string = "minutes";
                return mmin + $" {mmin_string} ago";
            }

            if (mv.TotalHours < 24)
            {
                var mhours = mv.Hours;
                string mhours_string = "hour";
                if (mhours > 1)
                    mhours_string = "hours";
                return mhours + $" {mhours_string}  ago";
            }

            if (mv.TotalDays < 3)
            {
                var mdays = mv.Days;
                string mdays_string = "day";
                if (mdays > 1)
                    mdays_string = "days";
                return mdays + $" {mdays_string} ago";
            }

            return DateTime.ToString(cuture ?? CultureInfo.DefaultThreadCurrentCulture);
        }
    }
}
