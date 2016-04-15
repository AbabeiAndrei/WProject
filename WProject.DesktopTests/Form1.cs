using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.UiLibrary.Classes;

namespace WProject.DesktopTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            wpTextThread1.Messages = new List<ChatMessage>
            {
                new ChatMessage
                {
                    Send = true,
                    Message = "Hellooo"
                },
                new ChatMessage
                {
                    Message = "Hellodoo"
                },
            };
        }
    }
}
