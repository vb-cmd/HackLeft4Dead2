namespace Overlay.Import;

internal static class ImportUser32
{
    [DllImport("user32.dll", SetLastError = true)]
    public static extern nint FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool GetWindowRect(nint hwnd, out Rect lpRect);

    [DllImport("user32.dll")]
    public static extern nint GetForegroundWindow();


    [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
    public static extern int SetWindowLong32(nint hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
    public static extern nint SetWindowLongPtr64(nint hWnd, int nIndex, nint dwNewLong);



    [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
    public static extern nint GetWindowLongPtr32(nint hWnd, int nIndex);

    [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
    public static extern nint GetWindowLongPtr64(nint hWnd, int nIndex);
}

[StructLayout(LayoutKind.Sequential)]
internal struct Rect
{
    public int
        Left,
        Top,
        Right,
        Bottom;
}
