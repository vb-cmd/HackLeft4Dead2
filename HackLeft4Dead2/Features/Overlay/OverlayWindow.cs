namespace HackLeft4Dead2.Features.Overlay
{
    public class OverlayWindow : IDisposable
    {
        public WindowInformation WindowInformation => windowInformation;
        public List<IGraphics> GraphicsCollection => graphicsCollection;

        private readonly FormOverlay overlay;
        private readonly List<IGraphics> graphicsCollection;
        private readonly WindowInformation windowInformation;

        public OverlayWindow(WindowInformation windowInformation, params IGraphics[] graphics)
        {
            this.windowInformation = windowInformation;
            this.graphicsCollection = new();

            if (graphics is not null) graphicsCollection.AddRange(graphics);

            overlay = new(GraphicsCollection, WindowInformation);
        }

        public void Show()
        => overlay.Show();


        public void Update()
        => overlay.UpdateGraphics();


        public void Dispose()
        => overlay.Close();
    }
}
