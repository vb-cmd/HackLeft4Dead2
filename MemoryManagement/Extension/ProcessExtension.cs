namespace MemoryManagement
{
    public static class ProcessExtension
    {
        public static Process? GetSingleProcessByName(string name)
        {
            return Process.GetProcesses()
                .SingleOrDefault(p=> p.ProcessName == name);
        }
        public static ProcessModuleExtension[] GetProcessModuleExtensions(this Process process)
        {
            return process.Modules.OfType<ProcessModule>()
                .Select(m => new ProcessModuleExtension(process, m))
                .ToArray();
        }

        public static ProcessModuleExtension? GetProcessModuleExtensionByName(this Process process, string name)
        {
            var module = process.Modules.OfType<ProcessModule>()
                .SingleOrDefault(m => m.ModuleName == name);

            return module is not null 
                ? new ProcessModuleExtension(process, module) 
                : null;
        }

        public static SModel MemoryReadStruct<SModel>(this Process process,nint baseAddress) where SModel: struct
        {
            return Memory.ReadStruct<SModel>(process.Handle, baseAddress);
        }

        public static byte[]? MemoryReadBytes(this Process process, nint baseAddress, int lenght)
        {
            return Memory.ReadBytes(process.Handle, baseAddress, lenght);
        }

        public static void MemoryWriteStruct<SModel>(this Process process, nint baseAddress, SModel model) where SModel : struct
        {
            Memory.WriteStruct(process.Handle, baseAddress, model);
        }

        public static void MemoryWriteBytes(this Process process, nint baseAddress, byte[] model)
        {
            Memory.WriteBytes(process.Handle, baseAddress, model);
        }
    }
}
