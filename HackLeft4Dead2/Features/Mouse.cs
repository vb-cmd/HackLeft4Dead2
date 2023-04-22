namespace HackLeft4Dead2.Features
{
    public static class Mouse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-mouseinput
        /// </summary>
        [Flags]
        private enum MouseEventFlags : uint
        {
            MOUSEEVENTF_MOVE = 0x0001,
            MOUSEEVENTF_LEFTDOWN = 0x0002,
            MOUSEEVENTF_LEFTUP = 0x0004,
            MOUSEEVENTF_RIGHTDOWN = 0x0008,
            MOUSEEVENTF_RIGHTUP = 0x0010,
            MOUSEEVENTF_MIDDLEDOWN = 0x0020,
            MOUSEEVENTF_MIDDLEUP = 0x0040,
            MOUSEEVENTF_XDOWN = 0x0080,
            MOUSEEVENTF_XUP = 0x0100,
            MOUSEEVENTF_WHEEL = 0x0800,
            MOUSEEVENTF_VIRTUALDESK = 0x4000,
            MOUSEEVENTF_ABSOLUTE = 0x8000
        }

        private static class ImportUser32
        {
            [DllImport("user32.dll")]
            public static extern void mouse_event(MouseEventFlags dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);
        }

        /// <summary>
        /// Send mouse move.
        /// </summary>
        public static void SetMouse(int x, int y)
        {
            ImportUser32.mouse_event(MouseEventFlags.MOUSEEVENTF_ABSOLUTE | MouseEventFlags.MOUSEEVENTF_MOVE, x, y, 0, 0);
        }

        /// <summary>
        /// Send mouse move.
        /// </summary>
        public static void SetMouse(Point point)
        {
            SetMouse(point.X, point.Y);
        }

        public static bool IsPressedLeftButton
            => Keyboard.IsPressedKey(VirtualKey.VK_LBUTTON);
    }
}
