using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.DataAccess;

namespace WProject.DestopTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var ml = Enumerable.Range(0, 50).Select(i => new Tuple<int, string>(i, "Item " + i)).ToList();
            
        }
    }
}
