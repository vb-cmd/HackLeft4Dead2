using NativeWindows;
using NativeWindows.Struct;

namespace Overlay.Sys
{
    internal static class WindowAPI
    {
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
