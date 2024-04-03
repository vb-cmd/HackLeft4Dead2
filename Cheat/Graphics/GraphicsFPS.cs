namespace CheatL4D2.Graphics;


public class GraphicsFPS : IGraphics
{
    TimeSpan FpsUpdate = TimeSpan.FromSeconds(1);
    Stopwatch stopWatch;
    int fpsCount;
    public int FPS { get; private set; }

    public SettingGraphicsFPS Setting { get; set; }

    public GraphicsFPS()
    {
        Setting = new();
        stopWatch = Stopwatch.StartNew();
    }

    public void Update()
    {
        var fpsTimerMs = stopWatch.Elapsed;
        if (fpsTimerMs > FpsUpdate)
        {
            FPS = (int)(fpsCount / fpsTimerMs.TotalSeconds);
            stopWatch.Restart();
            fpsCount = 0;
        }

        fpsCount++;
    }

    public override string ToString()
        => $"FPS: {FPS}";

    public void Render(PaintEventArgs e)
    {
        var g = e.Graphics;

        if (Setting.IsVisible)
        {
            SetPositionOnWindow(e.ClipRectangle.Size);
            Update();

            g.DrawString(ToString(), Setting.Font, Setting.FontBrush, Setting.Position);
        }
    }

    private void SetPositionOnWindow(Size size)
    {
        var position = PointF.Empty;

        position.X = Setting.PositionHorizontal switch
        {
            PositionHorizontal.Left => 0,
            PositionHorizontal.Center => (size.Width / 2) - (Setting.Width / 2),
            PositionHorizontal.Right => size.Width - Setting.Width,
            PositionHorizontal.Default => Setting.Position.X,
            _ => throw new ArgumentException(),
        };

        position.Y = Setting.PositionVertical switch
        {
            PositionVertical.Top => 0,
            PositionVertical.Center => (size.Height / 2) - (Setting.Height / 2),
            PositionVertical.Bottom => size.Height - Setting.Height,
            PositionVertical.Default => Setting.Position.Y,
            _ => throw new ArgumentException(),
        };

        Setting.Position = position;
    }
}
