namespace Hack;

public class AimBot : ThreadBase
{
    private readonly GameProcess gameProcess;

    public bool TargetTank { get; set; } = true;
    public bool TargetWitch { get; set; } = true;
    public bool TargetSpitter { get; set; } = true;
    public bool TargetSmoker { get; set; } = true;
    public bool TargetBoomer { get; set; } = true;
    public bool TargetJockey { get; set; } = true;
    public bool TargetCharger { get; set; } = true;
    public bool TargetHunter { get; set; } = true;
    public bool TargetInfected { get; set; } = false;

    public AimBot(Data data, WindowInformation windowInformation, GameProcess gameProcess)
    {
        Data = data;
        WindowInformation = windowInformation;
        this.gameProcess = gameProcess;
        UpdateTime = TimeSpan.FromMilliseconds(20);
    }

    public Data Data { get; }
    public WindowInformation WindowInformation { get; }

    public override void Update()
    {
        if (gameProcess.IsRunningGame)
        {
            var size = WindowInformation.WindowRectangleClient.Size;
            var entity = Data.Entities
                .Where(e => e.IsAlive && CheckValidPositionAimOnScreen(size, e.PositionAim) && CheckIfTargetModelValid(e.ClassId))
                .MaxBy(e => e.PositionBox.Height);


            if (Mouse.IsPressedLeftButton && entity is not null)
            {
                var center = TakeCenter(size, entity.PositionAim);
                Mouse.SetMouse(center);
            }
        }
    }


    private bool CheckIfTargetModelValid(ClassID id)
    {
        return id switch
        {
            ClassID.Tank => TargetTank,
            ClassID.Witch => TargetWitch,
            ClassID.Spitter => TargetSpitter,
            ClassID.Smoker => TargetSmoker,
            ClassID.Boomer => TargetBoomer,
            ClassID.Jockey => TargetJockey,
            ClassID.Charger => TargetCharger,
            ClassID.Hunter => TargetHunter,
            ClassID.Infected => TargetInfected,
            _ => false,
        };
    }

    private bool CheckValidPositionAimOnScreen(Size sizeWindow, Point positionAim)
    {
        return positionAim.X < sizeWindow.Width && positionAim.X > 0 && positionAim.Y < sizeWindow.Height && positionAim.Y > 0;
    }

    private Point TakeCenter(Size sizeWindow, Point positionAim)
    {
        return new Point(positionAim.X - sizeWindow.Width / 2, positionAim.Y - sizeWindow.Height / 2);
    }
}

