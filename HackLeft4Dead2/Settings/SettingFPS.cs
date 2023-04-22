namespace HackLeft4Dead2.Settings
{
    public class SettingFPS : SettingBase
    {
        public SettingFPS()
        {
            Font = new Font("Arial", 15);
            FontBrush = Brushes.Gold;
            Position = new PointF(10, 320);
        }

        public Font Font { get; set; }
        public Brush FontBrush { get; set; }
        public PointF Position { get; set; }
    }
}
