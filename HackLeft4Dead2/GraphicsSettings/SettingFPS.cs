using System.Drawing;

namespace HackLeft4Dead2.GraphicsSettings
{
    public class SettingFPS:SettingBase
    {
        public SettingFPS()
        {
            Font = new Font("Arial", 16);
            FontBrush = Brushes.Gold;
            Position = new PointF(10, 350);
        }

        public Font Font { get; set; }
        public Brush FontBrush { get; set; }
        public PointF Position { get; set; }
    }
}
