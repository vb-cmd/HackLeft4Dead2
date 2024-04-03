namespace Hack;

public class Data : ThreadBase
{
    private readonly GameProcess process;
    private readonly WindowInformation window;

    public Entity[] Entities { get; private set; }

    public Data(GameProcess process, WindowInformation window)
    {
        Entities = Enumerable.Range(0, Offset.MAX_OBJECTS).Select(i => new Entity() { Id = i }).ToArray();

        this.process = process ?? throw new NullReferenceException(nameof(process));
        this.window = window ?? throw new NullReferenceException(nameof(window));
    }

    public override void Update()
    {
        if (process.IsRunningGame)
        {
            var windowSize = window.WindowRectangleClient;
            var matrix = process.ModuleEngine.ReadStruct<Matrix4x4>(Offset.ViewMatrix);

            for (int i = 0; i < Entities.Length; i++)
            {
                var entity = process.ModuleClient.ReadStruct<nint>(Offset.EntityList + i * 0x8);
                var xyz = process.ProcessGame.ReadStruct<Vector3>(entity + Offset.EntityVector3);
                var topModel = process.ProcessGame.ReadStruct<float>(entity + Offset.EntityTopModel);
                var positionTop = matrix.WorldOfScreen(new Vector3(xyz.X, xyz.Y, xyz.Z), windowSize.Size);
                var positionBotton = matrix.WorldOfScreen(new Vector3(xyz.X, xyz.Y, xyz.Z + topModel), windowSize.Size);

                Entities[i].Id = process.ProcessGame.ReadStruct<int>(entity + Offset.EntityID);
                Entities[i].Team = (Team)process.ProcessGame.ReadStruct<int>(entity + Offset.EntityTeam);
                Entities[i].IsAlive = process.ProcessGame.ReadStruct<bool>(entity + Offset.EntityAlive);
                Entities[i].ClassId = (ClassID)process.ProcessGame.ReadStruct<int>(entity + Offset.EntityClassId);
                Entities[i].Health = process.ProcessGame.ReadStruct<int>(entity + Offset.EntityHealth);
                Entities[i].PositionLine = (new(windowSize.Width / 2, windowSize.Height), new(positionTop.X, positionTop.Y));
                Entities[i].PositionRadar = new(xyz.X, xyz.Y);
                Entities[i].TopModel = topModel;
                Entities[i].PositionAim = matrix.WorldOfScreen(new Vector3(xyz.X, xyz.Y, xyz.Z + topModel / 2), windowSize.Size);
                Entities[i].PositionBox = new Rectangle
                {
                    Location = new Point(positionTop.X - (positionTop.Y - positionBotton.Y) / 4, positionBotton.Y),
                    Size = new Size((positionTop.Y - positionBotton.Y) / 2, positionTop.Y - positionBotton.Y)
                };
            }
        }
    }
}
