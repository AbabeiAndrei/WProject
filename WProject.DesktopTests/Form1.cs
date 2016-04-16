using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.GenericLibrary.Helpers;
using WProject.UiLibrary.Classes;
using WProject.UiLibrary.Controls;

namespace WProject.DesktopTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string[] _users = 
            {
                "Alex",
                "Ionut",
                "Mircea",
                "Foo",
                "Bar"
            };

            wpTextThread1.Messages = Enumerable.Range(0, 100).Select(i => new ChatMessage
            {
                Message = Utils.RandomString(),
                Send = Utils.RandomBool(),
                SendBy = _users[Utils.RandomInt(0, _users.Length - 1)],
                DateTime = Utils.RandomDateTime()
            }).ToList();

            wpTextThread1.OnSend += (sender, args) =>
            {
                var ms = sender as WpTextThread;

                if (ms == null)
                    return;

                ms.Messages.Add(new ChatMessage
                {
                    Message = ms.Text,
                    Send = true
                });
            };
        }
    }
}
