namespace HackLeft4Dead2.Hack
{
    public class GameWindow : ThreadBase
    {
        private const string nameWindow = "Left 4 Dead 2 - Direct3D 9";

        public OverlayWindow OverlayWindow { get; private set; }
        public WindowInformation WindowInformation { get; private set; }

        public GameWindow()
        {
            OverlayWindow = new(nameWindow);
            WindowInformation = OverlayWindow.WindowInformation;
        }

        public override void Update()
        {
            WindowInformation.UpdateWindow();
            OverlayWindow.Update();

            base.IsRunning = WindowInformation.IsValid;
        }

        protected override void ThreadStart()
        {
            OverlayWindow.Show();

            while (IsWorkingThread)
            {
                Update();
                Thread.Sleep(IsRunning ? SleepUpdateTime : PauseTime);
            }

            OverlayWindow.Dispose();
        }
    }
}
