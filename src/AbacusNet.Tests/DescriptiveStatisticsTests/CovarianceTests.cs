using System;
using MathNet.Numerics.Random;
using MathNet.Numerics.Statistics;

namespace AbacusNet.Tests.DescriptiveStatisticsTests
{
    public class CovarianceTests : TestBase
    {
        public double[] data2;

        public CovarianceTests() : base()
        {
            data2 = Enumerable.Range(0, N).Select(v => random.NextDouble() * N).ToArray();
        }

        [Fact]
        public void CovarianceVsMathNet()
        {
            var actual = DescriptiveStatistics.Covariance(data, data2);
            var expected = Statistics.Covariance(data, data2);

            Assert.Equal(expected, actual, 5);
        }

        [Fact]
        public void CovarianceVsAlglib()
        {
            var actual = DescriptiveStatistics.Covariance(data, data2);
            var expected = alglib.cov2(data, data2);

            Assert.Equal(expected, actual, 5);
        }
    }
}

