using GraphicsGDI = System.Drawing.Graphics;


namespace HackLeft4Dead2.Graphics
{
    public class GraphicsRadar : IGraphics
    {
        public SettingGraphicsRadar Setting { get; set; }
        private readonly DataEntities data;

        public GraphicsRadar(DataEntities data)
        {
            Setting = new SettingGraphicsRadar();
            this.data = data;
        }

        public void Render(PaintEventArgs e)
        {
            if (Setting.IsVisible)
            {
                var g = e.Graphics;
                var player = data.Entities[0];

                RenderBox(g, Setting.BoxBrush, Setting.BoxRectangle);
                RenderPlayer(g, Setting.BoxBrushPlayer, Setting.BoxRectangle);


                for (int i = 1; i < data.Entities.Length; i++)
                {
                    var entity = data.Entities[i];

                    SelectModel(g, entity, player);
                }
            }
        }

        private void SelectModel(GraphicsGDI g, Entity entity, Entity entityPlayer)
        {
            switch (entity.ClassId)
            {
                case ClassID.SurvivorPlayer:
                        RenderEntity(g, Setting.SurvivorPlayer, entity, entityPlayer, Setting.BoxRectangle);
                    break;
                case ClassID.SurvivorBot:
                        RenderEntity(g, Setting.SurvivorBot, entity, entityPlayer, Setting.BoxRectangle);
                    break;
                case ClassID.Hunter:
                        RenderEntity(g, Setting.Hunter, entity, entityPlayer, Setting.BoxRectangle);
                    break;
                case ClassID.Tank:
                        RenderEntity(g, Setting.Tank, entity, entityPlayer, Setting.BoxRectangle);
                    break;
                case ClassID.Spitter:
                        RenderEntity(g, Setting.Spitter, entity, entityPlayer, Setting.BoxRectangle);
                    break;
                case ClassID.Smoker:
                        RenderEntity(g, Setting.Smoker, entity, entityPlayer, Setting.BoxRectangle);
                    break;
                case ClassID.Boomer:
                        RenderEntity(g, Setting.Boomer, entity, entityPlayer, Setting.BoxRectangle);
                    break;
                case ClassID.Jockey:
                        RenderEntity(g, Setting.Jockey, entity, entityPlayer, Setting.BoxRectangle);
                    break;
                case ClassID.Charger:
                        RenderEntity(g, Setting.Charger, entity, entityPlayer, Setting.BoxRectangle);
                    break;
                case ClassID.Witch:
                        RenderEntity(g, Setting.Witch, entity, entityPlayer, Setting.BoxRectangle);
                    break;
                case ClassID.Infected:
                        RenderObject(g, Setting.Infected, entity, entityPlayer, Setting.BoxRectangle);
                    break;
                case ClassID.WeaponSpawn:
                        RenderObject(g, Setting.WeaponSpawn, entity, entityPlayer, Setting.BoxRectangle);
                    break;
                case ClassID.WeaponAmmoSpawn:
                        RenderObject(g, Setting.WeaponAmmoSpawn, entity, entityPlayer, Setting.BoxRectangle);
                    break;
                default:
                    break;
            }
        }

        private static int RadarPositionCalculator(int localPlayer, int entity, int size)
        {
            float RadarX = (localPlayer - entity) * 0.1f;
            RadarX += size / 2;
            return (int)RadarX;
        }

        private void RenderEntity(GraphicsGDI graphics, SettingModel settingModel, Entity entity, Entity player, Rectangle rectangle)
        {
            if (entity.IsAlive && settingModel.IsVisible)
            {
                var x = rectangle.X + RadarPositionCalculator((int)player.PositionRadar.X, (int)entity.PositionRadar.X, rectangle.Width);
                var y = rectangle.Y + RadarPositionCalculator((int)player.PositionRadar.Y, (int)entity.PositionRadar.Y, rectangle.Height);


                if (x < rectangle.Width && y < rectangle.Width && x > 0 && y > 0)
                {
                    Rectangle rectagle = new(x - (Setting.BoxSizePlayer / 2), y - (Setting.BoxSizePlayer / 2), Setting.BoxSizePlayer, Setting.BoxSizePlayer);

                    //draw line from entity to player
                    graphics.DrawLine(settingModel.Pen, x, y, rectangle.X + (rectangle.Width / 2), rectangle.Y + (rectangle.Height / 2));

                    //draw background
                    graphics.FillEllipse(settingModel.Pen.Brush, rectagle);
                }
            }
        }

        private void RenderObject(GraphicsGDI graphics, SettingModel settingModel, Entity entity, Entity player, Rectangle rectangle)
        {
            if (entity.IsAlive)
            {
                var x = rectangle.X + RadarPositionCalculator((int)player.PositionRadar.X, (int)entity.PositionRadar.X, rectangle.Width);
                var y = rectangle.Y + RadarPositionCalculator((int)player.PositionRadar.Y, (int)entity.PositionRadar.Y, rectangle.Height);


                if (x < rectangle.Width && y < rectangle.Width && x > 0 && y > 0)
                {
                    Rectangle rectagle = new(x - (Setting.BoxSizeObject / 2), y - (Setting.BoxSizeObject / 2), Setting.BoxSizeObject, Setting.BoxSizeObject);

                    graphics.FillEllipse(settingModel.Pen.Brush, rectagle);
                }
            }
        }

        private void RenderBox(GraphicsGDI graphics, Brush brush, Rectangle rectangle)
        => graphics.FillRectangle(brush, rectangle);


        private void RenderPlayer(GraphicsGDI graphics, Brush brush, Rectangle rectangle)
        => graphics.FillEllipse(brush, rectangle.X + ((rectangle.Width / 2) - (Setting.BoxSizePlayer / 2)), rectangle.Y + ((rectangle.Height / 2) - (Setting.BoxSizePlayer / 2)), Setting.BoxSizePlayer, Setting.BoxSizePlayer);

    }
}
