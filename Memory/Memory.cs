namespace Memory
{
    public static class Memory
    {
        private static class ConvertExtension
        {
            public static SModel ByteArrayToStructure<SModel>(byte[] bytesStructure) where SModel : struct
            {
                GCHandle handle = GCHandle.Alloc(bytesStructure, GCHandleType.Pinned);

                try
                {
                    return Marshal.PtrToStructure<SModel>(handle.AddrOfPinnedObject());
                }
                finally
                {
                    handle.Free();
                }
            }

            public static byte[] StructureToByteArray<SModel>(SModel modelStructure) where SModel : struct
            {
                int length = Marshal.SizeOf(modelStructure);

                byte[] array = new byte[length];

                IntPtr pointer = Marshal.AllocHGlobal(length);

                Marshal.StructureToPtr(modelStructure, pointer, true);
                Marshal.Copy(pointer, array, 0, length);
                Marshal.FreeHGlobal(pointer);

                return array;
            }
        }

        private static class ImportKernel32
        {
            [DllImport("kernel32.dll")]
            public static extern bool ReadProcessMemory(nint hProcess, nint lpBaseAddress, byte[] buffer, int size, out int lpNumberOfBytesRead);

            [DllImport("kernel32.dll")]
            public static extern bool WriteProcessMemory(nint hProcess, nint lpBaseAddress, byte[] buffer, int size, out int lpNumberOfBytesWritten);
        }

        public static bool BaseRead(nint processHandle, nint baseAddress, byte[] buffer, out int countReadBytes)
        {
            return ImportKernel32.ReadProcessMemory(processHandle, baseAddress, buffer, buffer.Length, out countReadBytes);
        }

        public static SModel ReadStruct<SModel>(nint processHandle, nint baseAddress) where SModel : struct
        {
            int ByteSize = Marshal.SizeOf(typeof(SModel));

            byte[] buffer = new byte[ByteSize];

            ImportKernel32.ReadProcessMemory(processHandle, baseAddress, buffer, buffer.Length, out int countReadBytes);

            return ConvertExtension.ByteArrayToStructure<SModel>(buffer);
        }


        public static byte[]? ReadBytes(nint processHandle, nint baseAddress, int length)
        {
            byte[] output = new byte[length];
            if (ImportKernel32.ReadProcessMemory(processHandle, baseAddress, output, output.Length, out int countReadBytes))
                return output;
            else
                return null;
        }

        public static int ReadBytesCount(nint processHandle, nint baseAddress, int length, out byte[]? output)
        {
            output = new byte[length];

            if (ImportKernel32.ReadProcessMemory(processHandle, baseAddress, output, length, out int countReadBytes))
                return countReadBytes;
            else
                return 0;
        }

        public static bool TryReadBytes(nint processHandle, nint baseAddress, ref byte[] output)
        {
            if (output is null)
                return false;
            else if (ImportKernel32.ReadProcessMemory(processHandle, baseAddress, output, output.Length, out int countReadBytes))
                return true;
            else
                return false;
        }

        public static string? ReadStringByEncoding(nint processHandle, nint baseAddress, int length, EncodeStringIn encoding)
        {
            var bytes = ReadBytes(processHandle, baseAddress, length);

            if (bytes is null)
                return null;

            try
            {
                return encoding switch
                {
                    EncodeStringIn.UTF8 => Encoding.UTF8.GetString(bytes),
                    EncodeStringIn.UTF32 => Encoding.UTF32.GetString(bytes),
                    EncodeStringIn.BigEndianUnicode => Encoding.BigEndianUnicode.GetString(bytes),
                    EncodeStringIn.Unicode => Encoding.Unicode.GetString(bytes),
                    EncodeStringIn.ASCII => Encoding.ASCII.GetString(bytes),
                    _ => null
                };
            }
            catch
            { return null; }
        }

        public static bool BaseWrite(nint processHandle, nint baseAddress, byte[] buffer, out int countWriteBytes)
        {
            return ImportKernel32.WriteProcessMemory(processHandle, baseAddress, buffer, buffer.Length, out countWriteBytes);
        }

        public static void WriteStruct<SModel>(nint processHandle, nint baseAddress, SModel Value) where SModel : struct
        {
            byte[] buffer = ConvertExtension.StructureToByteArray(Value);

            ImportKernel32.WriteProcessMemory(processHandle, baseAddress, buffer, buffer.Length, out int countWriteBytes);
        }

        public static int WriteBytesReturnCount(nint processHandle, nint baseAddress, byte[] byteArray)
        {
            if (byteArray is null) return 0;

            if (ImportKernel32.WriteProcessMemory(processHandle, baseAddress, byteArray, byteArray.Length, out int countWriteBytes))
            {
                return countWriteBytes;
            }

            return 0;
        }

        public static void WriteBytes(nint processHandle, nint baseAddress, byte[] byteArrey)
        {
            ImportKernel32.WriteProcessMemory(processHandle, baseAddress, byteArrey, byteArrey.Length, out int countWriteBytes);
        }

        public static bool TryWriteBytes(nint processHandle, nint baseAddress, byte[] byteArrey)
        {
            if (byteArrey is null)
                return false;
            else if (ImportKernel32.WriteProcessMemory(processHandle, baseAddress, byteArrey, byteArrey.Length, out int countWriteBytes))
                return true;
            else
                return false;
        }

        public static void WriteStringByEncoding(nint processHandle, nint baseAddress, string value, EncodeStringIn encoding)
        {
            if (value is null) return;

            byte[]? bytes;

            try
            {
                bytes = encoding switch
                {
                    EncodeStringIn.UTF8 => Encoding.UTF8.GetBytes(value),
                    EncodeStringIn.UTF32 => Encoding.UTF32.GetBytes(value),
                    EncodeStringIn.BigEndianUnicode => Encoding.BigEndianUnicode.GetBytes(value),
                    EncodeStringIn.Unicode => Encoding.Unicode.GetBytes(value),
                    EncodeStringIn.ASCII => Encoding.ASCII.GetBytes(value),
                    _ => null
                };
            }
            catch
            {
                return;
            }

            if (bytes is null) return;

            WriteBytes(processHandle, baseAddress, bytes);
        }
    }

    public enum EncodeStringIn : byte
    {
        UTF8,
        UTF32,
        BigEndianUnicode,
        Unicode,
        ASCII,
    }
}