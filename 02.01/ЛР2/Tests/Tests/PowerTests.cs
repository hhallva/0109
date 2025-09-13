using static MyLibrary.MyMethods;

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
        [InlineData(0.3, 4, 0.0081)]
        public void Power_CorrectValue_ReturnsCorrectResult(double baseValue, int exponent, double expected)
        {
            double result = Power(baseValue, exponent);

            Assert.Equal(expected, result, 0.001);
        }


        //5
        [Fact]
        public void Power_ZeroBase_ZeroExponent_ThrowsArgumentException()
        {
            double baseValue = 0;
            int exponent = 0;

            var exception = Assert.Throws<ArgumentException>(() => Power(baseValue, exponent));
            Assert.Contains("0^0", exception.Message);
        }

        //8
        [Fact]
        public void Power_ZeroBase_NegativeExponent_ThrowsArgumentException()
        {
            double baseValue = 0;
            int exponent = -5;

            var exception = Assert.Throws<ArgumentException>(() => Power(baseValue, exponent));
            Assert.Contains("0^(-n)", exception.Message);
        }
    }
}
