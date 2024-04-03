

namespace CheatL4D2.Settings;

public class SettingGraphicsRadar : SettingEntityBase
{
    public PositionVertical PositionVertical { get; set; } = PositionVertical.Default;
    public PositionHorizontal PositionHorizontal { get; set; } = PositionHorizontal.Default;
    public int SizeObject { get; set; }
    public int SizePlayer { get; set; }
    public Brush BrushObject { get; set; }
    public Brush BrushPlayer { get; set; }
    public Brush BrushRadar { get; set; }
    public Rectangle CustomPositionAndSize { get; set; }

    public SettingGraphicsRadar()
    {
        SizeObject = 5;
        SizePlayer = 10;
        BrushPlayer = Brushes.GreenYellow;
        BrushObject = Brushes.DarkOrchid;
        BrushRadar = new SolidBrush(Color.FromArgb(50, 63, 74));
        CustomPositionAndSize = new(0, 0, 300, 300);
    }
}
