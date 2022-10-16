using MathNet.Numerics.Random;

namespace AbacusNet.Tests.BasicsTests;

public class SumTests : TestBase
{
    [Fact]
    public void SumVsLinq()
    {
        var actual = Basics.Sum(data);
        var expected = data.Sum();

        Assert.Equal(expected, actual, precision);
    }
}
