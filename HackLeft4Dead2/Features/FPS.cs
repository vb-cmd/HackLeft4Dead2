using System.Diagnostics;

namespace HackLeft4Dead2.Features
{

    public class FPS : IGraphics
    {
        static readonly TimeSpan FpsUpdate = TimeSpan.FromSeconds(1);

        Stopwatch sw;
        int fpsCount;
        double fps;
        public double Fps => fps;

        public FPS()
        {
            font = new("Arial", 16);
            brush = Brushes.Gold;
            pointF = new PointF(10, 10);
            sw = Stopwatch.StartNew();
        }

        public void Update()
        {
            var fpsTimerMs = sw.Elapsed;
            if (fpsTimerMs > FpsUpdate)
            {
                fps = fpsCount / fpsTimerMs.TotalSeconds;
                sw.Restart();
                fpsCount = 0;
            }

            fpsCount++;
        }

        public override string ToString()
        {
            return $"FPS: {fps}";
        }


        readonly Font font;
        readonly Brush brush;
        readonly PointF pointF;

        public void Render(PaintEventArgs e)
        {
            Update();
            e.Graphics.DrawString(this.ToString(), font, brush, pointF);
        }
    }
}
