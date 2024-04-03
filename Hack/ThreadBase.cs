namespace Hack;

public abstract class ThreadBase : IDisposable
{
    protected bool IsWorkingThread { get; set; } = true;
    protected virtual TimeSpan UpdateTime { get; set; } = TimeSpan.FromMilliseconds(5);
    protected virtual TimeSpan PauseTime { get; set; } = TimeSpan.FromMilliseconds(100);
    protected Thread ThreadCheat { get; private set; }

    public virtual bool IsRunning { get; set; } = true;

    public ThreadBase()
        => ThreadCheat = new Thread(ThreadStart);

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

                Thread.Sleep(UpdateTime);
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
