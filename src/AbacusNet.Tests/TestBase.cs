using System;
using MathNet.Numerics.Random;

namespace AbacusNet.Tests
{
    public class TestBase
    {
        protected MersenneTwister random = new MersenneTwister(RandomSeed.Robust());

        protected int N = 1000;
        protected double[] data;

        public TestBase()
        {
            data = Enumerable.Range(0, N).Select(v => random.NextDouble() * N).ToArray();

        }
    }
}

