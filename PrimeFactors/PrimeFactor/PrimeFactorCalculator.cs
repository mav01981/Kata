using System.Collections.Generic;

namespace PrimeFactors
{
    public class PrimeFactorCalculator
    {
        private int currentFactor = 2;
        private int Factor => 2;

        public IList<int> Calculate(int number)
        {
            List<int> result = new List<int>();

            while (number >= Factor)
            {
                bool isPrimeFactor = number % currentFactor == 0;
                if (isPrimeFactor)
                {
                    result.Add(currentFactor);

                    number /= currentFactor;
                }
                else
                {
                    currentFactor += currentFactor == 2 ? 1 : 2;
                }
            }
            return result;
        }
    }
}
