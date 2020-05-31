using Xunit;

namespace PrimeFactors.Tests
{
    public class PrimeFactorCalculatorTests
    {

        [Theory]
        [InlineData(0, new int[] { })]
        [InlineData(1, new int[] { })]
        [InlineData(2, new int[] { 2 })]
        [InlineData(100, new int[] { 2, 2, 5, 5 })]
        [InlineData(228, new int[] { 2, 2, 3, 19 })]
        public void One_should_return_EmptyList(int number, int[] expectedResult)
        {
            var factors = new PrimeFactorCalculator();

            var result = factors.Calculate(number);

            Assert.Equal(expectedResult, result);
        }
    }
}
