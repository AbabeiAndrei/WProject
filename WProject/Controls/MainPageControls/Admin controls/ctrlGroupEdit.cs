using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.WebApiClasses.Classes;
using Task = System.Threading.Tasks.Task;

namespace WProject.Controls.MainPageControls.Admin_controls
{
    public partial class ctrlGroupEdit : UserControl
    {
        private Group _group;

        public Func<Group, Task> AfterSave { get; set; }

        public ctrlGroupEdit()
        {
            InitializeComponent();
        }

        public ctrlGroupEdit(Group group)
        {
            _group = group;
        }
    }
}
