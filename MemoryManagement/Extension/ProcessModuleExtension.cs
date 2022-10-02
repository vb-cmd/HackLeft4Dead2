namespace MemoryManagement
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
        {
            Module?.Dispose();
        }

        public SModel MemoryReadStruct<SModel>(nint baseAddress) where SModel : struct
        {
            return Memory.ReadStruct<SModel>(Process.Handle, Module.BaseAddress + baseAddress);
        }

        public byte[]? MemoryReadBytes(nint baseAddress, int lenght)
        {
            return Memory.ReadBytes(Process.Handle, Module.BaseAddress + baseAddress, lenght);
        }

        public void MemoryWriteStruct<SModel>(nint baseAddress, SModel model) where SModel : struct
        {
            Memory.WriteStruct(Process.Handle, Module.BaseAddress + baseAddress, model);
        }

        public void MemoryWriteBytes(nint baseAddress, byte[] model)
        {
            Memory.WriteBytes(Process.Handle, Module.BaseAddress + baseAddress, model);
        }
    }
}