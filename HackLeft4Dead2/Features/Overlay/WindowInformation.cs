namespace HackLeft4Dead2.Features.Overlay
{
    public class WindowInformation
    {
        /// <summary>
        /// Game window name.
        /// </summary>
        private readonly string NAME_GAME_WINDOW;

        private const int HEIGHT_TOP_PANEL = 25;

        /// <summary>
        /// Game window handle.
        /// </summary>
        private nint HandleWindowGame;

        /// <summary>
        /// Game window client rectangle.
        /// </summary>
        public Rectangle WindowRectangleClient { get; private set; }

        /// <summary>
        /// Checking the window game by name.
        /// </summary>
        /// <returns>true if ptr and the current foreground Window is found, or false if not.</returns>
        public bool IsValid { get; private set; }
        
        /// <summary>
        /// The game window has a top panel. Default value is false.
        /// </summary>
        public bool IsWindowHasTopPanel { get; set; } = false;

        public WindowInformation(string nameWindow)
        => NAME_GAME_WINDOW = nameWindow ?? throw new NullReferenceException(nameWindow);
        

        /// <summary>
        /// Update the window when the game window has changed size.
        /// </summary>
        public void UpdateWindow()
        {
            HandleWindowGame = WindowAPI.FindWindow(NAME_GAME_WINDOW);

            IsValid = HandleWindowGame != IntPtr.Zero && WindowAPI.GetForegroundWindowCurrent(HandleWindowGame);

            if (IsValid)
            {
                var rect = WindowAPI.GetWindowRectangle(HandleWindowGame);

                WindowRectangleClient = IsWindowHasTopPanel
                    ? new Rectangle(rect.X, rect.Y + HEIGHT_TOP_PANEL, rect.Width, rect.Height - HEIGHT_TOP_PANEL)
                    : rect;
            }
            else
            {
                WindowRectangleClient = Rectangle.Empty;
            }
        }
    }
}
