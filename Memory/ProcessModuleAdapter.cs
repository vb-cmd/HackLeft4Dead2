namespace Memory;

public class ProcessModuleAdapter : IDisposable, IMemoryIO
{
    public ProcessModuleAdapter(ProcessAdapter process, ProcessModule module)
    {
        ProcessAdapter = process;
        Module = module;
    }

    public ProcessAdapter ProcessAdapter { get; }
    public ProcessModule Module { get; }

    public nint BaseAddress { get => Module.BaseAddress; }

    public void Dispose()
    => Module?.Dispose();


    public SModel ReadStruct<SModel>(nint baseAddress) where SModel : struct
    => MemoryIO.ReadStruct<SModel>(ProcessAdapter.Process.Handle, BaseAddress + baseAddress);


    public byte[] ReadBytes(nint baseAddress, int lenght)
    => MemoryIO.ReadBytes(ProcessAdapter.Handle, BaseAddress + baseAddress, lenght);


    public void WriteStruct<SModel>(nint baseAddress, SModel model) where SModel : struct
    => MemoryIO.WriteStruct(ProcessAdapter.Handle, BaseAddress + baseAddress, model);


    public void WriteBytes(nint baseAddress, byte[] model)
    => MemoryIO.WriteBytes(ProcessAdapter.Handle, BaseAddress + baseAddress, model);
}