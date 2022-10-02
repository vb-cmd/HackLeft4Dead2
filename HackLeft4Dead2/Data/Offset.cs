using System.Globalization;
using System.IO;

namespace HackLeft4Dead2.Data
{
    public static class Offset
    {
        private static readonly string PATH_FILE_OFFSETS = Environment.CurrentDirectory + "/Data/File/offsets.txt";

        public const int MAX_PLAYER = 32;
        public static readonly int ForceJump;
        public static readonly int CLient_LocalPlayer;
        public static readonly int Client_LocalPlayer_FlagJump;
        public static readonly int Engine_View_Matrix;
        public static readonly int Client_EntityList;
        public static readonly int Client_EntityList_Health;
        public static readonly int Client_EntityList_Team;
        public static readonly int Client_EntityList_Vector3;

        static Offset()
        {
            var data = File.ReadAllLines(PATH_FILE_OFFSETS).Select(a =>
         {
             return a.Split(" - ");
         });

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
