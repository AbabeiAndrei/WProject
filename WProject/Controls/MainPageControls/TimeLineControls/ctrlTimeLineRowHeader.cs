using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.Classes;
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.Interfaces;
using WProject.UiLibrary.Classes;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Helpers;
using WProject.UiLibrary.Style;
using WProject.UiLibrary.Theme;
using Task = WProject.WebApiClasses.Classes.Task;

namespace WProject.Controls.MainPageControls.TimeLineControls
{
    public partial class ctrlTimeLineRowHeader : WpUserControl, IUserPositions
    {
        #region Properties

        public int TopPadding
        {
            get
            {
                return pnlPadding.Height;
            }
            set
            {
                pnlPadding.Height = value;
            }
        }

        public IEnumerable<ctrlTimeLineRowHeaderUser> Users => Controls.OfType<ctrlTimeLineRowHeaderUser>();

        #endregion

        #region Events

        public event TimeLineRowHeaderExpand OnRowElaptionChanged;
        public event Action<int, int, Color> BacklogMouseEnter;

        #endregion

        #region Constructrors

        public ctrlTimeLineRowHeader()
        {
            InitializeComponent();
        }

        #endregion

        #region Implementation of IBacklogPositions

        public IEnumerable<UserPosition> Positions
        {
            get
            {
                return Controls.OfType<ctrlTimeLineRowHeaderUser>()
                               .Select(c => new UserPosition(c.UserId, c.Top)
                               {
                                   Height = c.Height,
                                   Positions = c.InnerContainer
                                                .Controls
                                                .OfType<ctrlTimeLineBacklogItem>()
                                                .Select(cb => new BacklogPosition(cb.BacklogId, c.Top + c.NameHeight + cb.Top)
                                                {
                                                    Height = cb.Height
                                                })
                               })
                               .OrderByDescending(up => up.UserId == WPSuite.ConnectedUserId);
            }
        }

        #endregion

        #region Private methods

        private Control CreateTaskUser(int userId, IEnumerable<Task> tasks, ITaskAddableControl taskAddable)
        {
            var mc = new ctrlTimeLineRowHeaderUser(userId)
            {
                Dock = DockStyle.Top,
                Name = $"{nameof(ctrlTimeLineRowHeaderUser)} {userId}"
            };

            var musrc = taskAddable.AddUser(userId);

            mc.BacklogMouseEnter += BacklogMouseEnter;

            mc.SetBacklogs(tasks, taskAddable);

            mc.OnExpand += (sender, args) => OnRowElaptionChanged?.Invoke(sender, args);

            musrc.Height = mc.Height;
            
            return mc;
        }

        #endregion

        #region Public methods

        public void ClearItems()
        {
            foreach (var mcontrol in Controls.OfType<ctrlTimeLineRowHeaderUser>())
            {
                mcontrol.ClearItems();
                mcontrol.Dispose();
            }

            Controls.Clear();
            Controls.Add(pnlPadding);
        }

        public void SetTasks(IEnumerable<Task> tasks, ITaskAddableControl taskAddable)
        {
            Controls.AddRange(tasks.Where(t => t.AssignedToId.HasValue)
                                   .GroupBy(t => t.AssignedToId.Value)
                                   .OrderBy(g => g.Key == WPSuite.ConnectedUserId)
                                   .Select(t => CreateTaskUser(t.Key, t, taskAddable))
                                   .ToArray());
        }

        public int ResizeControls()
        {
            foreach (var mitem in Controls.OfType<ctrlTimeLineRowHeaderUser>())
                mitem.ResizeControl();

            pnlPadding.SendToBack();

            return Controls.OfType<ctrlTimeLineRowHeaderUser>()
                           .Select(c => c.Height)
                           .DefaultIfEmpty(0)
                           .Sum();
        }

        #endregion
    }
}
