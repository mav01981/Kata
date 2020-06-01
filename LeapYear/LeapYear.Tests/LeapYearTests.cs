using LeapYear.Library;
using Xunit;

namespace LeapYear.Tests
{
    public class LeapYearTests
    {
        [Theory]
        [InlineData(2000, true)]
        [InlineData(2001, false)]
        [InlineData(1996, true)]
        [InlineData(1904, true)]
        [InlineData(1906, false)]
        public void IsLeapYear(int year, bool expectedResult)
        {
            var calculator = new LeapYearCalculator();

            bool isLeapYear = calculator.IsLeapYear(year);

            Assert.True(isLeapYear == expectedResult);
        }
    }
}
