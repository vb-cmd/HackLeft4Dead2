namespace Overlay;

public class WindowInformation
{
    /// <summary>
    /// Game window name.
    /// </summary>
    private readonly string NameGameWindow;

    private readonly int HeightTopPanel;
    /// <summary>
    /// Game window handle.
    /// </summary>
    private nint handleWindowGame;
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
    /// The window game has top panel. Default is false.
    /// </summary>
    public bool IsWindowHasTopPanel { get; set; } = false;

    public WindowInformation(string nameWindow, int heigthTopPanelWindow = 25)
    {
        HeightTopPanel = heigthTopPanelWindow;
        NameGameWindow = nameWindow ?? throw new NullReferenceException(nameWindow);
    }

    /// <summary>
    /// Update the window when the game window has changed size.
    /// </summary>
    public void UpdateWindow()
    {
        handleWindowGame = WindowAPI.FindWindow(NameGameWindow);
        IsValid = handleWindowGame != nint.Zero && WindowAPI.GetForegroundWindowCurrent(handleWindowGame);

        if (IsValid)
        {
            var rect = WindowAPI.GetWindowRectangle(handleWindowGame);

            WindowRectangleClient = IsWindowHasTopPanel
                ? new Rectangle(rect.X, rect.Y + HeightTopPanel, rect.Width, rect.Height - HeightTopPanel)
                : rect;
        }
        else
        {
            WindowRectangleClient = Rectangle.Empty;
        }
    }
}
