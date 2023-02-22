namespace HackLeft4Dead2.Hack
{
    public class BunnyHop : ThreadBase
    {
        private readonly GameProcess process;

        public BunnyHop(GameProcess process)
        {
            this.process = process;
        }
#nullable disable
        public override void Update()
        {
            if (process.IsWorkingGame)
            {
                if (Keyboard.IsPressedSpace)
                {
                    nint localPlayer = process.ModuleClient.MemoryReadStruct<int>(Offset.CLientLocalPlayer);

                    var flag = process.ProcessGame.MemoryReadStruct<int>(localPlayer + Offset.ClientLocalPlayerFlagJump);

                    // Check if the player is jumping
                    int statusJump = flag switch
                    {
                        131 or 129 or 641 or 643 => 5, /* Jump */
                        _ => 4 /* No Jump */
                    };

                    process.ModuleClient.MemoryWriteStruct(Offset.ClientForceJump, statusJump);
                }
            }
        }
    }

}
