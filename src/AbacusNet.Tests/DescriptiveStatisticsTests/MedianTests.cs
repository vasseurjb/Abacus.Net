using System;
using MathNet.Numerics.Statistics;

namespace AbacusNet.Tests.DescriptiveStatisticsTests
{
    public class MeanTests : TestBase
    {
        [Fact]
        public void MeanVsMathNet()
        {
            var actual = DescriptiveStatistics.Mean(data);
            var expected = Statistics.Mean(data);

            Assert.Equal(expected, actual, 5);
        }

        [Fact]
        public void MeanVsAlglib()
        {
            var actual = DescriptiveStatistics.Mean(data);
            var expected = alglib.samplemean(data);

            Assert.Equal(expected, actual, 5);
        }
    }
}

