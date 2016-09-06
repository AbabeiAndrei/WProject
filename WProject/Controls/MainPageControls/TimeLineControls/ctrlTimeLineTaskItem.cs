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
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.Properties;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Theme;
using WProject.WebApiClasses.Data;
using Task = WProject.WebApiClasses.Classes.Task;

namespace WProject.Controls.MainPageControls.TimeLineControls
{
    public partial class ctrlTimeLineTaskItem : WpUserControl
    {
        #region Fields

        private Brush _bkBrush;
        private Brush _bkTanspBrush;
        private Task _task;

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
    }
}
