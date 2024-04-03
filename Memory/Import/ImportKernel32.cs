namespace Memory.Import;

internal static class ImportKernel32
{
    [DllImport("kernel32.dll")]
    public static extern bool ReadProcessMemory(nint hProcess, nint lpBaseAddress, byte[] buffer, int size, out int lpNumberOfBytesRead);

    [DllImport("kernel32.dll")]
    public static extern bool WriteProcessMemory(nint hProcess, nint lpBaseAddress, byte[] buffer, int size, out int lpNumberOfBytesWritten);
}