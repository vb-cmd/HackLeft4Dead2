namespace HackLeft4Dead2.Features
{
    public class BunnyHop : ThreadBase
    {
        private readonly GameProcess process;

        public BunnyHop(GameProcess process)
        {
            this.process = process;
        }

        public override void Update()
        {
            if (Keyboard.IsPressedSpace)
            {
                nint localPlayer = process.ModuleClient.MemoryReadStruct<int>(Offset.CLient_LocalPlayer);

                var flag = process.ProcessGame.MemoryReadStruct<int>(localPlayer + Offset.Client_LocalPlayer_FlagJump);

                if (flag == 131 || flag == 129)
                {
                    process.ModuleClient.MemoryWriteStruct(Offset.ForceJump, (int)JumpState.Jump);
                }
                else
                {
                    process.ModuleClient.MemoryWriteStruct(Offset.ForceJump, (int)JumpState.NoJump);
                }
            }
        }

        private enum JumpState
        {
            NoJump = 4,
            Jump = 5
        }
    }

}
