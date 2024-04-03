namespace Device;

public static class Keyboard
{
    public static bool IsPressedSpace => IsPressedKey(VirtualKey.VK_SPACE);

    internal static bool IsPressedKey(VirtualKey key)
    {
        return ImportUser32.GetAsyncKeyState(key) < 0;
    }
}