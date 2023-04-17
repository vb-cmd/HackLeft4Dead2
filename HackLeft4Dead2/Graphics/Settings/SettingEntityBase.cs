namespace HackLeft4Dead2.Graphics.Settings
{
    public class SettingEntityBase : SettingBase
    {
        public SettingModel SurvivorPlayer { get; set; }
        public SettingModel SurvivorBot { get; set; }
        public SettingModel Hunter { get; set; }
        public SettingModel Tank { get; set; }
        public SettingModel Witch { get; set; }
        public SettingModel Spitter { get; set; }
        public SettingModel Smoker { get; set; }
        public SettingModel Boomer { get; set; }
        public SettingModel Jockey { get; set; }
        public SettingModel Charger { get; set; }
        public SettingModel Infected { get; set; }
        public SettingModel WeaponSpawn { get; set; }
        public SettingModel WeaponAmmoSpawn { get; set; }

        public SettingEntityBase()
        {
            float width = 1;

            var green = new Pen(Color.Green, width);
            var red = new Pen(Color.Red, width);
            var blue = new Pen(Color.Blue, width);

            SurvivorPlayer = new(green);
            SurvivorBot = new(green);
            Hunter = new(red);
            Tank = new(red);
            Witch = new(red);
            Spitter = new(red);
            Smoker = new(red);
            Boomer = new(red);
            Jockey = new(red);
            Charger = new(red);
            Infected = new(red);
            WeaponSpawn = new(blue);
            WeaponAmmoSpawn = new(blue);
        }
    }

    public class SettingModel
    {
        public SettingModel(Pen pen)
        {
            Pen = pen;
        }

        public Pen Pen { get; set; }
        public bool IsVisible { get; set; } = true;
    }
}
