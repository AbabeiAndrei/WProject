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
using WProject.GenericLibrary.Helpers.Log;
using WProject.Helpers;
using WProject.UiLibrary;
using WProject.UiLibrary.Controls;
using WProject.WebApiClasses.Classes;
using Task = System.Threading.Tasks.Task;

namespace WProject.Controls.MainPageControls.DashboardControls
{
    public partial class ctrlDashBoardTasks : WpUserControl
    {
        #region Constructors

        public ctrlDashBoardTasks()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides of Control

        protected override void OnSizeChanged(EventArgs e)
        {
            try
            {
                SuspendLayout();

                int mitemWidth = (int)Math.Floor((Width - ctrlDashBoardBacklogItem.DefaultSize.Width - 5d) /3);

                lblToDo.Width =
                    lblInProgress.Width =
                    lblDone.Width = mitemWidth;

                foreach (var mresult in pnlBackLogs.Controls.OfType<ctrlDashBoardBacklogItem>())
                    mresult.Columns = DashBoardColumnsCollectionSize.Create(lblToDo.Width, lblInProgress.Width, lblDone.Width, Width - ctrlDashBoardBacklogItem.DefaultSize.Width);

            }
            finally
            {
                ResumeLayout();
                base.OnSizeChanged(e);
            }
        }

        #endregion

        #region Public methods

        public async Task LoadTasks(Spring spring, Category category)
        {
            Logger.Log("Show backLogs for " + (category != null
                                                   ? $"category {category.Name}"
                                                   : $"spring {spring?.Name}"));

            try
            {
                UIHelper.ShowLoader("Get backlogs");

                pnlBackLogs.SuspendLayout();

                ClearControls();

                var mres = await WebCallFactory.GetAllBackLogs(spring?.Id, category?.Id);

                if (mres.Error)
                    throw mres.Exception;

                pnlBackLogs.Controls.AddRange(mres.Backlogs.Select(CreateBackLogControl).Cast<Control>().ToArray());

                UIHelper.HideLoader();
            }
            catch (Exception mex)
            {
                UIHelper.HideLoader();
                UIHelper.ShowError(mex);
            }
            finally
            {
                pnlBackLogs.ResumeLayout();
            }
        }

        #endregion

        #region Private methods

        private void ClearControls()
        {
            foreach (Control mcontrol in pnlBackLogs.Controls.Cast<Control>().Where(mcontrol => !mcontrol.Disposing))
                mcontrol.Dispose();

            pnlBackLogs.Controls.Clear();
        }

        private ctrlDashBoardBacklogItem CreateBackLogControl(Backlog backLog)
        {
            var mctrlbtem = new ctrlDashBoardBacklogItem(backLog)
            {
                Size = new Size(lblDone.Right - pbAdd.Left, 56),
                Dock = DockStyle.Top,
                Margin = new Padding(0, 4, 0, 2),
                Columns = DashBoardColumnsCollectionSize.Create(lblToDo.Width,
                                                                lblInProgress.Width,
                                                                lblDone.Width,
                                                                Width - ctrlDashBoardBacklogItem.DefaultSize.Width)
            };

            if(UIHelper.OpenedBackLogs.Contains(backLog.Id))
                mctrlbtem.Expand();

            mctrlbtem.OnCollaptionChange += (sender, args) =>
            {
                Logger.Log("UIHelper.OpenedBackLogs updated");
                var mc = sender as ctrlDashBoardBacklogItem;

                if (mc == null)
                    return;

                if (args.Collapsed)
                    UIHelper.OpenedBackLogs.RemoveAll(i => i == mc.BackLog?.Id);
                else if (mc.BackLog != null)
                    UIHelper.OpenedBackLogs.Add(mc.BackLog.Id);
            };

            return mctrlbtem;
        }

        #endregion

    }
}
