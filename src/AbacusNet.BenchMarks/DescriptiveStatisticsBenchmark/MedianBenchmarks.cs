using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MathNet.Numerics.Random;
using MathNet.Numerics.Statistics;

namespace AbacusNet.BenchMarks
{
    public class MedianBenchmark : BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double Median() => DescriptiveStatistics.Median(data);

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double MedianMathNet() => Statistics.Median(data);

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double MedianAlglib()
        {
            alglib.samplemedian(data, out double result);

            return result;
        }

    }
}
