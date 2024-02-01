using AutoMapper;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MockResult.BenchMarkTest
{
    [RPlotExporter]
    //[AsciiDocExporter]
    //[MemoryDiagnoser]
    public class Test
    {
        [Benchmark]
        public void NewFruit_MockResult()
        {
            Enumerable.Range(1, 10000).Select(x => MockConvert.NewObject<Apple>()).ToArray();
        }
        static Fruit[] fruits = Enumerable.Range(1, 10000).Select(x => new Fruit(Guid.NewGuid(),"Name")
        {
            Description = "Description",
        }).ToArray();
        static string json = JsonSerializer.Serialize(fruits);

        [Benchmark]
        public void NewFruit_FromJson()
        {
            var res = JsonSerializer.Deserialize<Apple[]>(json);
        }

        [Benchmark]
        public void NewFruit_Default()
        {
            var res =fruits.Select(x => new Apple(Guid.NewGuid(), "Name")
            {
                Description = x.Description,
            }).ToArray();
        }

        [Benchmark]
        public void NewFruit_AutoMapper()
        {
            var profile = new AutoProfile();
            var mapper =  new Mapper(new MapperConfiguration(options => options.AddProfile(profile)));
            var res = mapper.Map<Apple[]>(fruits);
        }
    }

    public class Fruit
    {
        public Fruit() {

        }
        public Fruit(Guid id,string name) {
            this.Id = id;
            this.Name = name;
        }
        public Guid Id {  get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }

    public class Apple : Fruit
    {
        public Apple(Guid id, string name) : base(id, name)
        {
        }

        public Apple() {

        }
        public string Color = "Red|Green";


        public string MaxNAME { get; set; } = "1111";


    }


    public class AutoProfile : Profile {
        public AutoProfile() {
            this.CreateMap<Fruit,Apple>()
                .ReverseMap();
        }
    }


    public struct ExampleDemo
    {
        public byte P1 { get; set; }
        public byte P2 { get; set; }
        public byte P3 { get; set; }
        public byte P4 { get; set; }
        public DayType Day { get; set; }
    }

    public enum DayType :byte
    {
        HappyDay,
        SadDay,
    }
}
