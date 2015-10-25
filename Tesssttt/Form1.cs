using System;
using System.Data.EntityClient;
using System.Windows.Forms;
using WProject.BusinessLibrary;
using WProject.Library.Helpers.Utils.Db;

namespace Tesssttt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            var mm = new WPModel();
            var mo = mm.Users;
        }
    }
}
