using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WProject.Controls;
using WProject.Controls.MainPageControls;
using WProject.Controls.MainPageControls.Admin_controls;
using WProject.GenericLibrary.Constants;
using WProject.GenericLibrary.Exceptions;
using WProject.GenericLibrary.Helpers.Drawing;
using WProject.GenericLibrary.Helpers.Log;
using WProject.GenericLibrary.WinApi;
using WProject.UiLibrary.Annotations;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Helpers;
using WProject.UiLibrary.Style;
using WProject.UiLibrary.Theme;
using WProject.WebApiClasses.Classes;
using Task = System.Threading.Tasks.Task;

namespace WProject.Helpers
{
    public enum ShowInFormControlSize
    {
        MainFormSize,
        ControlSize    
    }

    public static class UIHelper
    {
        #region Constants

        public const int BACKLOG_COLOR_BAR_WIDTH = 6;
        public const int TASK_COLOR_BAR_WIDTH = 6;
        public const string ApplicationName = "WProject";

        #endregion

        #region Properties

        public static List<int> OpenedBackLogs { get; }

        private static WpLoaderControl _loaderControl;

        public static ctrlHeader HeaderControl { get; set; }

        public static ctrlMainPanel MainPanel { get; set; }

        public static ctrlStatusBar StatusBar { get; set; }

        public static frmMain MainForm { get; set; }

        #endregion

        #region Contructors

        static UIHelper()
        {
            OpenedBackLogs = new List<int>();
        }

        #endregion

        #region General methods

        public static void RunOnUiThread(Action action)
        {
            if (action == null)
                return;

            try
            {
                if (MainForm == null)
                    action();
                else if (MainForm.InvokeRequired)
                    MainForm.Invoke(action);
                else
                    action();

            }
            catch (Exception mex)
            {
                Logger.Log(mex);
            }

        }

        public static void CloseApplication(string reason = null)
        {
            CloseApplication(0, reason);
        }

        public static void CloseApplication(int exitCode, string reason = null)
        {
            Logger.Log($"Application was closed. Reason : {reason}");
            Environment.Exit(0);
        }

        public static void UpdateStatusBarTexts()
        {
            MainPanel.UpdateStatusBar();
        }

