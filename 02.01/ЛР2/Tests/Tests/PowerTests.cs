using static Tests.MyMethods;

namespace Tests
{
    public class PowerTests
    {

        [Theory]
        [InlineData(2, 3, 8)]
        [InlineData(5, 0, 1)]
        [InlineData(2, -2, 0.25)]
        [InlineData(0, 5, 0)]
        [InlineData(-2, 3, -8)]
        [InlineData(0.3, 4, 0.008)]
        public void Power_PositiveBase_PositiveExponent2_ReturnsCorrectResult(double a, int n, double expected)
        {
            double result = MyMethods.Power(a, n);

            Assert.Equal(expected, result, 0.001);
        }


        //5
        [Fact]
        public void Power_ZeroBase_ZeroExponent_ThrowsArgumentException()
        {
            double a = 0;
            int n = 0;

            var exception = Assert.Throws<ArgumentException>(() => MyMethods.Power(a, n));
            Assert.Contains("0^0", exception.Message);
        }

        //8
        [Fact]
        public void Power_ZeroBase_NegativeExponent_ThrowsArgumentException()
        {
            double a = 0;
            int n = -5;

            var exception = Assert.Throws<ArgumentException>(() => MyMethods.Power(a, n));
            Assert.Contains("0^(-n)", exception.Message);
        }
    }
}
