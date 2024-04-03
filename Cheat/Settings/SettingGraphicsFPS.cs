namespace CheatL4D2.Settings;

public class SettingGraphicsFPS : SettingBase
{
    public PositionVertical PositionVertical { get; set; } = PositionVertical.Top;
    public PositionHorizontal PositionHorizontal { get; set; } = PositionHorizontal.Center;
    public int Height { get => Font.Height; }
    public int Width { get; } = 100;

    public SettingGraphicsFPS()
    {
        Font = new Font("Arial", 15);
        FontBrush = Brushes.Gold;
        Position = new PointF(10, 320);
    }

    public Font Font { get; set; }
    public Brush FontBrush { get; set; }
    public PointF Position { get; set; }
}
