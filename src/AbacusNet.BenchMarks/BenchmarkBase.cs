using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MathNet.Numerics.Random;

namespace AbacusNet.BenchMarks
{
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [RPlotExporter]
    [HtmlExporter]
    [MemoryDiagnoser]
    [JsonExporterAttribute.Full]
    [XmlExporterAttribute.Full]
    [GcServer(true)]
    public class BenchmarkBase
    {
        [Params(1000, 10000, 100000)]
        public int N;
        protected double[] data;

        [GlobalSetup]
        public void Setup()
        {
            var rand = new MersenneTwister(RandomSeed.Robust());
            data = Enumerable.Range(0, N).Select(v => rand.NextDouble() * N).ToArray();
        }
    }
}

