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
    public partial class ctrlProjectEdit : UserControl
    {
        private Project _project;

        public Func<Project, Task> AfterSave { get; set; }

        public ctrlProjectEdit()
        {
            InitializeComponent();
        }

        public ctrlProjectEdit(Project project)
        {
            _project = project;
        }
    }
}
