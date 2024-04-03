namespace Memory;

public class ProcessAdapter: IMemoryIO, IDisposable
{
    public Process Process { get; private set; }

    public nint Handle { get => Process.Handle; }

    public ProcessAdapter(Process process)
    {
        Process = process;
    }

    public static ProcessAdapter? GetProcessByName(string name)
    {
        var process = Process.GetProcesses().SingleOrDefault(p => p.ProcessName.ToLower() == name.ToLower());

        return process is not null ? new ProcessAdapter(process) : null;
    }

    public ProcessModuleAdapter[] GetProcessModuleAdapters()
        => Process.Modules
        .OfType<ProcessModule>()
        .Select(m => new ProcessModuleAdapter(this, m))
        .ToArray();

    public ProcessModuleAdapter? GetProcessModuleAdapterByName(string name)
    {
        var module = Process.Modules.OfType<ProcessModule>().SingleOrDefault(m => m.ModuleName.ToLower() == name.ToLower());

        return module is not null ? new ProcessModuleAdapter(this, module) : null;
    }

    public SModel ReadStruct<SModel>(nint baseAddress) where SModel : struct
        => MemoryIO.ReadStruct<SModel>(Handle, baseAddress);


    public byte[] ReadBytes(nint baseAddress, int lenght)
        => MemoryIO.ReadBytes(Handle, baseAddress, lenght);


    public void WriteStruct<SModel>(nint baseAddress, SModel model) where SModel : struct
        => MemoryIO.WriteStruct(Handle, baseAddress, model);


    public void WriteBytes(nint baseAddress, byte[] model)
        => MemoryIO.WriteBytes(Handle, baseAddress, model);

    public void Dispose()
    {
        Process?.Dispose();
    }
}
