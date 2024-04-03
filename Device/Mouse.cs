namespace Device;

public static class Mouse
{

    /// <summary>
    /// Send mouse move.
    /// </summary>
    public static void SetMouse(int x, int y)
    {
        ImportUser32.mouse_event(MouseEventFlags.MOUSEEVENTF_MOVE, x, y, 0, 0);
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
