# MemoryManagement
### How to use?

For example, how to read memory in process:
```C#
    var process = ProcessExtension.GetSingleProcessByName("NAME PROCESS");
    var value = process.MemoryReadStruct<int>(0x00001) // you can type an address such as hex(0x00) or int(1234) 
```

For example, how to write memory in process:
```C#
    var process = ProcessExtension.GetSingleProcessByName("NAME PROCESS");
    process.MemoryWriteStruct<int>(0x00001, 1234)
```

or you want to write a custom structure
```C#
public struct Example
{
    public int Y, X;
    public int Status;

    public Example(y,x, status)
    {
        Y = y;
        X = x;
        Status = status; 
    }
}
```

```C#
    var process = ProcessExtension.GetSingleProcessByName('NAME PROCESS');
    var example = new Example(2, 2, 1234)
    process.MemoryWriteStruct<Example>(0x00001, example)
```
