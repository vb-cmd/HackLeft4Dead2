
namespace Hack.Models;

public class Entity
{
    public int Id { get; set; }
    public ClassID ClassId { get; set; }
    public Rectangle PositionBox { get; set; } = Rectangle.Empty;
    public (PointF pointA, PointF pointB) PositionLine { get; set; }
    public PointF PositionRadar { get; set; }
    public Point PositionAim { get; set; }
    public bool IsAlive { get; set; }
    public Team Team { get; set; } = Team.Unknown;
    public int Health { get; set; }
    public float TopModel { get; set; }
}
