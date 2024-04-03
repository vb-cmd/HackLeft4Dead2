namespace Memory;

internal static class MemoryIO
{
    public static SModel ReadStruct<SModel>(nint processHandle, nint baseAddress) where SModel : struct
    {
        int ByteSize = Marshal.SizeOf(typeof(SModel));

        byte[] buffer = new byte[ByteSize];

        ImportKernel32.ReadProcessMemory(processHandle, baseAddress, buffer, buffer.Length, out int countReadBytes);

        return Helper.Convert.ByteArrayToStructure<SModel>(buffer);
    }


    public static byte[] ReadBytes(nint processHandle, nint baseAddress, int length)
    {
        byte[] output = new byte[length];
        ImportKernel32.ReadProcessMemory(processHandle, baseAddress, output, output.Length, out int countReadBytes);
        return output;
    }

    public static bool TryReadBytes(nint processHandle, nint baseAddress, ref byte[] output, out int countReadBytes)
        => ImportKernel32.ReadProcessMemory(processHandle, baseAddress, output, output.Length, out countReadBytes);



    public static string? ReadStringByEncoding(nint processHandle, nint baseAddress, int length, EncodeStringTo encoding)
    {
        var bytes = ReadBytes(processHandle, baseAddress, length);

        return encoding switch
        {
            EncodeStringTo.UTF8 => Encoding.UTF8.GetString(bytes),
            EncodeStringTo.UTF32 => Encoding.UTF32.GetString(bytes),
            EncodeStringTo.BigEndianUnicode => Encoding.BigEndianUnicode.GetString(bytes),
            EncodeStringTo.Unicode => Encoding.Unicode.GetString(bytes),
            EncodeStringTo.ASCII => Encoding.ASCII.GetString(bytes),
            _ => throw new Exception("Encoding not found.")
        };
    }

    public static void WriteStruct<SModel>(nint processHandle, nint baseAddress, SModel Value) where SModel : struct
    {
        byte[] buffer = Helper.Convert.StructureToByteArray(Value);

        ImportKernel32.WriteProcessMemory(processHandle, baseAddress, buffer, buffer.Length, out int countWriteBytes);
    }

    public static void WriteBytes(nint processHandle, nint baseAddress, byte[] byteArrey)
        => ImportKernel32.WriteProcessMemory(processHandle, baseAddress, byteArrey, byteArrey.Length, out int countWriteBytes);


    public static bool TryWriteBytes(nint processHandle, nint baseAddress, byte[] byteArrey, out int countWriteBytes)
        => ImportKernel32.WriteProcessMemory(processHandle, baseAddress, byteArrey, byteArrey.Length, out countWriteBytes);


    public static void WriteStringByEncoding(nint processHandle, nint baseAddress, string value, EncodeStringTo encoding)
    {
        byte[] bytes;

        bytes = encoding switch
        {
            EncodeStringTo.UTF8 => Encoding.UTF8.GetBytes(value),
            EncodeStringTo.UTF32 => Encoding.UTF32.GetBytes(value),
            EncodeStringTo.BigEndianUnicode => Encoding.BigEndianUnicode.GetBytes(value),
            EncodeStringTo.Unicode => Encoding.Unicode.GetBytes(value),
            EncodeStringTo.ASCII => Encoding.ASCII.GetBytes(value),
            _ => throw new Exception("Encoding not found.")
        };


        WriteBytes(processHandle, baseAddress, bytes);
    }
}