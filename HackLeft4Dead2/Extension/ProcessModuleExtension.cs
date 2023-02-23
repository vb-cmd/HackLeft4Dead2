namespace HackLeft4Dead2.Extension
{
    public class ProcessModuleExtension : IDisposable
    {
        public ProcessModuleExtension(Process process, ProcessModule module)
        {
            Process = process;
            Module = module;
        }

        public Process Process { get; }
        public ProcessModule Module { get; }

        public void Dispose()
        => Module?.Dispose();
        

        public SModel MemoryReadStruct<SModel>(nint baseAddress) where SModel : struct
        => Memory.ReadStruct<SModel>(Process.Handle, Module.BaseAddress + baseAddress);

        public void MemoryWriteStruct<SModel>(nint baseAddress, SModel model) where SModel : struct
        => Memory.WriteStruct(Process.Handle, Module.BaseAddress + baseAddress, model);
    }
}