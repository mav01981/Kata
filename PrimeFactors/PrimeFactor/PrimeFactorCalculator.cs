using System.Collections.Generic;

namespace PrimeFactors
{
    public class PrimeFactorCalculator
    {
        public IList<int> Calculate(int number)
        {
            List<int> result = new List<int>();
            var factor = 2;

            while (number > 1)
            {
                bool isPrimeFactor = number % factor == 0;
                if (isPrimeFactor)
                {
                    result.Add(factor);

                    number /= factor;
                }
                else
                {
                    factor += factor == 2 ? 1 : 2;
                }
            }
            return result;
        }
    }
}
