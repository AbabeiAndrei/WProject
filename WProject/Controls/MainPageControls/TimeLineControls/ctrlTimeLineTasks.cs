﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.Classes;
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.Interfaces;
using WProject.UiLibrary.Components;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Theme;
using WProject.WebApiClasses.Classes;
using Task = WProject.WebApiClasses.Classes.Task;

namespace WProject.Controls.MainPageControls.TimeLineControls
{
    public partial class ctrlTimeLineTasks : WpUserControl, ITaskAddableControl
    {
        #region Constants

        public const int HEADER_SIZE = 40;
        public const int MIN_HEIGHT_FOR_ROW = 24;
        public const int HALF_HOUR_WIDTH = 60;

        #endregion

        #region Fields
        
        private int _startHour;
        private int _endHour;
        private Brush _brushHeader;
        private Font _fontHeader;

        #endregion

        #region Properties

        public int StartHour
        {
            get
            {
                return _startHour;
            }
            set
            {
                _startHour = value;
                Refresh();
            }
        }

        public int EndHour
        {
            get
            {
                return _endHour;
            }
            set
            {
                _endHour = value;
                Refresh();
            }
        }

        public int WorkHours => Math.Abs(EndHour - StartHour);

        public IEnumerable<ctrlTimeLineRow> Users => pnlMain?.Controls.OfType<ctrlTimeLineRow>() ?? Enumerable.Empty<ctrlTimeLineRow>();

        #endregion

        #region Constructors

        public ctrlTimeLineTasks()
        {
            InitializeComponent();
        }

        #endregion

        #region Implementation of ITaskAddableControl

        public int AddTasks(IEnumerable<Task> tasks, int backlogId, int userId)
        {
            var mc = pnlMain.Controls
                            .OfType<ctrlTimeLineRow>()
                            .SelectMany(r => r.BacklogControls)
                            .FirstOrDefault(b => b.BacklogId == backlogId && b.UserId == userId);

            if (mc == null)
                return MIN_HEIGHT_FOR_ROW;

            mc.AddTasks(tasks);

            return mc.Height;
        }

        public Control AddUser(int userId)
        {
            Control mc = pnlMain.Controls
                                .OfType<ctrlTimeLineRow>()
                                .FirstOrDefault(r => r.UserId == userId);

            if (mc != null)
                return mc;

            mc = CreateUserRow(userId);

            pnlMain.Controls.Add(mc);

            return mc;
        }

        public Control AddBackLog(int userId, int backlogId)
        {
            var mc = pnlMain.Controls
                            .OfType<ctrlTimeLineRow>()
                            .FirstOrDefault(r => r.UserId == userId);

            if (mc != null)
                return mc.AddBacklog(backlogId, userId);    

            //todo : return null sau throw
            var musrc = AddUser(userId) as ctrlTimeLineRow;

            var mmc =  musrc?.AddBacklog(backlogId, userId);

            return mmc;
        }

        #endregion

        #region Overrides of WpStyledControl

        public override void ApplyStyle()
        {
            try
            {
                _brushHeader = new SolidBrush(ForeColor);
                _fontHeader = new Font("Segoe UI Light", 24f);
            }
            finally
            {
                base.ApplyStyle();
            }
        }

        #endregion

        #region Event handlers

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

            var mcolor = WpThemeColors.Blue;
            const int mheightGradient = 250;
            const int mhalfColorOpacity = 70;

            bool misHalf = false;

            var mb = new LinearGradientBrush(new Point(0, 0),
                                             new Point(0, mheightGradient),
                                             mcolor.SetOpacity(0),
                                             mcolor);

            var mbHalf = new LinearGradientBrush(new Point(0, 0),
                                                 new Point(0, mheightGradient),
                                                 mcolor.SetOpacity(0),
                                                 mcolor.SetOpacity(mhalfColorOpacity));
            var mpgr = new Pen(mb);                                     //pen gradient
            var mpgrHalf = new Pen(mbHalf);                             //pen gradient transparent
            var mp = new Pen(mcolor);                                   //pen continuare
            var mpHalf = new Pen(mcolor.SetOpacity(mhalfColorOpacity)); //pen continuare transparent

