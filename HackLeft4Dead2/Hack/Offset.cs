using System.Globalization;
using System.IO;

namespace HackLeft4Dead2.Hack
{
    public static class Offset
    {
        public const int MAX_OBJECT = 800;

        public static readonly int ForceJump;

        public static readonly int Engine_View_Matrix;

        public static readonly int CLient_LocalPlayer;
        public static readonly int Client_LocalPlayer_FlagJump;

        public static readonly int Client_EntityList;
        public static readonly int Client_EntityList_ID;
        public static readonly int Client_EntityList_Health;
        public static readonly int Client_EntityList_Team;
        public static readonly int Client_EntityList_Vector3;
        public static readonly int Client_EntityList_Alive;
        public static readonly int Client_EntityList_ClassId;
        public static readonly int Client_EntityList_TopModel;

        static Offset()
        {
            string PATH_FILE_OFFSETS = Environment.CurrentDirectory + "/Hack/File/offsets.txt";

            var data = File
                .ReadAllLines(PATH_FILE_OFFSETS)
                .Select(a => a.Split(" - "));

            foreach (var item in data)
            {
                var offsetProperty = typeof(Offset)
                    .GetFields()
                    .SingleOrDefault(a => a.Name == item[0]);

                if (offsetProperty is not null)
                    offsetProperty.SetValue(null, int.Parse(item[1], NumberStyles.HexNumber));
            }
        }
    }
}
