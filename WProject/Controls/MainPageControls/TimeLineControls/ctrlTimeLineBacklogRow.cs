using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.Helpers;
using WProject.UiLibrary.Controls;
using Task = WProject.WebApiClasses.Classes.Task;

namespace WProject.Controls.MainPageControls.TimeLineControls
{
    public partial class ctrlTimeLineBacklogRow : UserControl
    {
        #region Properties

        public int BacklogId { get; set; }
        public int UserId { get; set; }

        public IEnumerable<ctrlTimeLineTaskItem> Tasks => Controls.OfType<ctrlTimeLineTaskItem>();

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

        private ctrlTimeLineTaskItem CreateTaskControl(Task task)
        {
            var mm = new ctrlTimeLineTaskItem
            {
                Task = task,
                Height = 20,
                Width = 200,
                Direction = ResizeDirection.East
            };

            mm.AfterMoveOrResize += async (sender, args) =>
            {
                var mc = UIHelper.MainPanel.SelectedControlPage as ctrlTimeLine;

                if (mc == null)
                    return;

                await mc.LoadTasks();
                mc.SetTasks(mc.Tasks);
            };

            return mm;
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

        public void ClearItems()
        {
            Controls.Clear();
            foreach (var mtask in Tasks)
                mtask.Dispose();
        }

        #endregion
    }
}
