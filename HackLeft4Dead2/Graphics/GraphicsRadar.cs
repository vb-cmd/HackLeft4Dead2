using HackLeft4Dead2.GraphicsSettings;
using System.Numerics;
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

                RenderBox(g, Setting.BoxBrush, Setting.BoxRectangle);
                RenderPlayer(g, Setting.BoxBrushPlayer, Setting.BoxRectangle);

                var entityPlayer = data.Entities[0];

                for (int i = 1; i < data.Entities.Length; i++)
                {
                    var entity = data.Entities[i];

                    switch (entity.ClassId)
                    {
                        case ClassID.SurvivorPlayer:
                            if (entity.IsAlive && Setting.IsVisibleSurvivorPlayer)
                                RenderEntity(g, Setting.PenSurvivorPlayer, entity, entityPlayer, Setting.BoxRectangle);
                            break;
                        case ClassID.SurvivorBot:
                            if (entity.IsAlive && Setting.IsVisibleSurvivorBot)
                                RenderEntity(g, Setting.PenSurvivorBot, entity, entityPlayer, Setting.BoxRectangle);
                            break;
                        case ClassID.Hunter:
                            if (entity.IsAlive && Setting.IsVisibleHunter)
                                RenderEntity(g, Setting.PenHunter, entity, entityPlayer, Setting.BoxRectangle);
                            break;
                        case ClassID.Tank:
                            if (entity.IsAlive && Setting.IsVisibleTank)
                                RenderEntity(g, Setting.PenTank, entity, entityPlayer, Setting.BoxRectangle);
                            break;
                        case ClassID.Spitter:
                            if (entity.IsAlive && Setting.IsVisibleSpitter)
                                RenderEntity(g, Setting.PenSpitter, entity, entityPlayer, Setting.BoxRectangle);
                            break;
                        case ClassID.Smoker:
                            if (entity.IsAlive && Setting.IsVisibleSmoker)
                                RenderEntity(g, Setting.PenSmoker, entity, entityPlayer, Setting.BoxRectangle);
                            break;
                        case ClassID.Boomer:
                            if (entity.IsAlive && Setting.IsVisibleBoomer)
                                RenderEntity(g, Setting.PenBoomer, entity, entityPlayer, Setting.BoxRectangle);
                            break;
                        case ClassID.Jockey:
                            if (entity.IsAlive && Setting.IsVisibleJockey)
                                RenderEntity(g, Setting.PenJockey, entity, entityPlayer, Setting.BoxRectangle);
                            break;
                        case ClassID.Charger:
                            if (entity.IsAlive && Setting.IsVisibleCharger)
                                RenderEntity(g, Setting.PenCharger, entity, entityPlayer, Setting.BoxRectangle);
                            break;
                        case ClassID.Witch:
                            if (entity.IsAlive && Setting.IsVisibleWitch)
                                RenderEntity(g, Setting.PenWitch, entity, entityPlayer, Setting.BoxRectangle);
                            break;
                        case ClassID.Infected:
                            if (entity.IsAlive && Setting.IsVisibleInfected)
                                RenderObject(g, Setting.PenInfected, entity, entityPlayer, Setting.BoxRectangle);
                            break;
                        case ClassID.WeaponSpawn:
                            if (Setting.IsVisibleWeaponSpawn)
                                RenderObject(g, Setting.PenWeaponSpawn, entity, entityPlayer, Setting.BoxRectangle);
                            break;
                        case ClassID.WeaponAmmoSpawn:
                            if (Setting.IsVisibleWeaponAmmoSpawn)
                                RenderObject(g, Setting.PenWeaponAmmoSpawn, entity, entityPlayer, Setting.BoxRectangle);
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        private static int RadarPositionCalculator(int localPlayer, int entity, int size)
        {
            float RadarX = (localPlayer - entity) * 0.1f;
            RadarX += size / 2;
            return (int)RadarX;
        }

        private void RenderEntity(GraphicsGDI graphics, Pen pen, Entity entity, Entity player, Rectangle rectangle)
        {
            var x = rectangle.X + RadarPositionCalculator((int)player.PositionRadar.X, (int)entity.PositionRadar.X, rectangle.Width);
            var y = rectangle.Y + RadarPositionCalculator((int)player.PositionRadar.Y, (int)entity.PositionRadar.Y, rectangle.Height);


            if (x < rectangle.Width && y < rectangle.Width && x > 0 && y > 0)
            {
                Rectangle rectagle = new(x - (Setting.BoxSizePlayer / 2), y - (Setting.BoxSizePlayer / 2), Setting.BoxSizePlayer, Setting.BoxSizePlayer);

                //draw line from entity to player
                graphics.DrawLine(pen, x, y, rectangle.X+ (rectangle.Width / 2), rectangle.Y+ (rectangle.Height / 2));

                //draw background
                graphics.FillEllipse(pen.Brush, rectagle);
            }

        }

        private void RenderObject(GraphicsGDI graphics, Pen pen, Entity entity, Entity player, Rectangle rectangle)
        {
            var x = rectangle.X + RadarPositionCalculator( (int)player.PositionRadar.X, (int)entity.PositionRadar.X, rectangle.Width);
            var y = rectangle.Y + RadarPositionCalculator( (int)player.PositionRadar.Y, (int)entity.PositionRadar.Y, rectangle.Height);


            if (x < rectangle.Width && y < rectangle.Width && x > 0 && y > 0)
            {
                Rectangle rectagle = new(x - (Setting.BoxSizeObject / 2), y - (Setting.BoxSizeObject / 2), Setting.BoxSizeObject, Setting.BoxSizeObject);

                graphics.FillEllipse(pen.Brush, rectagle);
            }
        }

        private void RenderBox(GraphicsGDI graphics, Brush brush, Rectangle rectangle)
        {
            graphics.FillRectangle(brush, rectangle);
        }

        private void RenderPlayer(GraphicsGDI graphics, Brush brush, Rectangle rectangle)
        {
            graphics.FillEllipse(brush, rectangle.X + ((rectangle.Width / 2) - (Setting.BoxSizePlayer / 2)), rectangle.Y + ((rectangle.Height / 2) - (Setting.BoxSizePlayer / 2)), Setting.BoxSizePlayer, Setting.BoxSizePlayer);
        }
    }
}
