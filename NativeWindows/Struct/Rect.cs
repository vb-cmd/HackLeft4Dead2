using System.Runtime.InteropServices;

namespace NativeWindows.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int
            Left,
            Top,
            Right,
            Bottom;
    }
}
