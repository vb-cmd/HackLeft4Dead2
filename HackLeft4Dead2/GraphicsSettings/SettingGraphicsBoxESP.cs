namespace HackLeft4Dead2.GraphicsSettings
{
    public class SettingGraphicsBoxESP: SettingBaseEntity
    {
        public int SizeObject { get; set; }
        public Font Font { get; set; }
        public Brush FontBrush { get; set; }

        public SettingGraphicsBoxESP()
        {
            SizeObject = 10;
            Font = new("Ariel", 10);
            FontBrush = Brushes.Violet;
        }
    }
}
