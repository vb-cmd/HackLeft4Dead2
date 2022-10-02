namespace Overlay.Extension
{
    internal static class FormExtension
    {
        /// <summary>
        /// Makes the window transparent
        /// </summary>
        /// <exception cref="Exception">The method WindowTransparent can not be called prior to the window being initialized.</exception>
        public static void WindowTransparent(this Form form)
        {
            if (!form.IsHandleCreated)
                throw new Exception("The method WindowTransparent can not be called prior to the window being initialized.");

            var extendedStyle = WindowAPI.GetWindowLongPtr(form.Handle, -20 /*GwlExstyle*/);
            WindowAPI.SetWindowLongPtr(form.Handle, -20 /*GwlExstyle*/, extendedStyle | (nint)0x00000020 /*WsExTransparent*/);
        }
    }
}
