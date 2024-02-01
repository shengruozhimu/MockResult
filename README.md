# MockResult
## Introduce
0. Until today,this toolkit does not recognize any interfaces and does not implement initialization of common interfaces. 
1. This tool can automatically create generic classes and fill all property fields with random values.
2. If the attribute has a default value, it is not filled in.for example, Boolean values,integers,DateTime.
3. If the attribute type is a string, fill in the attribute name.

## Example

```
MockConvert.SetLength(3); //Set default length for lists and arrays

MockConvert.SetDeep(4);//Set the recursion depth of the class to prevent infinite nesting

var apple = MockConvert.NewObject<Apple>(); //OK

var apples = MockConvert.NewObject<List<Apple>>(); //OK

var appleArray = MockConvert.NewObject<Apple[]>(); //OK

var example = MockConvert.NewObject<ExampleDemo>(); //OK

var exampleDic = MockConvert.NewObject<Dictionary<ExampleDemo, Apple>>(); //OK

var error = MockConvert.NewObject<IEnumerable<Apple>>(); //error is null

var error2 = MockConvert.NewObject<ICollection<Apple>>(); //error is null

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
    "OtherName":"OtherName",
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
2.Perhaps in the future, it can support initialization of common IEnumerable interfaces