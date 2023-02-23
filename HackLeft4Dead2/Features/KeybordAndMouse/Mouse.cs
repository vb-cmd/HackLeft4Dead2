namespace HackLeft4Dead2.Features.KeybordAndMouse
{
    public static class Mouse
    {

        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-taginput
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct Input
        {
            [FieldOffset(0)] public SendInputEventType type;
            [FieldOffset(4)] public MouseInput mi;
            [FieldOffset(4)] public KeybdInput ki;
            [FieldOffset(4)] public HardwareInput hi;
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-taginput
        /// </summary>
        private enum SendInputEventType
        {
            InputMouse,
            InputKeyboard,
            InputHardware
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-mouseinput
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct MouseInput
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public MouseEventFlags dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-keybdinput
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct KeybdInput
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-hardwareinput
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct HardwareInput
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

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

            /// <summary>
            /// Synthesizes keystrokes, mouse motions, and button clicks.
            /// </summary>
            [DllImport("user32.dll", SetLastError = true)]
            public static extern uint SendInput(uint nInputs, ref Input pInputs, int cbSize);

            [DllImport("user32.dll")]
            public static extern bool SetCursorPos(int x, int y);
        }

        /// <summary>
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
