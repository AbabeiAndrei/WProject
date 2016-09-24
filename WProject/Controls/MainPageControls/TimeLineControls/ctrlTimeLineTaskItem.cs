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
using WProject.Connection;
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.Properties;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Theme;
using WProject.WebApiClasses.Data;
using Task = WProject.WebApiClasses.Classes.Task;

namespace WProject.Controls.MainPageControls.TimeLineControls
{
    public partial class ctrlTimeLineTaskItem : ResizableControl
    {
        #region Fields

        private Brush _bkBrush;
        private Brush _bkTanspBrush;
        private Task _task;
        private bool _onMove;
        private bool _onResize;

        #endregion

        #region Properties

        public Task Task
        {
            get
            {
                return _task;
            }
            set
            {
                _task = value;

                if (_task.State == null)
                    _task.State = SimpleCache.Util.GetDictItemById(_task.StateId);

                Refresh();
            }
        }

        #endregion

        #region Events

        public event EventHandler AfterMoveOrResize;

        #endregion

        #region Constructors

        public ctrlTimeLineTaskItem()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides of WpStyledControl

        public override void ApplyStyle()
        {
            base.ApplyStyle();

            Color mc = _task?.AssignedToId != null && _task.AssignedToId.Value == WPSuite.ConnectedUserId
                                ? WpThemeColors.Amber
                                : WpThemeColors.Gray;

            _bkBrush = new SolidBrush(mc);
            _bkTanspBrush = new SolidBrush(mc.SetOpacity(100));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                bool mdone = _task.State?.Code == Task.States.DONE_CODE;
                bool minprogr = _task.State?.Code == Task.States.IN_PROGRESS_CODE;
                int mtotalDone = minprogr ? CalculateTotalDown() : 0;

                if (minprogr)
                {
                    var mdoneRect = new Rectangle(0, 0, mtotalDone, Height);
                    var mremainRect = new Rectangle(mtotalDone + 1, 0, Width - mtotalDone, Height);

                    e.Graphics.FillRectangle(_bkBrush, mdoneRect);
                    e.Graphics.FillRectangle(_bkTanspBrush, mremainRect);
                }
                else
                    e.Graphics.FillRectangle(_bkBrush, ClientRectangle);

                int mdescRectString = 2;    //implicit 2

                if (mdone)              //daca s-a terminat task-ul scade lungimea imaginii
                    mdescRectString = Height + 2;
                else if (minprogr)      //daca este in progress scade lungimea backgroundului transparent
                    mdescRectString = Width - mtotalDone;

                var mrect = new Rectangle(2, 2, Width - mdescRectString, Height - 2);
                
                e.Graphics.DrawString(_task.FullName, Font, Brushes.Black, mrect);

                if(mdone)
                    e.Graphics.DrawImage(Resources.done_s.SetOpacity(100), new Rectangle(Width-Height, 0, Height, Height));
            }
            finally
            {
                base.OnPaint(e);
            }
        }

        private int CalculateTotalDown()
        {
            if (!(_task.StartHour.HasValue && _task.EndHour.HasValue))
                return Width;
            
            var meta = _task.StartHour.Value - _task.EndHour.Value;             //calculare diferenta (timp estimat ramas)
            var mpasedTime = DateTime.Now.TimeOfDay - _task.StartHour.Value;    //

            var mproc = 100/meta.TotalMinutes*mpasedTime.TotalMinutes;

            return (int) (Width*(mproc/100));
        }

        #endregion

        #region Overrides of Control

        protected override void OnClick(EventArgs e)
        {
            try
            {
                if(_task == null || _onMove || _onResize)
                    return;

                var mcontrol = UIHelper.MainPanel.SelectedControlPage as ctrlTimeLine;

                if (mcontrol == null)
                    return;

                var mtask = mcontrol.Tasks.FirstOrDefault(b => b.Id == _task.Id);

                if (mtask != null)
                    UIHelper.ShowTaskEditor(mtask, async b =>
                    {
                        await mcontrol.LoadTasks();
                        mcontrol.SetTasks(mcontrol.Tasks);
                    });
            }
            finally
            {
                _onMove = false;
                _onResize = false;
                base.OnClick(e);
            }
        }

        #endregion

        #region Event handlers

        private async void ctrlTimeLineTaskItem_AfterMove(object sender, ControlMovedArgs args)
        {
            try
            {
                UIHelper.ShowLoader();

                var mctrlTimeLine = UIHelper.MainPanel.SelectedControlPage as ctrlTimeLine;

                var mrows = mctrlTimeLine?.RowsControl;

                if (mrows == null)
                    return;

                var mnewHours = TimeSpan.FromMinutes(args.NewLocation.X/2f).Add(TimeSpan.FromHours(mrows.StartHour));

                var mres = await WebCallFactory.SetNewTimeToTask(_task.Id, mnewHours);

                if (mres.Error)
                    throw mres.Exception;

                AfterMoveOrResize?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception mex)
            {
                Location = args.OldLocation;

                Logger.Log(mex);
                UIHelper.ShowError(mex);
            }
            finally
            {
                UIHelper.HideLoader();
            }
        }

        private async void ctrlTimeLineTaskItem_AfterResize(object sender, ControlResizedArgs args)
        {

            try
            {
                UIHelper.ShowLoader();

                var mctrlTimeLine = UIHelper.MainPanel.SelectedControlPage as ctrlTimeLine;

                var mrows = mctrlTimeLine?.RowsControl;

                if (mrows == null)
                    return;

                var mnewHours = TimeSpan.FromMinutes(Right / 2f).Add(TimeSpan.FromHours(mrows.StartHour));

                var mres = await WebCallFactory.SetNewTimeToTask(_task.Id, mnewHours, false);

                if (mres.Error)
                    throw mres.Exception;

                AfterMoveOrResize?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception mex)
            {
                Size = args.OldSize;

                Logger.Log(mex);
                UIHelper.ShowError(mex);
            }
            finally
            {
                UIHelper.HideLoader();
            }
        }

        private void ctrlTimeLineTaskItem_BeginMove(object sender, EventArgs e)
        {
            _onMove = true;
        }

        private void ctrlTimeLineTaskItem_BeginResize(object sender, EventArgs e)
        {
            _onResize = true;
        }

        #endregion

        #region Public methods

        public int CalculateWidthByEstimatedTime()
        {
            if (_task.StartHour.HasValue && _task.EndHour.HasValue)
                return (int) (_task.EndHour.Value - _task.StartHour.Value).TotalMinutes * 2;

            if (_task.RemainingWork.HasValue)
                return Math.Max(_task.RemainingWork.Value, 10) * 2;

            return 120;
        }

        #endregion
    }
}
