using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.Classes;
using WProject.Interfaces;
using WProject.Properties;
using WProject.UiLibrary.Classes;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Theme;
using WProject.WebApiClasses.Classes;
using WProject.WebApiClasses.Data;
using Task = WProject.WebApiClasses.Classes.Task;

namespace WProject.Controls.MainPageControls.TimeLineControls
{
    public partial class ctrlTimeLineRowHeaderUser : WpUserControl
    {
        #region Fields

        #endregion

        #region Properties

        public bool Expanded
        {
            get
            {
                return pnlBacklogs.Visible;
            }
            set
            {
                pnlBacklogs.Visible = value;

                pbExpand.Image = value
                                     ? Resources.tree_s
                                     : Resources.expand_s;

                OnExpand?.Invoke(this, new TimeLineRowHeaderExpandArgs(UserId, value));
            }
        }

        public int UserId { get; }

        public WpPanel InnerContainer => pnlBacklogs;

        public int NameHeight => lblName.Height;

        #endregion

        #region Events

        public event TimeLineRowHeaderExpand OnExpand;

        public event Action<int, Color> BacklogMouseEnter
        {
            add
            {
                foreach (var mc in pnlBacklogs.Controls.OfType<ctrlTimeLineBacklogItem>())
                    mc.BacklogMouseEnter += value;
            }
            remove 
            {
                foreach (var mc in pnlBacklogs.Controls.OfType<ctrlTimeLineBacklogItem>())
                    mc.BacklogMouseEnter -= value;
            }
        }

        #endregion

        #region Constructors

        public ctrlTimeLineRowHeaderUser()
        {
            InitializeComponent();
        }

        public ctrlTimeLineRowHeaderUser(int userId)
            : this()
        {
            UserId = userId;

            Expanded = UserId == WPSuite.ConnectedUserId;

            var mu = SimpleCache.Util.GetUserById(UserId);

            if (mu == null)
                return;

            lblName.Text = mu.Name;
            var muavatar = mu.Avatar?.GetImage();

            pbAvatar.Image = muavatar;
            pbAvatar.Visible = muavatar != null;
        }

        #endregion

        #region Event handlers

        private void pbExpand_Click(object sender, EventArgs e)
        {
            Expanded = !Expanded;
        }

        #endregion

        #region Private methods

        private Control CreateBacklogControl(int backlogId, string name, int typeId)
        {
            return new ctrlTimeLineBacklogItem
            {
                BacklogId = backlogId,
                Text = name,
                RibbonColor = SimpleCache.FirstOrDefault<DictItem>(di => di.Id == typeId)?.Color ?? WpThemeColors.Amber,
                Dock = DockStyle.Top,
                OwnStyle = true,
                Style =
                {
                    NormalStyle =
                    {
                        Padding = new Padding(40, 4, 0, 0)
                    }
                },
                Name = $"{nameof(ctrlTimeLineBacklogItem)}_{backlogId}"
            };
        }

        #endregion

        #region Public methods

        public void SetBacklogs(IEnumerable<Task> tasks, ITaskAddableControl taskAddable)
        {
            foreach (var mitem in tasks.GroupBy(t => new
            {
                t.BacklogId,
                t.Backlog.Name,
                t.TypeId
            }))
            {
                var mc = CreateBacklogControl(mitem.Key.BacklogId, mitem.Key.Name, mitem.Key.TypeId);

                taskAddable.AddBackLog(UserId, mitem.Key.BacklogId);

                mc.Height = taskAddable.AddTasks(mitem, mitem.Key.BacklogId);

                pnlBacklogs.Controls.Add(mc);
            }
        }

        public void ResizeControl()
        {
            foreach (var mitem in pnlBacklogs.Controls.OfType<ctrlTimeLineBacklogItem>())
                mitem.Height = mitem.CalculateSize() + 2;
        }

        #endregion
    }
}
