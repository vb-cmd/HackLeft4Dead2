﻿namespace HackLeft4Dead2.Settings
{
    public class SettingGraphicsRadar : SettingEntityBase
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
            BoxBrushPlayer = Brushes.GreenYellow;
            BoxBrush = Brushes.DarkOrchid;
            BoxRectangle = new(0, 0, 300, 300);
        }
    }
}
