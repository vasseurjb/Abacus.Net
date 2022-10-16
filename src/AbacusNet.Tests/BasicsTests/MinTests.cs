namespace AbacusNet.Tests.BasicsTests
{
    public class MinTests : TestBase
    {
        [Fact]
        public void MinVsLinq()
        {
            var actual = Basics.Min(data);
            var expected = data.Min();

            Assert.Equal(expected, actual);
        }
    }
}

