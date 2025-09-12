using static Tests.MyMethods;

namespace Tests
{
    public class PowerTests
    {

        //1
        [Fact]
        public void Power_PositiveBase_PositiveExponent_ReturnsCorrectResult()
        {
            double a = 2;
            int n = 3;

            double result = MyMethods.Power(a, n);

            Assert.Equal(8.000, result);
        }

        //2
        [Fact]
        public void Power_AnyBase_ZeroExponent_ReturnsOne()
        {
            double a = 5;
            int n = 0;

            double result = MyMethods.Power(a, n);

            Assert.Equal(1.000, result);
        }

        //3
        [Fact]
        public void Power_PositiveBase_NegativeExponent_ReturnsCorrectResult()
        {
            double a = 2;
            int n = -2;

            double result = MyMethods.Power(a, n);

            Assert.Equal(0.250, result);
        }

        //4
        [Fact]
        public void Power_ZeroBase_PositiveExponent_ReturnsZero()
        {
            double a = 0;
            int n = 5;

            double result = MyMethods.Power(a, n);

            Assert.Equal(0.000, result);
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

        //6
        [Fact]
        public void Power_NegativeBase_OddExponent_ReturnsNegativeResult()
        {
            double a = -2;
            int n = 3;

            double result = MyMethods.Power(a, n);

            Assert.Equal(-8.000, result);
        }

        //7
        [Fact]
        public void Power_FractionalBase_PositiveExponent_RoundsToThreeDecimalPlaces()
        {
            double a = 0.3;
            int n = 4;

            double result = MyMethods.Power(a, n);

            Assert.Equal(0.008, result);
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
