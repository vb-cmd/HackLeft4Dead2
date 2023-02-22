using System;
using System.Runtime.InteropServices;

namespace KeybordAndMouse
{
    public static class Keyboard
    {
        private static class ImportUser32
        {
            // DLL libraries used to manage hotkeys
            [DllImport("User32.dll")]
            public static extern short GetAsyncKeyState(VirtualKey ArrowKeys);
        }

        public static bool IsPressedSpace => IsPressedKey(VirtualKey.VK_SPACE);

        public static bool IsPressedKey(VirtualKey key)
        {
            return ImportUser32.GetAsyncKeyState(key) < 0;
        }
    }

    /// <summary>
    /// The following table shows the symbolic constant names, hexadecimal values, and mouse or keyboard equivalents for the virtual-key codes used by the system. The codes are listed in numeric order.
    ///
    /// https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
    /// </summary>
    [Flags]
    public enum VirtualKey
    {
        /// <summary> 
        ///Left mouse button
        ///
        VK_LBUTTON = 0x01,

        /// <summary>
        /// Right mouse button
        /// </summary>
        VK_RBUTTON = 0x02,

        /// <summary> 
        ///Control-break processing
        ///
        VK_CANCEL = 0x03,

        /// <summary> 
        ///Middle mouse button (three-button mouse)
        ///
        VK_MBUTTON = 0x04,

        /// <summary> 
        ///X1 mouse button///
        VK_XBUTTON1 = 0x05,

        /// <summary> 
        ///X2 mouse button///
        VK_XBUTTON2 = 0x06,

        /// <summary> 
        ///BACKSPACE key///
        VK_BACK = 0x08,

        /// <summary> 
        ///TAB key///
        VK_TAB = 0x09,

        /// <summary> 
        ///CLEAR key///
        VK_CLEAR = 0x0C,

        /// <summary> 
        ///ENTER key///
        VK_RETURN = 0x0D,

        /// <summary> 
        ///SHIFT key///
        VK_SHIFT = 0x10,

        /// <summary> 
        ///CTRL key///
        VK_CONTROL = 0x11,

        /// <summary> 
        ///ALT key///
        VK_MENU = 0x12,

        /// <summary> 
        ///PAUSE key///
        VK_PAUSE = 0x13,

        /// <summary> 
        ///CAPS LOCK key///
        VK_CAPITAL = 0x14,

        /// <summary> 
        ///IME Kana mode///
        VK_KANA = 0x15,

        /// <summary> 
        ///IME Hanguel mode (maintained for compatibility; use VK_HANGUL)///
        VK_HANGUEL = 0x15,

        /// <summary> 
        ///IME Hangul mode///
        VK_HANGUL = 0x15,

        /// <summary> 
        ///IME Junja mode///
        VK_JUNJA = 0x17,

        /// <summary> 
        ///IME final mode///
        VK_FINAL = 0x18,

        /// <summary> 
        ///IME Hanja mode///
        VK_HANJA = 0x19,

        /// <summary> 
        ///IME Kanji mode///
        VK_KANJI = 0x19,

        /// <summary> 
        ///ESC key///
        VK_ESCAPE = 0x1B,

        /// <summary> 
        ///IME convert///
        VK_CONVERT = 0x1C,

        /// <summary> 
        ///IME nonconvert///
        VK_NONCONVERT = 0x1D,

        /// <summary> 
        ///IME accept///
        VK_ACCEPT = 0x1E,

        /// <summary> 
        ///IME mode change request///
        VK_MODECHANGE = 0x1F,

        /// <summary> 
        ///SPACEBAR///
        VK_SPACE = 0x20,

        /// <summary> 
        ///PAGE UP key///
        VK_PRIOR = 0x21,

        /// <summary> 
        ///PAGE DOWN key///
        VK_NEXT = 0x22,

        /// <summary> 
        ///END key///
        VK_END = 0x23,

        /// <summary> 
        ///HOME key///
        VK_HOME = 0x24,

        /// <summary> 
        ///LEFT ARROW key///
        VK_LEFT = 0x25,

        /// <summary> 
        ///UP ARROW key///
        VK_UP = 0x26,

        /// <summary> 
        ///RIGHT ARROW key///
        VK_RIGHT = 0x27,

        /// <summary> 
        ///DOWN ARROW key
        ///
        VK_DOWN = 0x28,

        /// <summary> 
        ///SELECT key
        ///
        VK_SELECT = 0x29,

