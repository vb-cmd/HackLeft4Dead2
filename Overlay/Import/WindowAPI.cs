namespace Overlay.Import;

internal static class WindowAPI
{
    public static nint FindWindow(string windowName)
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
    => handle == ImportUser32.GetForegroundWindow();


    public static nint SetWindowLongPtr(nint hWnd, int nIndex, nint dwNewLong)
    => nint.Size == 8 ? ImportUser32.SetWindowLongPtr64(hWnd, nIndex, dwNewLong) : new nint(ImportUser32.SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));

    public static nint GetWindowLongPtr(nint hWnd, int nIndex)
        => nint.Size == 8 ? ImportUser32.GetWindowLongPtr64(hWnd, nIndex) : ImportUser32.GetWindowLongPtr32(hWnd, nIndex);
}
