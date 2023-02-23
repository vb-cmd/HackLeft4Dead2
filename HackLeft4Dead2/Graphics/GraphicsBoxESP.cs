using GraphicsGDI = System.Drawing.Graphics;

namespace HackLeft4Dead2.Graphics
{
    public class GraphicsBoxESP : IGraphics
    {
        public SettingGraphicsBoxESP Setting { get; set; }
        private readonly DataEntities data;

        public GraphicsBoxESP(DataEntities data)
        {
            Setting = new();
            this.data = data;
        }

        public void Render(PaintEventArgs e)
        {
            if (Setting.IsVisible)
            {
                var g = e.Graphics;
                Entity entity;

                for (int i = 1; i < data.Entities.Length; i++)
                {
                    entity = data.Entities[i];

                    if (!entity.PositionBox.IsEmpty)
                    {
                        switch (entity.ClassId)
                        {
                            case ClassID.SurvivorPlayer:
                                if (entity.IsAlive && Setting.IsVisibleSurvivorPlayer)
                                    RenderEntity(g, Setting.PenSurvivorPlayer, entity);
                                break;
                            case ClassID.SurvivorBot:
                                if (entity.IsAlive && Setting.IsVisibleSurvivorBot)
                                    RenderEntity(g, Setting.PenSurvivorBot, entity);
                                break;
                            case ClassID.Hunter:
                                if (entity.IsAlive && Setting.IsVisibleHunter)
                                    RenderEntity(g, Setting.PenHunter, entity);
                                break;
                            case ClassID.Tank:
                                if (entity.IsAlive && Setting.IsVisibleTank)
                                    RenderEntity(g, Setting.PenTank, entity);
                                break;
                            case ClassID.Spitter:
                                if (entity.IsAlive && Setting.IsVisibleSpitter)
                                    RenderEntity(g, Setting.PenSpitter, entity);
                                break;
                            case ClassID.Smoker:
                                if (entity.IsAlive && Setting.IsVisibleSmoker)
                                    RenderEntity(g, Setting.PenSmoker, entity);
                                break;
                            case ClassID.Boomer:
                                if (entity.IsAlive && Setting.IsVisibleBoomer)
                                    RenderEntity(g, Setting.PenBoomer, entity);
                                break;
                            case ClassID.Jockey:
                                if (entity.IsAlive && Setting.IsVisibleJockey)
                                    RenderEntity(g, Setting.PenJockey, entity);
                                break;
                            case ClassID.Charger:
                                if (entity.IsAlive && Setting.IsVisibleCharger)
                                    RenderEntity(g, Setting.PenCharger, entity);
                                break;
                            case ClassID.Witch:
                                if (entity.IsAlive && Setting.IsVisibleWitch)
                                    RenderEntity(g, Setting.PenWitch, entity);
                                break;
                            case ClassID.Infected:
                                if (entity.IsAlive && Setting.IsVisibleInfected)
                                    RenderEntity(g, Setting.PenInfected, entity);
                                break;
                            case ClassID.WeaponSpawn:
                                if (Setting.IsVisibleWeaponSpawn)
                                    RenderObject(g, Setting.PenWeaponSpawn, entity);
                                break;
                            case ClassID.WeaponAmmoSpawn:
                                if (Setting.IsVisibleWeaponAmmoSpawn)
                                    RenderObject(g, Setting.PenWeaponAmmoSpawn, entity);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }


        private void RenderEntity(GraphicsGDI graphics, Pen pen, Entity entity)
        {
            graphics.DrawRectangle(pen, entity.PositionBox);

            if (entity.Health > 0)
            {
                //draw information about entity
                string value = $"H:{entity.Health}";
                graphics.DrawString(value, Setting.Font, Setting.FontBrush, entity.PositionBox.X, entity.PositionBox.Y - 15);
            }
        }

        private void RenderObject(GraphicsGDI graphics, Pen pen, Entity entity)
        {
            var rect = new Rectangle(entity.PositionBox.X - (Setting.SizeObject / 2), entity.PositionBox.Y - Setting.SizeObject, Setting.SizeObject, Setting.SizeObject);
            graphics.FillEllipse(pen.Brush, rect);
        }

    }
}

