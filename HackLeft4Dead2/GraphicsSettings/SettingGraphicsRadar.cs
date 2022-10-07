namespace HackLeft4Dead2.GraphicsSettings
{
    public class SettingGraphicsRadar: SettingBaseEntity
    {
        public int BoxSizeObject { get; set; }
        public int BoxSizePlayer { get; set; }
        public Brush BoxBrush { get; set; }
        public Brush BoxBrushPlayer { get; set; }
        public Rectangle BoxRectangle { get; set; }

        public SettingGraphicsRadar()
        {
            BoxSizeObject = 5;
            BoxSizePlayer = 10;
            BoxBrushPlayer = Brushes.DarkRed;
            BoxBrush = Brushes.Orange;
            BoxRectangle = new(0, 0, 300, 300);
        }
    }
}
