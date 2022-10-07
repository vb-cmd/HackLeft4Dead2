using NativeWindows;
using NativeWindows.Struct;

namespace KeybordManagement
{
    public static class Keyboard
    {
        public static bool IsPressedSpace => IsPressedKey(VirtualKey.VK_SPACE);

        public static bool IsPressedKey(VirtualKey key)
        {
            return ImportUser32.GetAsyncKeyState(key) < 0;
        }
    }

}