// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using MockResult;
using MockResult.BenchMarkTest;
using System.Collections.Generic;
using System.Text.Json;

Console.WriteLine("Begin Running");
#if DEBUG

MockConvert.SetLength(3); 

MockConvert.SetDeep(4);

var apple = MockConvert.NewObject<Apple>();

var apples = MockConvert.NewObject<List<Apple>>();

var appleArray = MockConvert.NewObject<Apple[]>();

var example = MockConvert.NewObject<ExampleDemo>();

var exampleDic = MockConvert.NewObject<Dictionary<ExampleDemo, Apple>>();

var error = MockConvert.NewObject<IEnumerable<Apple>>();

var error2 = MockConvert.NewObject<ICollection<Apple>>();

var error3 = MockConvert.NewObject<IList<Apple>>();
#endif
#if RELEASE
BenchmarkRunner.Run<Test>();
#endif
