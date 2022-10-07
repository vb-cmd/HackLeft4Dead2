using HackLeft4Dead2.GraphicsSettings;
using System.Diagnostics;

namespace HackLeft4Dead2.Graphics
{

    public class GraphicsFPS : IGraphics
    {
        static readonly TimeSpan FpsUpdate = TimeSpan.FromSeconds(1);

        Stopwatch sw;
        int fpsCount;
        int fps;
        public int Fps => fps;

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
                fps = (int)(fpsCount / fpsTimerMs.TotalSeconds);
                sw.Restart();
                fpsCount = 0;
            }

            fpsCount++;
        }

        public override string ToString()
        {
            return $"FPS: {fps}";
        }

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
