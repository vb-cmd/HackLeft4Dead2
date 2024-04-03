namespace Device.Import;

internal static class ImportUser32
{
    // DLL libraries used to manage hotkeys
    [DllImport("User32.dll")]
    public static extern short GetAsyncKeyState(VirtualKey ArrowKeys);

    [DllImport("user32.dll")]
    public static extern void mouse_event(MouseEventFlags dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);
}
