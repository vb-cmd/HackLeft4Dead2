namespace HackLeft4Dead2.Hack
{
    public class GameProcess : ThreadBase
    {
        private const string
             PROCESS_LEFT4DEAD2 = "left4dead2",
             MODULE_CLIENT = "client.dll",
             MODULE_ENGINE = "engine.dll";

        public bool IsWorkingGame => (ProcessGame is not null) && (ModuleClient is not null) && (ModuleEngine is not null);

        private bool IsRunningGame
        {
            get
            {
                try
                {
                    Process.GetProcessById(ProcessGame.Id);
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
                catch (ArgumentException)
                {
                    return false;
                }
                return true;
            }
        }

        protected override TimeSpan SleepUpdateTime { get; set; } = TimeSpan.FromMilliseconds(100);
        protected override TimeSpan PauseTime { get; set; } = TimeSpan.FromMilliseconds(300);

        public Process ProcessGame { get; private set; }
        public ProcessModuleExtension ModuleClient { get; private set; }
        public ProcessModuleExtension ModuleEngine { get; private set; }


        public bool Search()
        {
            return SearchProcess() && SearchModuleClient() && SearchModuleEngine();
        }

        private bool SearchProcess()
        {
            if (ProcessGame is null) ProcessGame = ProcessExtension.GetSingleProcessByName(PROCESS_LEFT4DEAD2);
            if (ProcessGame is null || !IsRunningGame) return false;

            return true;
        }

        private bool SearchModuleClient()
        {
            if (ModuleClient is null) ModuleClient = ProcessGame.GetProcessModuleExtensionByName(MODULE_CLIENT);
            if (ModuleClient is null) return false;

            return true;
        }

        private bool SearchModuleEngine()
        {
            if (ModuleEngine is null) ModuleEngine = ProcessGame.GetProcessModuleExtensionByName(MODULE_ENGINE);
            if (ModuleEngine is null) return false;

            return true;
        }

        private void Clear()
        {
            ProcessGame?.Dispose();
            ModuleClient?.Dispose();
            ModuleEngine?.Dispose();

            ProcessGame = null;
            ModuleClient = null;
            ModuleEngine = null;
        }

        public override void Dispose()
        {
            this.Clear();
            base.Dispose();
        }

        public override void Update()
        {
            if (!Search()) Clear();
        }
    }
}
