using MathNet.Numerics.Statistics;

namespace AbacusNet.Tests.DescriptiveStatisticsTests
{
    public class StandardDeviationTests : TestBase
    {
        [Fact]
        public void StandardDeviationVsMathNet()
        {
            var actual = DescriptiveStatistics.StandardDeviation(data);
            var expected = Statistics.StandardDeviation(data);

            Assert.Equal(expected, actual, precision);
        }

        [Fact]
        public void StandardDeviationVsAlglib()
        {
            var actual = DescriptiveStatistics.StandardDeviation(data);
            alglib.sampleadev(data, out double expected);

            Assert.Equal(expected, actual, precision);
        }
    }
}

