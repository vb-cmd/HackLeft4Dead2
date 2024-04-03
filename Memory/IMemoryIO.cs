namespace Memory;

internal interface IMemoryIO
{
    public SModel ReadStruct<SModel>(nint baseAddress) where SModel : struct;
    public byte[] ReadBytes(nint baseAddress, int lenght);
    public void WriteStruct<SModel>(nint baseAddress, SModel model) where SModel : struct;
    public void WriteBytes(nint baseAddress, byte[] model);
}
