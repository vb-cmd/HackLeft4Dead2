using HackLeft4Dead2.GraphicsSettings;
using GraphicsGDI = System.Drawing.Graphics;

namespace HackLeft4Dead2.Graphics
{
    public class GraphicsLineESP : IGraphics
    {
        private readonly DataEntities data;
        public SettingBaseEntity Setting { get; set; }

        public GraphicsLineESP(DataEntities data)
        {
            this.Setting = new();
            this.data = data;
        }

        public void Render(PaintEventArgs e)
        {
            if (Setting.IsVisible)
            {
                Entity entity;
                var g = e.Graphics;

                for (int i = 1; i < data.Entities.Length; i++)
                {
                    entity = data.Entities[i];

                    if (entity.PositionLine.pointB.IsNotEmptyAll() && entity.PositionLine.pointB.IsNotEmptyAll())
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
                                    RenderEntity(g, Setting.PenWeaponSpawn, entity);
                                break;
                            case ClassID.WeaponAmmoSpawn:
                                if (Setting.IsVisibleWeaponAmmoSpawn)
                                    RenderEntity(g, Setting.PenWeaponAmmoSpawn, entity);
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
            graphics.DrawLine(pen, entity.PositionLine.pointA, entity.PositionLine.pointB);
        }
    }
}
