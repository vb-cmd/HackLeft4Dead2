using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackLeft4Dead2.Data
{
    public class GameWindow : ThreadBase
    {
        private const string nameWindow = "Left 4 Dead 2 - Direct3D 9";

        public OverlayWindow OverlayWindow { get; private set; }
        public WindowInformation WindowInformation { get; private set; }

        public GameWindow()
        {
            WindowInformation = new(nameWindow);
            OverlayWindow = new(WindowInformation);
        }

        public override void Update()
        {
            WindowInformation.UpdateWindow();
            OverlayWindow.Update();
        }

        protected override void ThreadStart()
        {
            OverlayWindow.Show();

            while (IsWorkingThread)
            {
                if (IsRunning)
                {
                    Update();

                    Thread.Sleep(SleepUpdateTime);
                }
                else
                {
                    Thread.Sleep(PauseTime);
                }
            }

            OverlayWindow.Dispose();
        }
    }
}
