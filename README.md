# MockResult
## Introduce
1. This tool can automatically create generic classes and fill all property fields with random values.
2. If the attribute has a default value, it is not filled in.for example, Boolean values,integers,DateTime.
3. If the attribute type is a string, fill in the attribute name.


## Example

```
var apple = MockConvert.NewObject<Apple>();

var example = MockConvert.NewObject<ExampleDemo>();

public class Apple 
{
    public Guid Id {  get; set; }
    public string Name { get; set; } = string.Empty;
    public string OtherName { get; set; } = "OtherName";
}

public struct ExampleDemo
{
    public byte P1 { get; set; }
    public byte P2 { get; set; }
    public byte P3 { get; set; }
    public byte P4 { get; set; }
    public DayType Day { get; set; }
}

public enum DayType :short
{
    HappyDay,
    SadDay,
}
```

The generated JSON string

```
{
    "MaxNAME":"1111",
    "Id":"56a62db5-627c-4cff-9761-7e4b97083014",
    "Name":"NAME",
    "Description":"DESCRIPTION"
}
```
```
{"P1":90,"P2":136,"P3":220,"P4":61,"Day":0}
```
### Functional iteration
1.plan to use more reasonable padding values to fill your newly created classes and structures.