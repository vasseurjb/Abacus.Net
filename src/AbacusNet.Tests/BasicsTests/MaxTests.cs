using System;
namespace AbacusNet.Tests.BasicsTests
{
    public class MaxTests : TestBase
    {
        [Fact]
        public void MaxVsLinq()
        {
            var actual = Basics.Max(data);
            var expected = data.Max();

            Assert.Equal(expected, actual);
        }
    }
}

