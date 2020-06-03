using System.Collections.Generic;

namespace Potter.Library
{
    public class Basket:IBasket
    {
        private readonly List<Book> books = new List<Book>();
        private readonly IDiscountCalculator _discountCalculator;

        public decimal TotalPrice => _discountCalculator.Calculate(books.ToArray());

        public Basket(IDiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator;
        }

        public IBasket Add(Book book)
        {
            books.Add(book);

            return this;
        }
    }
}
