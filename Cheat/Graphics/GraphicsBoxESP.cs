namespace CheatL4D2.Graphics;

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
            for (int i = 1; i < data.Entities.Length; i++)
            {
                var entity = data.Entities[i];

                if (!entity.PositionBox.IsEmpty)
                {
                    RenderObject(e.Graphics, entity);
                }
            }
        }
    }

    private void RenderObject(SystemGraphics g, Entity entity)
    {
        SettingModel settingModel = Setting.GetSettingModel(entity);

        if (settingModel is null) return;

        if (entity.ClassId == ClassID.WeaponAmmoSpawn || entity.ClassId == ClassID.WeaponSpawn)
        {
            RenderWeaponOrAmmo(g, settingModel, entity);
            return;
        }

        RenderEntity(g, settingModel, entity);
    }

    private void RenderEntity(SystemGraphics graphics, SettingModel settingModel, Entity entity)
    {
        if (entity.IsAlive && settingModel.IsVisible)
        {
            graphics.DrawRectangle(settingModel.Pen, entity.PositionBox);

            string value = entity.Health > 0 ? $"{entity.ClassId}:{entity.Health}" : $"{entity.ClassId}";
            graphics.DrawString(value, Setting.Font, Setting.FontBrush, entity.PositionBox.X, entity.PositionBox.Y - 15);
        }
    }

    private void RenderWeaponOrAmmo(SystemGraphics graphics, SettingModel settingModel, Entity entity)
    {
        if (settingModel.IsVisible)
        {
            var sizeObject = Setting.SizeObject;
            var rect = new Rectangle(entity.PositionBox.X - sizeObject / 2, entity.PositionBox.Y - sizeObject, sizeObject, sizeObject);
            graphics.FillEllipse(settingModel.Pen.Brush, rect);
        }
    }

}

