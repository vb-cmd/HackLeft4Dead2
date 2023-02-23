namespace HackLeft4Dead2.Hack
{
    public abstract class ThreadBase : IDisposable
    {
        protected bool IsWorkingThread = true;
        public virtual bool IsRunning { get; set; } = true;

        protected virtual TimeSpan SleepUpdateTime { get; set; } = TimeSpan.FromMilliseconds(10);
        protected virtual TimeSpan PauseTime { get; set; } = TimeSpan.FromMilliseconds(100);

        protected Thread ThreadCheat { get; private set; }

        public ThreadBase() 
        =>ThreadCheat = new Thread(ThreadStart);
        

        public abstract void Update();

        public virtual void Start()
        => ThreadCheat?.Start();
        

        protected virtual void ThreadStart()
        {
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
        } 

        public virtual void Dispose()
        {
            IsWorkingThread = false;
            ThreadCheat = null;
        }
    }
}
