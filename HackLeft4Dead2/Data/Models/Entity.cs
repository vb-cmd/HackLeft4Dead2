namespace HackLeft4Dead2.Data.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public Rectangle PositionBox { get; set; }
        public (PointF pointA, PointF pointB) PositionLine { get; set; }
        public PointF PositionRadar { get; set; }
        public Team Team { get; set; }
        public int Health { get; set; }
    }
}