        /// <summary> 
        ///PRINT key
        ///
        VK_PRINT = 0x2A,

        /// <summary> 
        ///EXECUTE key
        ///
        VK_EXECUTE = 0x2B,

        /// <summary> 
        ///PRINT SCREEN key
        ///
        VK_SNAPSHOT = 0x2C,

        /// <summary> 
        ///INS key
        ///
        VK_INSERT = 0x2D,

        /// <summary> 
        ///DEL key
        ///
        VK_DELETE = 0x2E,

        /// <summary> 
        ///HELP key
        ///
        VK_HELP = 0x2F,

        /// <summary> 
        ///0 key
        ///
        K_0 = 0x30,

        /// <summary> 
        ///1 key
        ///
        K_1 = 0x31,

        /// <summary> 
        ///2 key
        ///
        K_2 = 0x32,

        /// <summary> 
        ///3 key
        ///
        K_3 = 0x33,

        /// <summary> 
        ///4 key
        ///
        K_4 = 0x34,

        /// <summary> 
        ///5 key
        ///
        K_5 = 0x35,

        /// <summary> 
        ///6 key
        ///
        K_6 = 0x36,

        /// <summary> 
        ///7 key
        ///
        K_7 = 0x37,

        /// <summary> 
        ///8 key
        ///
        K_8 = 0x38,

        /// <summary> 
        ///9 key
        ///
        K_9 = 0x39,

        /// <summary> 
        ///A key
        ///
        K_A = 0x41,

        /// <summary> 
        ///B key
        ///
        K_B = 0x42,

        /// <summary> 
        ///C key
        ///
        K_C = 0x43,

        /// <summary> 
        ///D key
        ///
        K_D = 0x44,

        /// <summary> 
        ///E key
        ///
        K_E = 0x45,

        /// <summary> 
        ///F key
        ///
        K_F = 0x46,

        /// <summary> 
        ///G key
        ///
        K_G = 0x47,

        /// <summary> 
        ///H key
        ///
        K_H = 0x48,

        /// <summary> 
        ///I key
        ///
        K_I = 0x49,

        /// <summary> 
        ///J key
        ///
        K_J = 0x4A,

        /// <summary> 
        ///K key
        ///
        K_K = 0x4B,

        /// <summary> 
        ///L key
        ///
        K_L = 0x4C,

        /// <summary> 
        ///M key
        ///
        K_M = 0x4D,

        /// <summary> 
        ///N key
        ///
        K_N = 0x4E,

        /// <summary> 
        ///O key
        ///
        K_O = 0x4F,

        /// <summary> 
        ///P key
        ///
        K_P = 0x50,

        /// <summary> 
        ///Q key
        ///
        K_Q = 0x51,

        /// <summary> 
        ///R key
        ///
        K_R = 0x52,

        /// <summary> 
        ///S key
        ///
        K_S = 0x53,

        /// <summary> 
        ///T key
        ///
        K_T = 0x54,

        /// <summary> 
        ///U key
        ///
        K_U = 0x55,

        /// <summary> 
        ///V key
        ///
        K_V = 0x56,

        /// <summary> 
        ///W key
        ///
        K_W = 0x57,

        /// <summary> 
        ///X key
        ///
        K_X = 0x58,

        /// <summary> 
        ///Y key
        ///
        K_Y = 0x59,

        /// <summary> 
        ///Z key
        ///
        K_Z = 0x5A,

        /// <summary> 
        ///Left Windows key (Natural keyboard)
        ///
        VK_LWIN = 0x5B,

        /// <summary> 
        ///Right Windows key (Natural keyboard)
        ///
        VK_RWIN = 0x5C,

        /// <summary> 
        ///Applications key (Natural keyboard)
        ///
        VK_APPS = 0x5D,

        /// <summary> 
        ///Computer Sleep key
        ///
        VK_SLEEP = 0x5F,

        /// <summary> 
        ///Numeric keypad 0 key
        ///
        VK_NUMPAD0 = 0x60,

        /// <summary> 
        ///Numeric keypad 1 key
        ///
        VK_NUMPAD1 = 0x61,

        /// <summary> 
        ///Numeric keypad 2 key
        ///
        VK_NUMPAD2 = 0x62,

        /// <summary> 
        ///Numeric keypad 3 key
        ///
        VK_NUMPAD3 = 0x63,

