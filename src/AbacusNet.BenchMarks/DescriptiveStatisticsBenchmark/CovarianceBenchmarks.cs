using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MathNet.Numerics.Random;
using MathNet.Numerics.Statistics;

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
    public class CovarianceBenchmark
    {
        [Params(1000, 10000, 100000)]
        public int N;
        public double[] data;
        public double[] data2;

        [GlobalSetup]
        public void Setup()
        {
            var rand = new MersenneTwister(RandomSeed.Robust());
            data = Enumerable.Range(0, N).Select(v => rand.NextDouble() * N).ToArray();
            data2 = Enumerable.Range(0, N).Select(v => rand.NextDouble() * N).ToArray();
        }

        [Benchmark(Baseline = true)]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double Covariance() => DescriptiveStatistics.Covariance(data, data2);

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double CovarianceMathNet() => Statistics.Covariance(data, data2);

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double CovarianceAlglib() => alglib.cov2(data, data2);

    }
}
