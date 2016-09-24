using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Helpers;

namespace WProject.Controls.MainPageControls.TimeLineControls
{
    public partial class ctrlTimeLineRow : WpUserControl
    {
        #region Fields

        private bool _expanded;
        private StringFormat _startHourStringFormat;
        private StringFormat _endHourStringFormat;
        private SolidBrush _colorStartEndHour;
        private Font _fontStartEndHour;
        private Pen _penStartEndHour;

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

        public IEnumerable<ctrlTimeLineBacklogRow> BacklogControls => pnlTasks?.Controls
                                                                               .OfType<ctrlTimeLineBacklogRow>() ??
                                                                      Enumerable.Empty<ctrlTimeLineBacklogRow>();

        #endregion

        #region Constructors

        public ctrlTimeLineRow()
        {
            InitializeComponent();

            var mcolor = Color.Black.SetOpacity(150);

            _startHourStringFormat = new StringFormat
            {
                Alignment = StringAlignment.Far
            };

            _endHourStringFormat = new StringFormat
            {
                Alignment = StringAlignment.Near
            };
            _colorStartEndHour = new SolidBrush(mcolor);
            _fontStartEndHour = new Font("Segoe UI", 10f);
            _penStartEndHour = new Pen(mcolor);
        }

        #endregion

        #region Overrides of WpStyledControl

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if(!Visible)
                    return;

                const int mtextLength = 80;
                const int mminusTop = 15;

                foreach (var mbk in BacklogControls)
                {
                    int mtop = mbk.Top;

                    foreach (var mitem in mbk.Tasks)
                    {
                        
                        if(!mitem.Task.StartHour.HasValue)
                            continue;

                        int mbotom = mtop + mitem.Height;

                        e.Graphics.DrawString(mitem.Task.StartHour.Value.Hours.ToString("00") + ":" + mitem.Task.StartHour.Value.Minutes.ToString("00"),
                                              _fontStartEndHour,
                                              _colorStartEndHour,
                                              new Rectangle(mitem.Left - mtextLength, mtop - mminusTop, mtextLength, 15),
                                              _startHourStringFormat);

                        e.Graphics.DrawLine(_penStartEndHour, mitem.Left - 1, mtop - mminusTop, mitem.Left - 1, mbotom + 1);

                        string mendHour;

                        if(mitem.Task.EndHour.HasValue)
                            mendHour = mitem.Task.EndHour.Value.Hours.ToString("00") + ":" + mitem.Task.EndHour.Value.Minutes.ToString("00");
                        else if (mitem.Task.RemainingWork.HasValue)
                        {
                            var mendTime = mitem.Task.StartHour.Value.Add(TimeSpan.FromMinutes(mitem.Task.RemainingWork.Value));

                            mendHour = mendTime.Hours.ToString("00") + ":" + mendTime.Minutes.ToString("00");
                        }
                        else
                            continue;

                        e.Graphics.DrawString(mendHour,
                                              _fontStartEndHour,
                                              _colorStartEndHour,
                                              new Rectangle(mitem.Right, mtop - mminusTop, mtextLength, 15),
                                              _endHourStringFormat);

                        e.Graphics.DrawLine(_penStartEndHour, mitem.Right, mtop - mminusTop, mitem.Right, mbotom + 1);


                    }
                }
            }
            finally
            {
                base.OnPaint(e);
            }
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

        private Control CreateBacklogItem(int backlogId, int userId)
        {
            return new ctrlTimeLineBacklogRow
            {
                BacklogId = backlogId,
                UserId = userId,
                Name = $"{nameof(ctrlTimeLineBacklogRow)} {backlogId} {userId}"
            };
        }

        #endregion

        #region Public methods

        public Control AddBacklog(int backlogId, int userId)
        {
            Control mc = pnlTasks.Controls
                                 .OfType<ctrlTimeLineBacklogRow>()
                                 .FirstOrDefault(bi => bi.BacklogId == backlogId && bi.UserId == userId);

            if (mc != null)
                return mc;

            mc = CreateBacklogItem(backlogId, userId);

            pnlTasks.Controls.Add(mc);

            return mc;
        }

        public void SetExpanded(bool expanded)
        {
            /*foreach (var mcontrol in BacklogControls)
                mcontrol.*/Visible = expanded;
        }

        public void ClearItems()
        {
            pnlTasks.Controls.Clear();
            Controls.Clear();
            foreach (var mbacklogRow in BacklogControls)
            {
                mbacklogRow.ClearItems();
                mbacklogRow.Dispose();
            }
        }

        #endregion
    }
}
