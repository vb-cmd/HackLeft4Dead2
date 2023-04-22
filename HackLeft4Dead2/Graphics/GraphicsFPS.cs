using HackLeft4Dead2.Settings;

namespace HackLeft4Dead2.Graphics
{

    public class GraphicsFPS : IGraphics
    {
        TimeSpan FpsUpdate = TimeSpan.FromSeconds(1);
        Stopwatch sw;
        int fpsCount;
        public int FPS { get; private set; }

        public SettingFPS Setting { get; set; }

        public GraphicsFPS()
        {
            Setting = new();
            sw = Stopwatch.StartNew();
        }

        public void Update()
        {
            var fpsTimerMs = sw.Elapsed;
            if (fpsTimerMs > FpsUpdate)
            {
                FPS = (int)(fpsCount / fpsTimerMs.TotalSeconds);
                sw.Restart();
                fpsCount = 0;
            }

            fpsCount++;
        }

        public override string ToString() 
        => $"FPS: {FPS}";
        
        public void Render(PaintEventArgs e)
        {
            if (Setting.IsVisible)
            {
                var g = e.Graphics;

                Update();
                g.DrawString(ToString(), Setting.Font, Setting.FontBrush, Setting.Position);
            }
        }
    }
}
