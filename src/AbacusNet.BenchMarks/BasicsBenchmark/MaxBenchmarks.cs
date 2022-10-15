using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MathNet.Numerics.Random;

namespace AbacusNet.BenchMarks
{
    public class MaxBenchmark : BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double Max() => Basics.Max(data);

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double MaxVanilla()
        {
            double result = double.MinValue;

            for (int i = 0, length = N; i < length; i++)
            {
                if (data[i] > result)
                {
                    result = data[i];
                }
            }

            return result;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double MaxLinq() => data.Max();

    }
}
