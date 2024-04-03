namespace Hack;

public class BunnyHop : ThreadBase
{
    private readonly GameProcess process;

    public BunnyHop(GameProcess process)
    {
        this.process = process;
    }

    public override void Update()
    {
        if (process.IsRunningGame && Keyboard.IsPressedSpace)
        {
            nint localPlayer = process.ModuleClient.ReadStruct<int>(Offset.LocalPlayer);

            var flag = process.ProcessGame.ReadStruct<int>(localPlayer + Offset.FlagJump);

            // Check if the player is jumping
            int statusJump = flag switch
            {
                131 or 129 or 641 or 643 => 5, /* Jump */
                _ => 4 /* No Jump */
            };

            process.ModuleClient.WriteStruct(Offset.ForceJump, statusJump);
        }
    }
}
