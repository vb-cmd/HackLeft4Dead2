namespace Overlay;

public class OverlayWindow : IDisposable
{
    public WindowInformation WindowInformation => windowInformation;
    public List<IGraphics> GraphicsCollection => graphicsCollection;
    public Form Form => overlay;

    private readonly FormOverlay overlay;
    private readonly List<IGraphics> graphicsCollection;
    private readonly WindowInformation windowInformation;

    public OverlayWindow(string nameWindow, params IGraphics[] graphics)
    {
        windowInformation = new(nameWindow);
        graphicsCollection = new();

        if (graphics is not null) graphicsCollection.AddRange(graphics);

        overlay = new(GraphicsCollection, WindowInformation);
    }

    public void Show()
    => overlay.Show();

    public void Close()
        => overlay.Close();


    public void Update()
    => overlay.UpdateGraphics();


    public void Dispose()
        => overlay?.Dispose();
}
