namespace HackLeft4Dead2.Graphics
{
    public class GraphicsBorderWindow : IGraphics
    {
        public SettingBorderWindow Setting { get; set; }

        public GraphicsBorderWindow()
        {
            Setting = new();
        }

        public void Render(PaintEventArgs e)
        {
            if (Setting.IsVisible)
            {
                var g = e.Graphics;
                var rect = new Rectangle(0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height);

                g.DrawRectangle(Setting.PenBorder, rect);
            }
        }
    }
}
