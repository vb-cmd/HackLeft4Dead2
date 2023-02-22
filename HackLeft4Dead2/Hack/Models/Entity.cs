namespace HackLeft4Dead2.Hack.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public ClassID ClassId { get; set; }
        public Rectangle PositionBox { get; set; }
        public (PointF pointA, PointF pointB) PositionLine { get; set; }
        public PointF PositionRadar { get; set; }
        public bool IsAlive { get; set; }
        public Team Team { get; set; }
        public int Health { get; set; }
        public float TopModel { get; set; }
    }

    public enum Team
    {
        Unknown = 0,
        Spectator = 1,
        Survivors = 2,
        MainZombie = 3,
    }

    public enum ClassID : sbyte
    {
        SurvivorPlayer = 67,
        SurvivorBot = 97,

        Hunter = -70,
        Tank = -91,
        Witch = -98,
        Spitter = -57,
        Smoker = -77,
        Boomer = -84,
        Jockey = -50,
        Charger = -63,
        Infected = -108,

        WeaponSpawn = 2,
        WeaponAmmoSpawn = 6,
    }
}
