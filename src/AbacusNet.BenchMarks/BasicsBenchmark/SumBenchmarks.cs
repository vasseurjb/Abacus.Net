using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MathNet.Numerics.Random;

namespace AbacusNet.BenchMarks
{
    public class SumBenchmark : BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double Sum() => Basics.Sum(data);

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double SumVanilla()
        {
            double result = 0;

            for (int i = 0, length = N; i < length; i++)
            {
                result += data[i];
            }

            return result;
        }

        [Benchmark]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public double SumLinq() => data.Sum();

    }
}
