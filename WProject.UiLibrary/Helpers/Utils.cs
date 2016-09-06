using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.GenericLibrary.WinApi;

namespace WProject.UiLibrary.Helpers
{
    [Flags]
    public enum Direction
    {
        Left,
        Up, 
        Right,
        Down,
        Horizontal = Left | Right,
        Vertical = Up | Down,
        All = Horizontal | Vertical
    }

    public static class Utils
    {
        public static MouseButtons GetMouseButtonsFromMessage(int wm_button)
        {
            switch (wm_button)
            {
                case Constants.WM_LBUTTONUP:
                    return MouseButtons.Left;
                case Constants.WM_MBUTTONUP:
                    return MouseButtons.Middle;
                case Constants.WM_RBUTTONUP:
                    return MouseButtons.Right;
                default:
                    return MouseButtons.None;
            }
        }

        public static Padding Clone(this Padding padding)
        {
            return new Padding(padding.Left, padding.Top, padding.Right, padding.Bottom);
        }

        public static Padding SetPadding(this Padding padding, int value, Direction direction)
        {
            var mnewPadding = padding.Clone();
            if (direction.HasFlag(Direction.Left))
                mnewPadding = new Padding(value, mnewPadding.Top, mnewPadding.Right, mnewPadding.Bottom);
            if (direction.HasFlag(Direction.Up))
                mnewPadding = new Padding(mnewPadding.Left, value, mnewPadding.Right, mnewPadding.Bottom);
            if (direction.HasFlag(Direction.Right))
                mnewPadding = new Padding(mnewPadding.Left, mnewPadding.Top, value, mnewPadding.Bottom);
            if (direction.HasFlag(Direction.Down))
                mnewPadding = new Padding(mnewPadding.Left, mnewPadding.Top, mnewPadding.Right, value);

            return mnewPadding;
        }

        public static void DrawBorder(this Control control)
        {
            control.Paint += DrawBorderHandler;
            control.Refresh();
        }

        public static void RemoveBorder(this Control control)
        {
            control.Paint -= DrawBorderHandler;
            control.Refresh();
        }

        private static void DrawBorderHandler(object sender, PaintEventArgs args)
        {
            var mc = sender as Control;

            if (mc != null)
                ControlPaint.DrawBorder(args.Graphics, mc.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        }
    }
}
