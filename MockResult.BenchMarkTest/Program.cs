// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using MockResult;
using MockResult.BenchMarkTest;

Console.WriteLine("Begin Running");
BenchmarkRunner.Run<Test>();
Console.ReadKey();
