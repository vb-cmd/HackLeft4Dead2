﻿namespace HackLeft4Dead2.Settings
{
    public class SettingBorderWindow : SettingBase
    {
        public Pen PenBorder { get; set; }
        public SettingBorderWindow()
        {
            PenBorder = new(Color.Linen, 2);
        }
    }
}
