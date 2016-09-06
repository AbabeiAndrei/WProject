using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.UiLibrary.Controls;

namespace WProject.Controls.MainPageControls.TimeLineControls
{
    public partial class ctrlTimeLineRow : WpUserControl
    {
        #region Fields

        private bool _expanded;

        #endregion

        #region Properties


        public int UserId { get; set; }

        public bool Expanded
        {
            get
            {
                return _expanded;
            }
            set
            {
                _expanded = value;

                pnlTasks.Visible = _expanded;
                pnlInfo.Refresh();
            }
        }

        public IEnumerable<ctrlTimeLineBacklogRow> BacklogControls => pnlTasks.Controls
                                                                               .OfType<ctrlTimeLineBacklogRow>();

        #endregion

        #region Constructors

        public ctrlTimeLineRow()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void pnlInfo_Paint(object sender, PaintEventArgs e)
        {
            if (pnlTasks.Visible)
                return;

            //todo make map
        }

        #endregion

        #region Private methods

        private Control CreateBacklogItem(int backlogId)
        {
            return new ctrlTimeLineBacklogRow
            {
                BacklogId = backlogId,
                Name = $"{nameof(ctrlTimeLineBacklogRow)} {backlogId}"
            };
        }

        #endregion

        #region Public methods

        public Control AddBacklog(int backlogId)
        {
            Control mc = pnlTasks.Controls
                                 .OfType<ctrlTimeLineBacklogRow>()
                                 .FirstOrDefault(bi => bi.BacklogId == backlogId);

            if (mc != null)
                return mc;

            mc = CreateBacklogItem(backlogId);

            pnlTasks.Controls.Add(mc);

            return mc;
        }

        #endregion
    }
}
