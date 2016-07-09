
using System;
using System.Drawing;
using System.Windows.Forms;
using WProject.GenericLibrary.Helpers;
using WProject.GenericLibrary.Helpers.Log;
using WProject.GenericLibrary.WinApi;
using WProject.UiLibrary.Classes;

namespace WProject.UiLibrary.Controls.Base
{
    public class WpBaseUserControl : UserControl
    {
        #region Events

        public event MouseEventHandler MouseClickOutside;

        #endregion

        #region Fields

        private static int hHook;
        private HookProc MouseHookProcedure;

        #endregion

        #region Properties

        //public virtual bool Dragable { get; set; }

        #endregion
        
        #region Constructors

        protected WpBaseUserControl()
        {
            AutoScaleMode = AutoScaleMode.None;
        }

        #endregion

        #region Overrides of UserControl

        protected override void OnLoad(EventArgs e)
        {
            if (!DesignMode)
            {
                MouseHookProcedure = MouseHookProc;

                hHook = User32.SetWindowsHookEx(Constants.WH_MOUSE, MouseHookProcedure, (IntPtr) 0, Kernel32.GetCurrentThreadId());

                if (hHook == 0)
                    Console.Write("Fail to hook window");
            }

            base.OnLoad(e);
        }

        #endregion

        #region Overrides of Control

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (DesignMode)
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Dashed);
        }

        #endregion

        #region Overrides of ContainerControl

        protected override void Dispose(bool disposing)
        {
            User32.SetWindowsHookEx(Constants.WH_MOUSE, (n, w, l) => 0, (IntPtr)0, Kernel32.GetCurrentThreadId());

            base.Dispose(disposing);
        }

        #endregion

        #region Private methods

        private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (Disposing)
                return 0;
            try
            {
                int mwp = wParam.ToInt32();
                if (nCode >= 0 && Utils.EqualsToAny(mwp, Constants.WM_LBUTTONUP, Constants.WM_MBUTTONUP, Constants.WM_RBUTTONUP))
                {
                    Point mousePosition = PointToClient(MousePosition);

                    if (Visible && !ClientRectangle.Contains(mousePosition))
                        MouseClickOutside?.Invoke(this,
                                                  new MouseEventArgs(Helpers.Utils.GetMouseButtonsFromMessage(mwp),
                                                                     1,
                                                                     mousePosition.X,
                                                                     mousePosition.Y,
                                                                     0));
                }

                return User32.CallNextHookEx(hHook, nCode, wParam, lParam);
            }
            catch (Exception mex)
            {
                Logger.Log(mex);
                return -1;
            }
        }

        #endregion
    }
}
