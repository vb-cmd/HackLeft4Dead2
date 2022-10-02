using NativeWindows;
using NativeWindows.Struct;

namespace KeybordManagement
{
    public static class Keyboard
    {
        public static bool IsPressedSpace => ImportUser32.GetAsyncKeyState(VirtualKey.SPACE) < 0;

        public static bool IsPressedKey(VirtualKey key)
        {
            return ImportUser32.GetAsyncKeyState(key) < 0;
        }
    }

}