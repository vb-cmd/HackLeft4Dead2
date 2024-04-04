# OverlayManagement
Library that allows you to render visuals to other windows.

![Test](https://github.com/vitalii-bakun/HackLeft4Dead2/blob/master/Assets/overlay.jpg)

## How to use?
You need to implement the interface in your class.
```C#
    public interface IGraphics
    {
        void Render(PaintEventArgs e);
    }
```

And add elements to OverlayWindow like this:
```C#
    var arrayGraphics = new IGraphics[] {
        new BorderWindow(),
        new FPS(),
        new TestSpeedRender()
    };

    OverlayWindow window = new("Left 4 Dead 2", arrayGraphics);
```

Or add to the collection:
```C#
    var graphic = new BorderWindow();
    window.GraphicsCollection.Add(graphic);
```

## Implementation

What 'Render' should look like:
```C#
    public void Render(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.DrawRectangle(pen, e.ClipRectangle);
    }
```

### For example

```C#
    public class BorderWindow : IGraphics
    {
        private readonly Pen pen;

        public BorderWindow()
        {
            pen = new(Color.GreenYellow)
            {
                Width = 2
            };
        }
        public void Render(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.DrawRectangle(pen, e.ClipRectangle);
        }
    }
```

```C#
    public class TestSpeedRender : IGraphics
    {
        private readonly Random random;
        private readonly Pen enemy;
        private readonly Pen team;
        
        public TestSpeedRender()
        {
            random = new Random();
            enemy = new Pen(Color.Red);
            team = new Pen(Color.Green);
        }

        public void Render(PaintEventArgs e)
        {
            var listEnemys = new List<Rectangle>();
            var listTeam = new List<Rectangle>();
            int height, width, x, y;
            Rectangle rectagle;
            var g = e.Graphics;

            for (int i = 0; i < 32; i++)
            {
                if (e.ClipRectangle.Width != 0 || e.ClipRectangle.Height != 0)
                {
                    try
                    {
                        width = random.Next(20, 70);
                        height = random.Next(30, 100);

                        x = random.Next(width, e.ClipRectangle.Width - width);
                        y = random.Next(height, e.ClipRectangle.Height - height);

                        rectagle = new Rectangle(x, y, width, height);

                        listEnemys.Add(rectagle);

                        width = random.Next(20, 70);
                        height = random.Next(30, 100);

                        x = random.Next(width, e.ClipRectangle.Width - width);
                        y = random.Next(height, e.ClipRectangle.Height - height);

                        rectagle = new Rectangle(x, y, width, height);
                        listTeam.Add(rectagle);
                    }
                    catch { }

                }
            }

            if (listEnemys.Any())
            {
                g.DrawRectangles(enemy, listEnemys.ToArray());
            }
            if (listTeam.Any())
            {
                g.DrawRectangles(team, listTeam.ToArray());
            }
        }
    }
```

```C#
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
            var g = e.Graphics;
            Update();
            g.DrawString(this.ToString(), font, brush, pointF);
        }
    }
```

Here is how to add an OverlayWindow in a Form:
```C#
    public partial class HackForm : Form
    {
        private const string NAME_GAME_WINDOW = "Left 4 Dead 2 - Direct3D 9";
        private OverlayWindow window;

        public HackForm()
        {
            InitializeComponent();
        }

        private void HackForm_Load(object sender, EventArgs e)
        {
            window = new(NAME_GAME_WINDOW, new FPS(), new BorderWindow(), new TestSpeedRender());
            window.Show();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            window.Update();
        }
    }
```

## Problem
Full screen doesn't work.
I know this problem and will solve the problem soon.
Run the game in a window only or without border. 
