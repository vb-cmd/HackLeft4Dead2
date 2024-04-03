namespace Memory.Helper;

internal static class Convert
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

        nint pointer = Marshal.AllocHGlobal(length);

        Marshal.StructureToPtr(modelStructure, pointer, true);
        Marshal.Copy(pointer, array, 0, length);
        Marshal.FreeHGlobal(pointer);

        return array;
    }
}