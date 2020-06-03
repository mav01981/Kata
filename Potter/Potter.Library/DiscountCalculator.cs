using System.Linq;

namespace Potter.Library
{
    public class DiscountCalculator : IDiscountCalculator
    {
        private const int bookCost = 8;

        public decimal Calculate(Book[] books)
        {
            decimal[] discounts = new[]
            {
                Discount(books,2,0.95m),
                Discount(books,3,0.9m),
                Discount(books,4,0.8m),
                Discount(books,5,0.75m),
            };
            return discounts.OrderBy(x => x).First();
        }

        private static decimal Discount(Book[] books, int matchingBookCount, decimal factor)
        {
            int numberOfBooks = books.Count();
            var distinctTitles = books.GroupBy(x => x.Name).Count();
            int quantity = 0;
            int bookSetSize = 5;

            if (numberOfBooks > bookSetSize && numberOfBooks % matchingBookCount == 0)
            {
                quantity = numberOfBooks / matchingBookCount;

                int numberOfBooksNotDiscounted = numberOfBooks - (matchingBookCount * quantity);

                return (((bookCost * matchingBookCount) * factor) * quantity) + (numberOfBooksNotDiscounted * 8); ;
            }
            else if (matchingBookCount == distinctTitles && distinctTitles % matchingBookCount == 0)
            {
                int numberOfBooksNotDiscounted = numberOfBooks - distinctTitles;
                return ((bookCost * matchingBookCount) * factor) + (numberOfBooksNotDiscounted * 8);
            }
            return books.Sum(x => x.Price);
        }
    }
}
