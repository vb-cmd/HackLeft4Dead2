

namespace Hack;

public class GameProcess : IDisposable
{
    private const string
         PROCESS_LEFT4DEAD2 = "left4dead2",
         MODULE_CLIENT = "client.dll",
         MODULE_ENGINE = "engine.dll";

    public bool IsRunningGame
    {
       get => !ProcessGame.Process.HasExited;
    }

    public ProcessAdapter ProcessGame { get; private set; }
    public ProcessModuleAdapter ModuleClient { get; private set; }
    public ProcessModuleAdapter ModuleEngine { get; private set; }


    public bool Search()
    {
        return SearchProcess() && SearchModuleClient() && SearchModuleEngine();
    }

    private bool SearchProcess()
    {
        if (ProcessGame is null)
            ProcessGame = ProcessAdapter.GetProcessByName(PROCESS_LEFT4DEAD2);
        
        if (ProcessGame is null) return false;

        return true;
    }

    private bool SearchModuleClient()
    {
        if (ModuleClient is null) ModuleClient = ProcessGame.GetProcessModuleAdapterByName(MODULE_CLIENT);
        if (ModuleClient is null) return false;

        return true;
    }

    private bool SearchModuleEngine()
    {
        if (ModuleEngine is null) ModuleEngine = ProcessGame.GetProcessModuleAdapterByName(MODULE_ENGINE);
        if (ModuleEngine is null) return false;

        return true;
    }

    public void Dispose()
    {
        ProcessGame?.Dispose();
        ModuleClient?.Dispose();
        ModuleEngine?.Dispose();
    }
}
