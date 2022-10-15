using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MathNet.Numerics.Random;
using MathNet.Numerics.Statistics;

namespace AbacusNet.BenchMarks
{
    public class StandardDeviationBenchmark : BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double StandardDeviation() => DescriptiveStatistics.StandardDeviation(data);

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double StandardDeviationMathNet() => Statistics.StandardDeviation(data);

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double StandardDeviationAlglib()
        {
            alglib.sampleadev(data, out double result);

            return result;
        }

    }
}
