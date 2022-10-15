using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MathNet.Numerics.Random;

namespace AbacusNet.BenchMarks
{
    public class MinBenchmark : BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double Min() => Basics.Min(data);

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double MinVanilla()
        {
            double result = double.MaxValue;

            for (int i = 0, length = N; i < length; i++)
            {
                if (data[i] < result)
                {
                    result = data[i];
                }
            }

            return result;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double MinLinq() => data.Min();

    }
}
