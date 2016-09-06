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
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.Interfaces;
using WProject.UiLibrary;
using WProject.UiLibrary.Controls;
using WProject.WebApiClasses.Classes;

namespace WProject.Controls.MainPageControls
{
    public abstract partial class MainPageControl : WpUserControl, IMainPageControl
    {
        #region Properties

        public virtual StatusBarVisbility StatusBarVisibility { get; }

        public virtual string[] StatusBarTexts => null;

        #endregion

        #region Constructors

        protected MainPageControl()
        {
            InitializeComponent();

            // ReSharper disable once VirtualMemberCallInContructor
            Dock = DockStyle.Fill;
            Visible = false;

            StatusBarVisibility = new StatusBarVisbility
            {
                OnChatsClick = OnStatusBarChatClick
            };
        }

        #endregion

        #region Implementation of IMainPageControl

        public abstract Pages Page { get; }

        public virtual bool CanChangeProject => true;

        #endregion

        #region Overrides of Control

        protected override void OnPaint(PaintEventArgs e)
        {
            /*if(Visible)
                e.Graphics.DrawString(Page.ToString().ToUpper(), Font, new SolidBrush(Color.Black), PointF.Empty);*/
            base.OnPaint(e);
        }

        #endregion

        #region Abstract Methods

        public abstract void SetProject(Project project);

        #endregion

        #region Protected methods

        protected virtual void OnStatusBarChatClick()
        {
            Logger.Log("MainPageControl > OnStatusBarChatClick (NOT IMPLEMENTED)");
        }

        #endregion

        #region Public methods

        public virtual void OnPageSelected()
        {
            Logger.Log("MainPageControl > OnPageSelected (NOT IMPLEMENTED)");
        }

        #endregion

    }
}
