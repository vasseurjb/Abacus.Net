using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MathNet.Numerics.Random;
using MathNet.Numerics.Statistics;

namespace AbacusNet.BenchMarks
{
    public class VarianceBenchmark : BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double Variance() => DescriptiveStatistics.Variance(data);

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double VarianceMathNet() => Statistics.Variance(data);

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double VarianceAlglib() => alglib.samplevariance(data);

    }
}
