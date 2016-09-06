using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task = WProject.WebApiClasses.Classes.Task;

namespace WProject.Controls.MainPageControls.TimeLineControls
{
    public partial class ctrlTimeLineBacklogRow : UserControl
    {
        #region Properties

        public int BacklogId { get; set; }

        #endregion

        #region Constructors

        public ctrlTimeLineBacklogRow()
        {
            InitializeComponent();
        }

        #endregion

        #region Public methods

        public void AddTasks(IEnumerable<Task> tasks)
        {
            foreach (Task mtask in tasks)
            {
                var mc = CreateTaskControl(mtask);
                Controls.Add(mc);
            }
        }

        #endregion

        #region Private methods

        private static ctrlTimeLineTaskItem CreateTaskControl(Task task)
        {
            return new ctrlTimeLineTaskItem
            {
                Task = task,
                Height = 20,
                Width = 200
            };
        }

        #endregion

        #region Public methods

        public int CalculateHeight()
        {
            return Controls.OfType<ctrlTimeLineTaskItem>()
                           .Select(c => c.Height)
                           .DefaultIfEmpty(0)
                           .Sum();
        }

        #endregion

    }
}
