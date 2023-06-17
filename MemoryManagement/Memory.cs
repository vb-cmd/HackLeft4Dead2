using System.Runtime.InteropServices;
using System.Text;

namespace MemoryManagement
{
    public static class Memory
    {
        private static class ImportKernel32
        {
            [DllImport("kernel32.dll")]
            public static extern bool ReadProcessMemory(nint hProcess, nint lpBaseAddress, byte[] buffer, int size, out int lpNumberOfBytesRead);

            [DllImport("kernel32.dll")]
            public static extern bool WriteProcessMemory(nint hProcess, nint lpBaseAddress, byte[] buffer, int size, out int lpNumberOfBytesWritten);
        }

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

        public static SModel ReadStruct<SModel>(nint processHandle, nint baseAddress) where SModel : struct
        {
            int ByteSize = Marshal.SizeOf(typeof(SModel));

            byte[] buffer = new byte[ByteSize];

            ImportKernel32.ReadProcessMemory(processHandle, baseAddress, buffer, buffer.Length, out int countReadBytes);

            return ConvertExtension.ByteArrayToStructure<SModel>(buffer);
        }


        public static byte[] ReadBytes(nint processHandle, nint baseAddress, int length)
        {
            byte[] output = new byte[length];
            ImportKernel32.ReadProcessMemory(processHandle, baseAddress, output, output.Length, out int countReadBytes);
            return output;
        }

        public static bool TryReadBytes(nint processHandle, nint baseAddress, ref byte[] output, out int countReadBytes)
            => ImportKernel32.ReadProcessMemory(processHandle, baseAddress, output, output.Length, out countReadBytes);

        

        public static string? ReadStringByEncoding(nint processHandle, nint baseAddress, int length, EncodeStringIn encoding)
        {
            var bytes = ReadBytes(processHandle, baseAddress, length);

            return encoding switch
            {
                EncodeStringIn.UTF8 => Encoding.UTF8.GetString(bytes),
                EncodeStringIn.UTF32 => Encoding.UTF32.GetString(bytes),
                EncodeStringIn.BigEndianUnicode => Encoding.BigEndianUnicode.GetString(bytes),
                EncodeStringIn.Unicode => Encoding.Unicode.GetString(bytes),
                EncodeStringIn.ASCII => Encoding.ASCII.GetString(bytes),
                _ => throw new Exception("Encoding not found.")
            };
        }

        public static void WriteStruct<SModel>(nint processHandle, nint baseAddress, SModel Value) where SModel : struct
        {
            byte[] buffer = ConvertExtension.StructureToByteArray(Value);

            ImportKernel32.WriteProcessMemory(processHandle, baseAddress, buffer, buffer.Length, out int countWriteBytes);
        }

        public static void WriteBytes(nint processHandle, nint baseAddress, byte[] byteArrey)
            => ImportKernel32.WriteProcessMemory(processHandle, baseAddress, byteArrey, byteArrey.Length, out int countWriteBytes);


        public static bool TryWriteBytes(nint processHandle, nint baseAddress, byte[] byteArrey, out int countWriteBytes)
            => ImportKernel32.WriteProcessMemory(processHandle, baseAddress, byteArrey, byteArrey.Length, out countWriteBytes);


        public static void WriteStringByEncoding(nint processHandle, nint baseAddress, string value, EncodeStringIn encoding)
        {
            byte[] bytes;

            bytes = encoding switch
            {
                EncodeStringIn.UTF8 => Encoding.UTF8.GetBytes(value),
                EncodeStringIn.UTF32 => Encoding.UTF32.GetBytes(value),
                EncodeStringIn.BigEndianUnicode => Encoding.BigEndianUnicode.GetBytes(value),
                EncodeStringIn.Unicode => Encoding.Unicode.GetBytes(value),
                EncodeStringIn.ASCII => Encoding.ASCII.GetBytes(value),
                _ => throw new Exception("Encoding not found.")
            };


            WriteBytes(processHandle, baseAddress, bytes);
        }
    }
}