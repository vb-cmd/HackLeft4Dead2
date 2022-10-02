using System.Diagnostics;
using System.Numerics;

namespace HackLeft4Dead2.Data
{
    public class DataEntities : ThreadBase
    {
        private readonly GameProcess process;
        private readonly WindowInformation window;
        private object locked = new();
        private Entity[] entities;

        public Entity[] Entities
        {
            get
            {
                lock (locked)
                    return entities;
            }
            private set
            {
                lock (locked)
                    entities = value;
            }
        }

        public DataEntities(GameProcess process, WindowInformation window)
        {
            Entities = Enumerable.Range(0, Offset.MAX_PLAYER)
                .Select(i => new Entity()
                {
                    Id = i,
                    PositionBox = Rectangle.Empty,
                    Team = Team.Unknown
                })
                .ToArray();
            this.process = process;
            this.window = window;
        }

        public override void Update()
        {
            var windowSize = window.WindowRectangleClient;
            var matrix = process.ModuleEngine.MemoryReadStruct<Matrix4x4>(Offset.Engine_View_Matrix);

            for (int i = 0; i < Entities.Length; i++)
            {
                var entity = process.ModuleClient.MemoryReadStruct<nint>(Offset.Client_EntityList + i * 0x8);

                var team = (Team)process.ProcessGame.MemoryReadStruct<int>(entity + Offset.Client_EntityList_Team);
                var health = process.ProcessGame.MemoryReadStruct<int>(entity + Offset.Client_EntityList_Health);
                var xyz = process.ProcessGame.MemoryReadStruct<Vector3>(entity + Offset.Client_EntityList_Vector3);



                var positionTop = MathExtension.WorldOfScreen(matrix, new Vector3(xyz.X, xyz.Y, xyz.Z + 58), windowSize.Size);
                var positionBotton = MathExtension.WorldOfScreen(matrix, new Vector3(xyz.X, xyz.Y, xyz.Z), windowSize.Size);


                Entities[i].Team = team;
                Entities[i].Health = health;
                Entities[i].PositionLine = (new(windowSize.Width / 2, windowSize.Height), new(positionTop.X, positionTop.Y));

                Debug.WriteLineIf(i == 1, $"{Entities[i].PositionLine}");

                Entities[i].PositionRadar = new(xyz.X, xyz.Y);

                Entities[i].PositionBox = new Rectangle
                {
                    Location = new Point(positionTop.X - (positionTop.Y - positionBotton.Y) / 4, positionBotton.Y),
                    Size = new Size((positionTop.Y - positionBotton.Y) / 2, (positionTop.Y - positionBotton.Y))
                };
            }
        }
    }
}