        /// <summary> 
        ///Numeric keypad 4 key
        ///
        VK_NUMPAD4 = 0x64,

        /// <summary> 
        ///Numeric keypad 5 key
        ///
        VK_NUMPAD5 = 0x65,

        /// <summary> 
        ///Numeric keypad 6 key
        ///
        VK_NUMPAD6 = 0x66,

        /// <summary> 
        ///Numeric keypad 7 key
        ///
        VK_NUMPAD7 = 0x67,

        /// <summary> 
        ///Numeric keypad 8 key
        ///
        VK_NUMPAD8 = 0x68,

        /// <summary> 
        ///Numeric keypad 9 key
        ///
        VK_NUMPAD9 = 0x69,

        /// <summary> 
        ///Multiply key
        ///
        VK_MULTIPLY = 0x6A,

        /// <summary> 
        ///Add key
        ///
        VK_ADD = 0x6B,

        /// <summary> 
        ///Separator key
        ///
        VK_SEPARATOR = 0x6C,

        /// <summary> 
        ///Subtract key
        ///
        VK_SUBTRACT = 0x6D,

        /// <summary> 
        ///Decimal key
        ///
        VK_DECIMAL = 0x6E,

        /// <summary> 
        ///Divide key
        ///
        VK_DIVIDE = 0x6F,

        /// <summary> 
        ///F1 key
        ///
        VK_F1 = 0x70,

        /// <summary> 
        ///F2 key
        ///
        VK_F2 = 0x71,

        /// <summary> 
        ///F3 key
        ///
        VK_F3 = 0x72,

        /// <summary> 
        ///F4 key
        ///
        VK_F4 = 0x73,

        /// <summary> 
        ///F5 key
        ///
        VK_F5 = 0x74,

        /// <summary> 
        ///F6 key
        ///
        VK_F6 = 0x75,

        /// <summary> 
        ///F7 key
        ///
        VK_F7 = 0x76,

        /// <summary> 
        ///F8 key
        ///
        VK_F8 = 0x77,

        /// <summary> 
        ///F9 key
        ///
        VK_F9 = 0x78,

        /// <summary> 
        ///F10 key
        ///
        VK_F10 = 0x79,

        /// <summary> 
        ///F11 key
        ///
        VK_F11 = 0x7A,

        /// <summary> 
        ///F12 key
        ///
        VK_F12 = 0x7B,

        /// <summary> 
        ///F13 key
        ///
        VK_F13 = 0x7C,

        /// <summary> 
        ///F14 key
        ///
        VK_F14 = 0x7D,

        /// <summary> 
        ///F15 key
        ///
        VK_F15 = 0x7E,

        /// <summary> 
        ///F16 key
        ///
        VK_F16 = 0x7F,

        /// <summary> 
        ///F17 key
        ///
        VK_F17 = 0x80,

        /// <summary> 
        ///F18 key
        ///
        VK_F18 = 0x81,

        /// <summary> 
        ///F19 key
        ///
        VK_F19 = 0x82,

        /// <summary> 
        ///F20 key
        ///
        VK_F20 = 0x83,

        /// <summary> 
        ///F21 key
        ///
        VK_F21 = 0x84,

        /// <summary> 
        ///F22 key
        ///
        VK_F22 = 0x85,

        /// <summary> 
        ///F23 key
        ///
        VK_F23 = 0x86,

        /// <summary> 
        ///F24 key
        ///
        VK_F24 = 0x87,

        /// <summary> 
        ///NUM LOCK key
        ///
        VK_NUMLOCK = 0x90,

        /// <summary> 
        ///SCROLL LOCK key
        ///
        VK_SCROLL = 0x91,

        /// <summary> 
        ///Left SHIFT key
        ///
        VK_LSHIFT = 0xA0,

        /// <summary> 
        ///Right SHIFT key
        ///
        VK_RSHIFT = 0xA1,

        /// <summary> 
        ///Left CONTROL key
        ///
        VK_LCONTROL = 0xA2,

        /// <summary> 
        ///Right CONTROL key
        ///
        VK_RCONTROL = 0xA3,

        /// <summary> 
        ///Left MENU key
        ///
        VK_LMENU = 0xA4,

        /// <summary> 
        ///Right MENU key
        ///
        VK_RMENU = 0xA5,

        /// <summary> 
        ///Browser Back key
        ///
        VK_BROWSER_BACK = 0xA6,

        /// <summary> 
        ///Browser Forward key
        ///
        VK_BROWSER_FORWARD = 0xA7,

