namespace Overlay.Import
{
    internal static class WindowAPI
    {

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int
                Left,
                Top,
                Right,
                Bottom;
        }
        private static class ImportUser32
        {
            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool GetWindowRect(IntPtr hwnd, out Rect lpRect);

            [DllImport("user32.dll")]
            public static extern IntPtr GetForegroundWindow();


            [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
            public static extern int SetWindowLong32(IntPtr hWnd, int nIndex, int dwNewLong);

            [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
            public static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);



            [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
            public static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, int nIndex);

            [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
            public static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);
        }

        public static IntPtr FindWindow(string windowName)
           => ImportUser32.FindWindow(null, windowName);

        public static Rectangle GetWindowRectangle(nint hwnd)
        {
            if (ImportUser32.GetWindowRect(hwnd, out Rect sizeWindowGame))
            {
                return new Rectangle
                {
                    Size = new Size(sizeWindowGame.Right - sizeWindowGame.Left, sizeWindowGame.Bottom - sizeWindowGame.Top),
                    Location = new Point(sizeWindowGame.Left, sizeWindowGame.Top),
                };
            }
            else
            {
                return Rectangle.Empty;
            }
        }

        public static bool GetForegroundWindowCurrent(nint handle)
        {
            return handle == ImportUser32.GetForegroundWindow();
        }

        public static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        => IntPtr.Size == 8 ? ImportUser32.SetWindowLongPtr64(hWnd, nIndex, dwNewLong) : new IntPtr(ImportUser32.SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));

        public static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
            => IntPtr.Size == 8 ? ImportUser32.GetWindowLongPtr64(hWnd, nIndex) : ImportUser32.GetWindowLongPtr32(hWnd, nIndex);
            
    }
}
