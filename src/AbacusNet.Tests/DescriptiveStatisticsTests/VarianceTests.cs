using MathNet.Numerics.Statistics;

namespace AbacusNet.Tests.DescriptiveStatisticsTests
{
    public class VarianceTests : TestBase
    {
        [Fact]
        public void VarianceVsMathNet()
        {
            var actual = DescriptiveStatistics.Variance(data);
            var expected = Statistics.Variance(data);

            Assert.Equal(expected, actual, precision);
        }

        [Fact]
        public void VarianceVsAlglib()
        {
            var actual = DescriptiveStatistics.Variance(data);
            var expected = alglib.samplevariance(data);

            Assert.Equal(expected, actual, precision);
        }
    }
}