        /// <summary> 
        ///Browser Refresh key
        ///
        VK_BROWSER_REFRESH = 0xA8,

        /// <summary> 
        ///Browser Stop key
        ///
        VK_BROWSER_STOP = 0xA9,

        /// <summary> 
        ///Browser Search key
        ///
        VK_BROWSER_SEARCH = 0xAA,

        /// <summary> 
        ///Browser Favorites key
        ///
        VK_BROWSER_FAVORITES = 0xAB,

        /// <summary> 
        ///Browser Start and Home key
        ///
        VK_BROWSER_HOME = 0xAC,

        /// <summary> 
        ///Volume Mute key
        ///
        VK_VOLUME_MUTE = 0xAD,

        /// <summary> 
        ///Volume Down key
        ///
        VK_VOLUME_DOWN = 0xAE,

        /// <summary> 
        ///Volume Up key
        ///
        VK_VOLUME_UP = 0xAF,

        /// <summary> 
        ///Next Track key
        ///
        VK_MEDIA_NEXT_TRACK = 0xB0,

        /// <summary> 
        ///Previous Track key
        ///
        VK_MEDIA_PREV_TRACK = 0xB1,

        /// <summary> 
        ///Stop Media key
        ///
        VK_MEDIA_STOP = 0xB2,

        /// <summary> 
        ///Play/Pause Media key
        ///
        VK_MEDIA_PLAY_PAUSE = 0xB3,

        /// <summary> 
        ///Start Mail key
        ///
        VK_LAUNCH_MAIL = 0xB4,

        /// <summary> 
        ///Select Media key
        ///
        VK_LAUNCH_MEDIA_SELECT = 0xB5,

        /// <summary> 
        ///Start Application 1 key
        ///
        VK_LAUNCH_APP1 = 0xB6,

        /// <summary> 
        ///Start Application 2 key
        ///
        VK_LAUNCH_APP2 = 0xB7,

        /// <summary> 
        ///Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ';:' key
        ///
        VK_OEM_1 = 0xBA,

        /// <summary> 
        ///For any country/region, the '+' key
        ///
        VK_OEM_PLUS = 0xBB,

        /// <summary> 
        ///For any country/region, the ',' key
        ///
        VK_OEM_COMMA = 0xBC,

        /// <summary> 
        ///For any country/region, the '-' key
        ///
        VK_OEM_MINUS = 0xBD,

        /// <summary> 
        ///For any country/region, the '.' key
        ///
        VK_OEM_PERIOD = 0xBE,

        /// <summary> 
        ///Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '/?' key
        ///
        VK_OEM_2 = 0xBF,

        /// <summary> 
        ///Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '`~' key
        ///
        VK_OEM_3 = 0xC0,

        /// <summary> 
        ///Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '[{' key
        ///
        VK_OEM_4 = 0xDB,

        /// <summary> 
        ///Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '\\|' key
        ///
        VK_OEM_5 = 0xDC,

        /// <summary> 
        ///Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ']}' key
        ///
        VK_OEM_6 = 0xDD,

        /// <summary> 
        ///Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the 'single-quote/double-quote' key
        ///
        VK_OEM_7 = 0xDE,

        /// <summary> 
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///
        VK_OEM_8 = 0xDF,

        /// <summary> 
        ///Either the angle bracket key or the backslash key on the RT 102-key keyboard
        ///
        VK_OEM_102 = 0xE2,

        /// <summary> 
        ///IME PROCESS key
        ///
        VK_PROCESSKEY = 0xE5,

        /// <summary> 
        ///Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
        ///
        VK_PACKET = 0xE7,

        /// <summary> 
        ///Attn key
        ///
        VK_ATTN = 0xF6,

        /// <summary> 
        ///CrSel key
        ///
        VK_CRSEL = 0xF7,

        /// <summary> 
        ///ExSel key
        ///
        VK_EXSEL = 0xF8,

        /// <summary> 
        ///Erase EOF key
        ///
        VK_EREOF = 0xF9,

        /// <summary> 
        ///Play key
        ///
        VK_PLAY = 0xFA,

        /// <summary> 
        ///Zoom key
        ///
        VK_ZOOM = 0xFB,

        /// <summary> 
        ///PA1 key
        ///
        VK_PA1 = 0xFD,

        /// <summary> 
        ///Clear key
        ///
        VK_OEM_CLEAR = 0xFE,

    }
}