﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.Controls;
using WProject.Controls.MainPageControls;
using WProject.GenericLibrary.Constants;
using WProject.GenericLibrary.Exceptions;
using WProject.GenericLibrary.Helpers.Log;
using WProject.GenericLibrary.WinApi;
using WProject.UiLibrary.Annotations;
using WProject.UiLibrary.Controls;
using WProject.UiLibrary.Theme;

namespace WProject.Helpers
{
    public enum ShowInFormControlSize
    {
        MainFormSize,
        ControlSize    
    }

    public static class UIHelper
    {
        public const int BACKLOG_COLOR_BAR_WIDTH = 6;
        public const int TASK_COLOR_BAR_WIDTH = 6;
        public const string ApplicationName = "WProject";

        public static List<int> OpenedBackLogs { get; }

        private static WpLoaderControl _loaderControl;

        public static ctrlHeader HeaderControl { get; set; }

        public static ctrlMainPanel MainPanel { get; set; }

        public static ctrlStatusBar StatusBar { get; set; }

        public static frmMain MainForm { get; set; }

        static UIHelper()
        {
            OpenedBackLogs = new List<int>();
        }

        public static void RunOnUiThread(Action action)
        {
            if(action == null)
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

        public static void CloseApplication()
        {
            Environment.Exit(0);
        }

        public static void ShowError(WpException exception, Form parent = null)
        {
            ShowError("ERROR : " + exception.Message + "\n" +
                      "ERROR CODE : " + exception.ErrorCode + "\n" +
                      (!string.IsNullOrEmpty(exception.Metadata) ? "METADATA : " + exception.Metadata : string.Empty),
                      parent);
        }
        
        public static void ShowError(Exception exception, Form parent = null)
        {
            ShowError("ERROR : " + exception.Message + "\n",
                      parent);
        }

        public static void ShowError(string error, Form parent = null)
        {
            parent = parent ?? MainForm;
            MessageBox.Show(parent, error, GeneralConstants.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowLoader(string text = "", Form parent = null)
        {
            if(_loaderControl == null)
                _loaderControl = new WpLoaderControl
                {
                    Visible = false
                };

            var mp = MainForm;

            if(mp == null)
                return;

            if (mp != _loaderControl.ParentForm)
                User32.SetParent(_loaderControl.Handle, mp.Handle);
                //mp.Controls.Add(_loaderControl);

            _loaderControl.BackColor = Color.DarkGray;

            if (mp.ClientSize != _loaderControl.Size)
                _loaderControl.Size = mp.Size;

            if(_loaderControl.Location != Point.Empty)
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

        public static void ShowTaskEditor(int taskId,
                                          Action<WebApiClasses.Classes.Task> onSave,
                                          Action onClose = null,
                                          Action onFollow = null,
                                          Form parentForm = null)
        {
            var mc = new ctrlTaskEditor(taskId);

            mc.OnClose = () =>
            {
                onClose?.Invoke();

                mc.ParentForm?.Close();
            };

            mc.Style = null;
            ShowControlInForm(mc, ShowInFormControlSize.ControlSize, parentForm:parentForm);
        }

        public static void ShowControlInForm(Control control, ShowInFormControlSize size, Color? borderColor = null, Form parentForm = null)
        {
            var mform = new ChildForm(borderColor ?? WpThemeColors.Purple)
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterParent
            };

            if (size == ShowInFormControlSize.MainFormSize)
                mform.Size = Program.MainForm.Size;
            else
                mform.Size = control.Size + new Size((int)mform.BorderWidth * 2, (int)mform.BorderWidth + mform.TitleHeight);
            
            control.Location = new Point((int) mform.BorderWidth, mform.TitleHeight);
            control.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            mform.Controls.Add(control);
            mform.Paint += ChildFormPaint;

            if (parentForm != null)
            {
                //User32.SetParent(mform.Handle, parentForm.Handle);
                mform.ShowDialog(parentForm);
            }
            else
                mform.ShowDialog();

        }

        private static void ChildFormPaint(object sender, PaintEventArgs e)
        {
            var mchildForm = sender as ChildForm;
            if (mchildForm == null || !mchildForm.DrawBorder)
                return;

            e.Graphics.FillRectangle(mchildForm.BorderBrush, new Rectangle(0, 0, mchildForm.Width, mchildForm.TitleHeight));
            e.Graphics.DrawRectangle(mchildForm.BorderPen, mchildForm.DrawBorderRect);
        
        }

        public static async Task PerformLogout()
        {
            return;
        }
    }
}
