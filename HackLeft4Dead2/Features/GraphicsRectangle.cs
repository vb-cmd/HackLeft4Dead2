namespace HackLeft4Dead2.Features
{
    public class GraphicsRectangle : IGraphics
    {
        private readonly Pen enemy;
        private readonly Pen team;
        private readonly DataEntities data;

        public GraphicsRectangle(DataEntities data)
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

                    if (data.Entities[i].Team == Team.BossZombie)
                    {
                        e.Graphics.DrawRectangle(enemy, data.Entities[i].PositionBox);
                    }
                    else if (data.Entities[i].Team == Team.Survivors)
                    {
                        e.Graphics.DrawRectangle(team, data.Entities[i].PositionBox);
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
