namespace HackLeft4Dead2.Graphics.Settings
{
    public class SettingBaseEntity : SettingBase
    {
        public bool IsVisibleSurvivorPlayer { get; set; } = true;
        public bool IsVisibleSurvivorBot { get; set; } = true;

        public bool IsVisibleHunter { get; set; } = true;
        public bool IsVisibleTank { get; set; } = true;
        public bool IsVisibleWitch { get; set; } = true;
        public bool IsVisibleSpitter { get; set; } = true;
        public bool IsVisibleSmoker { get; set; } = true;
        public bool IsVisibleBoomer { get; set; } = true;
        public bool IsVisibleJockey { get; set; } = true;
        public bool IsVisibleCharger { get; set; } = true;
        public bool IsVisibleInfected { get; set; } = true;

        public bool IsVisibleWeaponSpawn { get; set; } = true;
        public bool IsVisibleWeaponAmmoSpawn { get; set; } = true;

        public Pen PenSurvivorPlayer { get; set; }
        public Pen PenSurvivorBot { get; set; }

        public Pen PenHunter { get; set; }
        public Pen PenTank { get; set; }
        public Pen PenWitch { get; set; }
        public Pen PenSpitter { get; set; }
        public Pen PenSmoker { get; set; }
        public Pen PenBoomer { get; set; }
        public Pen PenJockey { get; set; }
        public Pen PenCharger { get; set; }
        public Pen PenInfected { get; set; }

        public Pen PenWeaponSpawn { get; set; }
        public Pen PenWeaponAmmoSpawn { get; set; }

        public SettingBaseEntity()
        {
            PenSurvivorPlayer = new Pen(Color.Green, 1);
            PenSurvivorBot = new Pen(Color.Green, 1);

            PenHunter = new Pen(Color.Red, 1);
            PenTank = new(Color.Red, 1);
            PenWitch = new(Color.OrangeRed);
            PenSpitter = new(Color.Red, 1);
            PenSmoker = new(Color.Red, 1);
            PenBoomer = new(Color.Red, 1);
            PenJockey = new(Color.Red, 1);
            PenCharger = new(Color.Red, 1);
            PenInfected = new(Color.DarkRed, 1);

            PenWeaponSpawn = new(Color.Blue, 1);
            PenWeaponAmmoSpawn = new(Color.AliceBlue, 1);
        }
    }
}
