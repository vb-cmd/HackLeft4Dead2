using HackLeft4Dead2.Settings;
using GraphicsGDI = System.Drawing.Graphics;

namespace HackLeft4Dead2.Graphics
{
    public class GraphicsBoxESP : IGraphics
    {
        public SettingGraphicsBoxESP Setting { get; set; }
        private readonly Data data;

        public GraphicsBoxESP(Data data)
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
                        SelectModel(g, entity);
                    }
                }
            }
        }

        private void SelectModel(GraphicsGDI g, Entity entity)
        {
            switch (entity.ClassId)
            {
                case ClassID.SurvivorPlayer:
                    RenderEntity(g, Setting.SurvivorPlayer, entity);
                    break;
                case ClassID.SurvivorBot:
                    RenderEntity(g, Setting.SurvivorBot, entity);
                    break;
                case ClassID.Hunter:
                    RenderEntity(g, Setting.Hunter, entity);
                    break;
                case ClassID.Tank:
                    RenderEntity(g, Setting.Tank, entity);
                    break;
                case ClassID.Spitter:
                    RenderEntity(g, Setting.Spitter, entity);
                    break;
                case ClassID.Smoker:
                    RenderEntity(g, Setting.Smoker, entity);
                    break;
                case ClassID.Boomer:
                    RenderEntity(g, Setting.Boomer, entity);
                    break;
                case ClassID.Jockey:
                    RenderEntity(g, Setting.Jockey, entity);
                    break;
                case ClassID.Charger:
                    RenderEntity(g, Setting.Charger, entity);
                    break;
                case ClassID.Witch:
                    RenderEntity(g, Setting.Witch, entity);
                    break;
                case ClassID.Infected:
                    RenderEntity(g, Setting.Infected, entity);
                    break;
                case ClassID.WeaponSpawn:
                    RenderObject(g, Setting.WeaponSpawn, entity);
                    break;
                case ClassID.WeaponAmmoSpawn:
                    RenderObject(g, Setting.WeaponAmmoSpawn, entity);
                    break;
                default:
                    break;
            }
        }

        private void RenderEntity(GraphicsGDI graphics, SettingModel settingModel, Entity entity)
        {
            if (entity.IsAlive && settingModel.IsVisible)
            {
                graphics.DrawRectangle(settingModel.Pen, entity.PositionBox);

                if (entity.Health > 0)
                {
                    //draw information about entity
                    string value = $"H:{entity.Health}";
                    graphics.DrawString(value, Setting.Font, Setting.FontBrush, entity.PositionBox.X, entity.PositionBox.Y - 15);
                }
            }
        }

        private void RenderObject(GraphicsGDI graphics, SettingModel settingModel, Entity entity)
        {
            if (settingModel.IsVisible)
            {
                var sizeObject = Setting.SizeObject;
                var rect = new Rectangle(entity.PositionBox.X - (sizeObject / 2), entity.PositionBox.Y - sizeObject, sizeObject, sizeObject);
                graphics.FillEllipse(settingModel.Pen.Brush, rect);
            }
        }

    }
}

