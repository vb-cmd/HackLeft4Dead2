namespace HackLeft4Dead2.Hack
{
    public static class Offset
    {
        public const int MAX_OBJECTS = 800;

        //Engine DLL
        public static readonly int ViewMatrix = 0x600F9C;

        //Client DLL
        public static readonly int ForceJump = 0x757DF0;

        //Base address LocalPlayer
        public static readonly int LocalPlayer = 0x724B58;
        //Offset for LocalPlayer
        public static readonly int FlagJump = 0xF0;

        //Base address EntityList
        public static readonly int EntityList = 0x748524;
        //Offset for EntityList
        public static readonly int EntityID = 0x50;
        public static readonly int EntityHealth = 0xE4;
        public static readonly int EntityTeam = 0xDC;
        public static readonly int EntityVector3 = 0x8C;
        public static readonly int EntityAlive = 0x158;
        public static readonly int EntityClassId = 0x1;
        public static readonly int EntityTopModel = 0xF4;
    }
}
