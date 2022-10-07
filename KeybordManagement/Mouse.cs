using NativeWindows;
using NativeWindows.Struct;
using System.Drawing;
using System.Runtime.InteropServices;

namespace KeybordManagement
{
    public static class Mouse
    {  /// <summary>
       /// Send mouse left down.
       /// </summary>
        public static void MouseLeftDown()
        {
            var mouseMoveInput = new Input
            {
                type = SendInputEventType.InputMouse,
                mi =
                {
                    dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTDOWN
                },
            };
            ImportUser32.SendInput(1, ref mouseMoveInput, Marshal.SizeOf<Input>());
        }

        /// <summary>
        /// Send mouse left up.
        /// </summary>
        public static void MouseLeftUp()
        {
            var mouseMoveInput = new Input
            {
                type = SendInputEventType.InputMouse,
                mi =
                {
                    dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTUP
                },
            };
            ImportUser32.SendInput(1, ref mouseMoveInput, Marshal.SizeOf<Input>());
        }

        /// <summary>
        /// Send mouse move.
        /// </summary>
        public static void MouseMove(int deltaX, int deltaY)
        {
            var mouseMoveInput = new Input
            {
                type = SendInputEventType.InputMouse,
                mi =
                {
                    dwFlags = MouseEventFlags.MOUSEEVENTF_ABSOLUTE|MouseEventFlags.MOUSEEVENTF_MOVE,
                    dx = deltaX,
                    dy = deltaY,
                },
            };
            ImportUser32.SendInput(1, ref mouseMoveInput, Marshal.SizeOf<Input>());
        }

        /// <summary>
        /// Send mouse move.
        /// </summary>
        public static void SetMouse(int deltaX, int deltaY, int sx, int sy)
        {
            int x = deltaX * (65536 / 10) / sx;
            int y = deltaY * (65536 / 10) / sy;

            ImportUser32.mouse_event(MouseEventFlags.MOUSEEVENTF_ABSOLUTE | MouseEventFlags.MOUSEEVENTF_MOVE, x, y, 0, 0);
        }

        public static bool SetCursorPosition(int x, int y)
        {
            return ImportUser32.SetCursorPos(x, y);
        }
        public static bool SetCursorPosition(Point point)
        {
            return SetCursorPosition(point.X, point.Y);
        }
        public static bool SetCursorPosition(PointF point)
        {
            return SetCursorPosition((int)point.X, (int)point.Y);
        }

        public static bool IsPressedLeftButton
            => Keyboard.IsPressedKey(VirtualKey.VK_LBUTTON);
    }
}
