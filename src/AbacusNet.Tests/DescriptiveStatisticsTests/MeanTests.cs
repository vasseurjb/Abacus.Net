using MathNet.Numerics.Statistics;

namespace AbacusNet.Tests.DescriptiveStatisticsTests
{
    public class MedianTests : TestBase
    {
        [Fact]
        public void MedianVsMathNet()
        {
            var actual = DescriptiveStatistics.Median(data);
            var expected = Statistics.Median(data);

            Assert.Equal(expected, actual, precision);
        }

        [Fact]
        public void MedianVsAlglib()
        {
            var actual = DescriptiveStatistics.Median(data);
            alglib.samplemedian(data, out double expected);

            Assert.Equal(expected, actual, precision);
        }
    }
}

