namespace CheatL4D2.Graphics;

public class GraphicsLineESP : IGraphics
{
    private readonly Data data;
    public SettingEntityBase Setting { get; set; }

    public GraphicsLineESP(Data data)
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
                if (!entity.PositionLine.pointA.IsEmpty && !entity.PositionLine.pointB.IsEmpty)
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
            graphics.DrawLine(settingModel.Pen, entity.PositionLine.pointA, entity.PositionLine.pointB);
    }

    private void RenderWeaponOrAmmo(SystemGraphics graphics, SettingModel settingModel, Entity entity)
    {
        if (settingModel.IsVisible)
            graphics.DrawLine(settingModel.Pen, entity.PositionLine.pointA, entity.PositionLine.pointB);
    }
}
