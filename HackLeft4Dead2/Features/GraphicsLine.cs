namespace HackLeft4Dead2.Features
{
    public class GraphicsLine : IGraphics
    {
        private readonly Pen enemy;
        private readonly Pen team;
        private readonly DataEntities data;

        public GraphicsLine(DataEntities data)
        {
            enemy = new Pen(Color.Red);
            team = new Pen(Color.Green);
            this.data = data;
        }

        public void Render(PaintEventArgs e)
        {
            for (int i = 1; i < data.Entities.Length; i++)
            {
                if (e.ClipRectangle.Width != 0 && e.ClipRectangle.Height != 0)
                {
                    try
                    {
                        if (data.Entities[i].Team == Team.BossZombie)
                        {
                            e.Graphics.DrawLine(enemy, data.Entities[i].PositionLine.pointA, data.Entities[i].PositionLine.pointB);
                        }
                        if (data.Entities[i].Team == Team.Survivors)
                        {
                            e.Graphics.DrawLine(team, data.Entities[i].PositionLine.pointA, data.Entities[i].PositionLine.pointB);
                        }
                    }
                    catch { }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
