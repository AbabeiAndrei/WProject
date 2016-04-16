using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
    }
}
