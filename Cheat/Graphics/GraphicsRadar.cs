namespace CheatL4D2.Graphics;

public class GraphicsRadar : IGraphics
{
    private readonly Data data;

    public SettingGraphicsRadar Setting { get; set; }

    public GraphicsRadar(Data data)
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
            Entity entity;

            SetPositionRadarOnWindow(e.ClipRectangle.Size);
            RenderRectangle(g);
            RenderPlayer(g);


            for (int i = 1; i < data.Entities.Length; i++)
            {
                entity = data.Entities[i];

                RenderModel(g, entity, player);
            }
        }
    }

    private static int CalculateObjectPositionOnRadar(int localPlayer, int entity, int size)
    {
        float RadarX = (localPlayer - entity) * 0.1f;
        RadarX += size / 2;
        return (int)RadarX;
    }

    private void SetPositionRadarOnWindow(Size size)
    {
        var rectangle = Setting.CustomPositionAndSize;

        rectangle.X = Setting.PositionHorizontal switch
        {
            PositionHorizontal.Left => 0,
            PositionHorizontal.Center => (size.Width / 2) - (Setting.CustomPositionAndSize.Width / 2),
            PositionHorizontal.Right => size.Width - Setting.CustomPositionAndSize.Width,
            PositionHorizontal.Default => Setting.CustomPositionAndSize.X,
            _ => throw new ArgumentException(),
        };

        rectangle.Y = Setting.PositionVertical switch
        {
            PositionVertical.Top => 0,
            PositionVertical.Center => (size.Height / 2) - (Setting.CustomPositionAndSize.Height / 2),
            PositionVertical.Bottom => size.Height - Setting.CustomPositionAndSize.Height,
            PositionVertical.Default => Setting.CustomPositionAndSize.Y,
            _ => throw new ArgumentException(),
        };

        Setting.CustomPositionAndSize = rectangle;
    }

    private void RenderModel(SystemGraphics g, Entity entity, Entity entityPlayer)
    {
        SettingModel settingModel = Setting.GetSettingModel(entity);

        if (settingModel is null) return;

        if (settingModel.IsVisible) RenderObject(g, settingModel, entity, entityPlayer);
    }

    private void RenderObject(SystemGraphics graphics, SettingModel settingModel, Entity entity, Entity player)
    {
        if (!entity.IsAlive) return;

        var rectangle = Setting.CustomPositionAndSize;
        var boxSize = Setting.SizeObject;

        var x = rectangle.X + CalculateObjectPositionOnRadar((int)player.PositionRadar.X, (int)entity.PositionRadar.X, rectangle.Width);
        var y = rectangle.Y + CalculateObjectPositionOnRadar((int)player.PositionRadar.Y, (int)entity.PositionRadar.Y, rectangle.Height);


        if (x > rectangle.X && y > rectangle.Y
            && x < (rectangle.X + rectangle.Width) && y < (rectangle.Y + rectangle.Height))
        {
            Rectangle rectagle = new(x - boxSize / 2, y - boxSize / 2, boxSize, boxSize);

            graphics.FillEllipse(settingModel.Pen.Brush, rectagle);
        }
    }

    private void RenderRectangle(SystemGraphics graphics)
        => graphics.FillRectangle(Setting.BrushRadar, Setting.CustomPositionAndSize);


    private void RenderPlayer(SystemGraphics graphics)
        => graphics.FillEllipse(Setting.BrushPlayer,
            Setting.CustomPositionAndSize.X + (Setting.CustomPositionAndSize.Width / 2 - Setting.SizePlayer / 2),
            Setting.CustomPositionAndSize.Y + (Setting.CustomPositionAndSize.Height / 2 - Setting.SizePlayer / 2),
            Setting.SizePlayer, Setting.SizePlayer);

}
