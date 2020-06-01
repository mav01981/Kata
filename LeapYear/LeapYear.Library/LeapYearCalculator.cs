using System;

namespace LeapYear.Library
{
    public class LeapYearCalculator
    {
        public bool IsLeapYear(int year)
        {
            return year % 4 == 0 ? true : year % 100 == 0 ? true : year % 400 == 0 ? true : false;
        }
    }
}
