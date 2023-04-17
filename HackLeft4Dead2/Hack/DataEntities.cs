namespace HackLeft4Dead2.Hack
{
    public class DataEntities : ThreadBase
    {
        private readonly GameProcess process;
        private readonly WindowInformation window;

        public Entity[] Entities { get; private set; }

        public DataEntities(GameProcess process, WindowInformation window)
        {
            Entities = Enumerable.Range(0, Offset.MAX_OBJECTS)
                .Select(i => new Entity()
                {
                    Id = i,
                    PositionBox = Rectangle.Empty,
                    Team = Team.Unknown
                })
                .ToArray();

            this.process = process ?? throw new NullReferenceException(nameof(process));
            this.window = window ?? throw new NullReferenceException(nameof(window));
        }

        public override void Update()
        {
            if (process.IsWorkingGame)
            {
                var windowSize = window.WindowRectangleClient;
                var matrix = process.ModuleEngine.MemoryReadStruct<Matrix4x4>(Offset.EngineViewMatrix);

                for (int i = 0; i < Entities.Length; i++)
                {
                    var entity = process.ModuleClient.MemoryReadStruct<nint>(Offset.ClientEntityList + i * 0x8);

                    var id = process.ProcessGame.MemoryReadStruct<int>(entity + Offset.ClientEntityListID);
                    var team = (Team)process.ProcessGame.MemoryReadStruct<int>(entity + Offset.ClientEntityListTeam);
                    var health = process.ProcessGame.MemoryReadStruct<int>(entity + Offset.ClientEntityListHealth);
                    var alive = process.ProcessGame.MemoryReadStruct<bool>(entity + Offset.ClientEntityListAlive);
                    var classID = (ClassID)process.ProcessGame.MemoryReadStruct<int>(entity + Offset.ClientEntityListClassId);
                    var xyz = process.ProcessGame.MemoryReadStruct<Vector3>(entity + Offset.ClientEntityListVector3);
                    var topModel = process.ProcessGame.MemoryReadStruct<float>(entity + Offset.ClientEntityListTopModel);

                    var positionTop = matrix.WorldOfScreen(new Vector3(xyz.X, xyz.Y, xyz.Z), windowSize.Size);
                    var positionBotton = matrix.WorldOfScreen(new Vector3(xyz.X, xyz.Y, xyz.Z + topModel), windowSize.Size);
                    var positionAim = matrix.WorldOfScreen(new Vector3(xyz.X, xyz.Y, xyz.Z + (topModel / 2)), windowSize.Size);

                    Entities[i].Id = id;
                    Entities[i].Team = team;
                    Entities[i].Health = health;
                    Entities[i].PositionLine = (new(windowSize.Width / 2, windowSize.Height), new(positionTop.X, positionTop.Y));
                    Entities[i].PositionRadar = new(xyz.X, xyz.Y);
                    Entities[i].IsAlive = alive;
                    Entities[i].ClassId = classID;
                    Entities[i].TopModel = topModel;
                    Entities[i].PositionAim = positionAim;
                    Entities[i].PositionBox = new Rectangle
                    {
                        Location = new Point(positionTop.X - (positionTop.Y - positionBotton.Y) / 4, positionBotton.Y),
                        Size = new Size((positionTop.Y - positionBotton.Y) / 2, (positionTop.Y - positionBotton.Y))
                    };
                }
            }
        }
    }
}
