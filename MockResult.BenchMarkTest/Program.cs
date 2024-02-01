// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using MockResult;
using MockResult.BenchMarkTest;
using System.Text.Json;

Console.WriteLine("Begin Running");
BenchmarkRunner.Run<Test>();