        public static int GetTopMostItem(Control panel, Direction direction)
        {
            var mcl = panel.Controls
                        .OfType<Control>();


            IEnumerable<int> mlv;
            switch (direction)
            {
                case Direction.Left:
                    mlv = mcl.Select(c => c.Left);
                    break;
                case Direction.Up:
                    mlv = mcl.Select(c => c.Top);
                    break;
                case Direction.Right:
                    mlv = mcl.Select(c => c.Right);
                    break;
                case Direction.Down:
                    mlv = mcl.Select(c => c.Bottom);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            if (direction == Direction.Up || direction == Direction.Left)
                return mlv.DefaultIfEmpty(0).Min();

            return mlv.DefaultIfEmpty(0).Max();
        }

        #endregion

        #region Forms

        public static void ShowError(WpException exception, Form parent = null)
        {
            ShowError("ERROR : " + exception.Message + "\n" + "ERROR CODE : " + exception.ErrorCode + "\n" + (!string.IsNullOrEmpty(exception.Metadata) ? "METADATA : " + exception.Metadata : string.Empty), parent);
        }

        public static void ShowError(Exception exception, Form parent = null)
        {
            ShowError("ERROR : " + exception.Message + "\n", parent);
        }

        public static void ShowError(string error, Form parent = null)
        {
            parent = parent ?? MainForm;
            MessageBox.Show(parent, error, GeneralConstants.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowLoader(string text = "", Form parent = null)
        {
            if (_loaderControl == null)
                _loaderControl = new WpLoaderControl
                {
                    Visible = false
                };

            var mp = MainForm;

            if (mp == null)
                return;

            if (mp != _loaderControl.ParentForm)
                User32.SetParent(_loaderControl.Handle, mp.Handle);
            //mp.Controls.Add(_loaderControl);

            _loaderControl.BackColor = Color.DarkGray;

            if (mp.ClientSize != _loaderControl.Size)
                _loaderControl.Size = mp.Size;

            if (_loaderControl.Location != Point.Empty)
                _loaderControl.Location = Point.Empty;

            _loaderControl.SetLoaderText(text);

            //_loaderControl.BringToFront();
            //_loaderControl.Visible = true;
        }

        public static void HideLoader()
        {
            if (_loaderControl != null && _loaderControl.Visible)
                _loaderControl.Visible = false;
        }

        public static void ShowTaskEditor(WebApiClasses.Classes.Task task, Func<WebApiClasses.Classes.Task, Task> onSave, Action onClose = null, Action onFollow = null, Form parentForm = null)
        {
            var mc = new ctrlTaskEditor(task);

            mc.OnSave = async ntask =>
            {
                if (onSave != null)
                    await onSave(ntask);

                mc.ParentForm?.Close();
            };

            mc.OnClose = () =>
            {
                onClose?.Invoke();

                mc.ParentForm?.Close();
            };

            mc.Style = null;
            ShowControlInForm(mc, ShowInFormControlSize.ControlSize, parentForm: parentForm);
        }

        public static void ShowBackLogEditor(Backlog backlog, Func<Backlog, Task> onSave = null, Action onClose = null, Form parentForm = null)
        {
            var mc = new ctrlBacklogEditor(backlog);

            mc.OnSave = async mbacklog =>
            {
                if (onSave != null)
                    await onSave(mbacklog);

                mc.ParentForm?.Close();
            };

            mc.OnClose = () =>
            {
                onClose?.Invoke();

                mc.ParentForm?.Close();
            };

            mc.Style = null;
            ShowControlInForm(mc, ShowInFormControlSize.ControlSize, parentForm: parentForm);
        }

        public static void ShowControlInForm(Control control, ShowInFormControlSize size, Color? borderColor = null, Form parentForm = null)
        {
            var mform = new ChildForm(borderColor ?? WpThemeColors.Purple)
            {
                FormBorderStyle = FormBorderStyle.None, StartPosition = FormStartPosition.CenterParent
            };

            if (size == ShowInFormControlSize.MainFormSize)
                mform.Size = Program.MainForm.Size;
            else
                mform.Size = control.Size + new Size((int) mform.BorderWidth*2, (int) mform.BorderWidth + mform.TitleHeight);

            control.Location = new Point((int) mform.BorderWidth, mform.TitleHeight);
            control.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            mform.Controls.Add(control);
            mform.Paint += ChildFormPaint;

            try
            {
                MainForm.ShowOverlay();

                if (parentForm != null)
                {
                    //User32.SetParent(mform.Handle, parentForm.Handle);
                    mform.ShowDialog(parentForm);
                }
                else
                    mform.ShowDialog();
            }
            finally
            {
                MainForm.ShowOverlay(false);
            }
        }

        private static void ChildFormPaint(object sender, PaintEventArgs e)
        {
            var mchildForm = sender as ChildForm;
            if (mchildForm == null || !mchildForm.DrawBorder)
                return;

            e.Graphics.FillRectangle(mchildForm.BorderBrush, new Rectangle(0, 0, mchildForm.Width, mchildForm.TitleHeight));
            e.Graphics.DrawRectangle(mchildForm.BorderPen, mchildForm.DrawBorderRect);
        }

        #endregion

        #region Connection methods

        public static async Task PerformLogout()
        {
            return;
        }

        public static async void RefreshDashboard()
        {
            var mctrl = MainPanel?.GetPage(Pages.DashBoard) as ctrlDashBoard;
            if (mctrl == null)
                return;

            await mctrl.RefreshTasks();
        }

        public static void ExecuteServerMethod(string data, Action action, string method)
        {
            RunOnUiThread(() =>
            {
                Logger.Log($"Run method {method} with data : {data}");

                action?.Invoke();
            });
        }

        public static void ExecuteServerMethod(string data, Action<string> action, string method)
        {
            RunOnUiThread(() =>
            {
                Logger.Log($"Run method {method} with data (send to action) : {data}");

                action?.Invoke(data);
            });
        }

        #endregion

        #region Default method themes

        public static void SetStylForDropDowns(params WpStyledControl[] dropDowns)
        {
            if (dropDowns == null)
                return;

            var mstyle = new UiStyle
            {
                NormalStyle = new Style
                {
                    BackColor = Color.Transparent, ForeColor = Color.Black, Padding = new Padding(0, 3, 0, 0), BorderColor = WpThemeColors.Teal.SetOpacity(60), BorderWidth = 1f
                },
                HoverStyle = new Style
                {
                    BackColor = Color.Transparent, ForeColor = Color.Black, Padding = new Padding(0, 3, 0, 0), BorderColor = WpThemeColors.Teal, BorderWidth = 1f, Cursor = Cursors.Hand
                }
            };

            foreach (var mdropDown in dropDowns.Where(dd => dd != null))
                mdropDown.Style = mstyle.Clone();
        }

        #endregion

        #region Admin forms

        public static void ShowUserEdit(User user, Func<User, Task> afterSave = null)
        {
            var mc = new ctrlUserEdit(user);

            mc.AfterSave = async u =>
            {
                if (afterSave != null)
                    await afterSave(u);

                mc.ParentForm?.Close();
            };

            ShowControlInForm(mc, ShowInFormControlSize.ControlSize);
        }

        public static void ShowGroupEdit(Group group, Func<Group, Task> afterSave = null)
        {
            var mc = new ctrlGroupEdit(group);

            mc.AfterSave = async g =>
            {
                if (afterSave != null)
                    await afterSave(g);

                mc.ParentForm?.Close();
            };

            ShowControlInForm(mc, ShowInFormControlSize.ControlSize);
        }

        public static void ShowProjectEdit(Project project, Func<Project, Task> afterSave = null)
        {
            var mc = new ctrlProjectEdit(project);

            mc.AfterSave = async p =>
            {
                if (afterSave != null)
                    await afterSave(p);

                mc.ParentForm?.Close();
            };

            ShowControlInForm(mc, ShowInFormControlSize.ControlSize);
        }

        public static void ShowSpringEdit(Tuple<Spring, Category> tuple,
                                          Tuple<Project, Spring, Category> newData,
                                          Func<Tuple<Spring, Category>, Task> afterSave = null)
        {
            var mc = new ctrlSpringEdit(tuple)
            {
                NewData = newData
            };

            mc.AfterSave = async p =>
            {
                if (afterSave != null)
                    await afterSave(p);

                mc.ParentForm?.Close();
            };

            ShowControlInForm(mc, ShowInFormControlSize.ControlSize);
        }

        #endregion

        public static void ShowConfirmWindow(string title, string text, string key, Action action)
        {
            var mc = new ctrlConfirmAction
            {
                TextConfirm = text,
                Text = title,
                ConfirmKey = key,
                ConfirmAction = action
            };

            ShowControlInForm(mc, ShowInFormControlSize.ControlSize);
        }
    }
}
