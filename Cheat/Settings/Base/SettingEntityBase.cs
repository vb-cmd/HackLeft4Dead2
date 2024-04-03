namespace CheatForm.Settings.Base;

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

        var survivorColor = new Pen(Color.Green, width);
        var zombieBossColor = new Pen(Color.Red, width);
        var infectedColor = new Pen(Color.FromArgb(255, 0, 111), width);
        var weapon = new Pen(Color.FromArgb(0, 77, 255), width);

        SurvivorPlayer = new(survivorColor);
        SurvivorBot = new(survivorColor);
        Hunter = new(zombieBossColor);
        Tank = new(zombieBossColor);
        Witch = new(zombieBossColor);
        Spitter = new(zombieBossColor);
        Smoker = new(zombieBossColor);
        Boomer = new(zombieBossColor);
        Jockey = new(zombieBossColor);
        Charger = new(zombieBossColor);
        Infected = new(infectedColor);
        WeaponSpawn = new(weapon, false);
        WeaponAmmoSpawn = new(weapon, false);
    }

    public SettingModel GetSettingModel(Entity entity)
    {
        return entity.ClassId switch
        {
            ClassID.SurvivorPlayer => SurvivorPlayer,
            ClassID.SurvivorBot => SurvivorBot,
            ClassID.Hunter => Hunter,
            ClassID.Tank => Tank,
            ClassID.Spitter => Spitter,
            ClassID.Smoker => Smoker,
            ClassID.Boomer => Boomer,
            ClassID.Jockey => Jockey,
            ClassID.Charger => Charger,
            ClassID.Witch => Witch,
            ClassID.Infected => Infected,
            ClassID.WeaponSpawn => WeaponSpawn,
            ClassID.WeaponAmmoSpawn => WeaponAmmoSpawn,
            _ => null,
        };
    }
}

public class SettingModel
{
    public SettingModel(Pen pen, bool isVisible = true)
    {
        Pen = pen;
        IsVisible = isVisible;
    }

    public Pen Pen { get; set; }
    public bool IsVisible { get; set; }
}
