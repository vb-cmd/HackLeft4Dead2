namespace Overlay
{
    public class WindowInformation
    {
        /// <summary>
        /// Game window name.
        /// </summary>
        private readonly string NAME_GAME_WINDOW;
        /// <summary>
        /// Game window handle.
        /// </summary>
        private nint HandleWindowGame => WindowAPI.FindWindow(NAME_GAME_WINDOW);
        /// <summary>
        /// Game window client rectangle.
        /// </summary>
        public Rectangle WindowRectangleClient { get; private set; }

        /// <summary>
        /// Checking the window game by name.
        /// </summary>
        /// <returns>true if ptr and the current foreground Window is found, or false if not.</returns>
        public bool IsValid => HandleWindowGame != IntPtr.Zero;

        public bool ForegroundWindow => WindowAPI.GetForegroundWindowCurrent(HandleWindowGame);

        public WindowInformation(string nameWindow)
        {
            NAME_GAME_WINDOW = nameWindow ?? throw new NullReferenceException(nameWindow);
        }

        /// <summary>
        /// Update the window when the game window has changed size.
        /// </summary>
        public void UpdateWindow()
        {
            if (IsValid)
            {
                WindowRectangleClient = WindowAPI.GetWindowRectangle(HandleWindowGame);
            }
            else
            {
                WindowRectangleClient = Rectangle.Empty;
            }
        }
    }
}
