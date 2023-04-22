namespace HackLeft4Dead2.Settings
{
    public class SettingGraphicsBoxESP : SettingEntityBase
    {
        public int SizeObject { get; set; }
        public Font Font { get; set; }
        public Brush FontBrush { get; set; }

        public SettingGraphicsBoxESP()
        {
            SizeObject = 10;
            Font = new("Ariel", SizeObject);
            FontBrush = Brushes.AntiqueWhite;
        }
    }
}