            try
            {
                for (int mi = 0; mi < pnlMain.Width; mi += HALF_HOUR_WIDTH)
                {
                    var mpenTrans = misHalf
                                        ? mpgrHalf
                                        : mpgr;
                    var mpenOpaq = misHalf
                                       ? mpHalf
                                       : mp;

                    var mspoint = new Point(mi, mheightGradient);
                    e.Graphics.DrawLine(mpenTrans,
                                        new Point(mi, 0),
                                        mspoint);
                    e.Graphics.DrawLine(mpenOpaq,
                                        mspoint,
                                        new Point(mi, 1200));       //todo pnlMain.Height

                    misHalf = !misHalf; //alternare opac cu transarent
                }
                int mdi = 0;
                for (int mi = StartHour; mi <= EndHour; mi++)
                    e.Graphics.DrawString(mi.ToString("00") + ":00",
                                          _fontHeader,
                                          _brushHeader,
                                          mdi++*HALF_HOUR_WIDTH*2 + 5,
                                          5);
            }
            finally
            {
                mb.Dispose();
                mbHalf.Dispose();
                mpgr.Dispose();
                mpgrHalf.Dispose();
                mp.Dispose();
                mpHalf.Dispose();
            }
        }

        #endregion
        
        #region Overrides of WpUserControl

        public override void DisposeComponents()
        {
            try
            {
                _fontHeader?.Dispose();
                _brushHeader?.Dispose();
            }
            finally
            {
                base.DisposeComponents();
            }
        }

        #endregion

        #region Private methods

        private Control CreateUserRow(int userId)
        {
            return new ctrlTimeLineRow
            {
                UserId = userId,
                Name = $"{nameof(ctrlTimeLineRow)}_{userId}",
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
        }

        #endregion

        #region Public methods

        public void SetExpanded(int userId, bool expanded)
        {
            var mc = Controls.OfType<Control>()
                             .SelectMany(c => c.Controls.OfType<ctrlTimeLineRow>())
                             .FirstOrDefault(r => r.UserId == userId);

            mc?.SetExpanded(expanded);
        }

        public void SetBacklogHover(int backlogId, int userId, Color color)
        {
            var mc = Controls.OfType<ctrlTimeLineRow>()
                             .SelectMany(r => r.BacklogControls)
                             .FirstOrDefault(b => b.BacklogId == backlogId && b.UserId == userId);

            if(mc == null)
                return;

            mc.BackColor = color;
        }

        public void PerformResizeWidth(int clientSize = -1)
        {
            if (pnlMain != null)
                pnlMain.Width = Math.Max((EndHour - StartHour)*HALF_HOUR_WIDTH*2, clientSize);
        }

        public void PerformResizeHeigh(int height)
        {
            if (pnlMain != null)
                pnlMain.Height = height;
        }

        public void RepositionControls(IUserPositions positions)
        {
            int mheight = 0;

            foreach (var mposition in positions.Positions)
            {
                var mc = pnlMain.Controls
                                .OfType<ctrlTimeLineRow>()
                                .FirstOrDefault(c => c.UserId == mposition.UserId);

                if(mc == null)
                    continue;

                mc.Top = HEADER_SIZE + mheight;
                mc.Left = 0;
                mc.Width = WorkHours * HALF_HOUR_WIDTH * 2;

                foreach (var mbacklogPosition in mposition.Positions)
                {
                    var mcc = mc.BacklogControls
                                .FirstOrDefault(c => c.BacklogId == mbacklogPosition.BacklogId);

                    if (mcc == null)
                        continue;

                    mcc.Top = mbacklogPosition.Top;
                    mcc.Width = mc.Width;

                    //mheight += mcc.CalculateHeight();

                    foreach (var mtask in mcc.Tasks)
                    {
                        mtask.Top = 2;
                        mtask.Height = 22;
                        
                        if(mtask.Task.StartHour.HasValue)
                        mtask.Left = (mtask.Task.StartHour.Value.Hours - StartHour) * HALF_HOUR_WIDTH * 2 + mtask.Task.StartHour.Value.Minutes * 2;
                        mtask.Width = mtask.CalculateWidthByEstimatedTime();
                    }
                }

                mc.Height = mposition.Height + mposition.Positions.Select(bp => bp.Height).DefaultIfEmpty(0).Sum();

                mheight += mc.Height;
            }
        }

        public void ClearItems()
        {
            foreach (var mrow in pnlMain.Controls.OfType<ctrlTimeLineRow>())
            {
                Controls.Remove(mrow);
                mrow.ClearItems();
                mrow.Dispose();
            }
        }

        public void ExpandAll(bool expanded, int except)
        {
            foreach (ctrlTimeLineRow mc in Controls.OfType<Control>()
                                                   .SelectMany(c => c.Controls.OfType<ctrlTimeLineRow>())
                                                   .Where(r => r.UserId != except))
            
                mc.SetExpanded(expanded);
        }

        #endregion
    }
}
