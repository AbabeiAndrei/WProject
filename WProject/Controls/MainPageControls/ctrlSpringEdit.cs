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

namespace WProject.Controls.MainPageControls
{
    public partial class ctrlSpringEdit : UserControl
    {
        private Tuple<Spring, Category> _tuple;

        public Tuple<Project, Spring, Category> NewData { get; set; }

        public Func<Tuple<Spring, Category>, Task> AfterSave { get; set; }

        public ctrlSpringEdit()
        {
            InitializeComponent();
        }

        public ctrlSpringEdit(Tuple<Spring, Category> tuple)
        {
            _tuple = tuple;
        }

    }
}
