using Potter.Library;
using Xunit;

namespace Potter.Tests
{
    public class PotterTests
    {
        /// <summary>
        ///  2 * 8 = 16 | 16/100 = 0.16 * 5 = 0.8 | 16-0.8 =>15.20 euros.
        /// </summary>
        /// <param name="books"></param>
        [Theory]
        [ClassData(typeof(TwoDifferentTitles))]
        public void TwoDifferentBooks_Apply10PercentDiscount_ReturnsTotal(Book[] books)
        {
            var basket = new Basket(new DiscountCalculator());

            foreach (var book in books)
            {
                basket.Add(book);
            }

            Assert.True(basket.TotalPrice == 15.20m);
        }

        /// <summary>
        ///  3 * 8 = 24 | 24/100 = 0.24 * 10 = 2.4 | 24-2.4 =>21.6 euros.
        /// </summary>
        /// <param name="books"></param>
        [Theory]
        [ClassData(typeof(ThreeDifferentTitles))]
        public void ThreeDifferentBooks_Apply10PercentDiscount_returns(Book[] books)
        {
            var basket = new Basket(new DiscountCalculator());

            foreach (var book in books)
            {
                basket.Add(book);
            }

            Assert.True(basket.TotalPrice == 21.6m);
        }

        /// <summary>
        /// 8 * 4 = 32 | 32/100 = 0.32 * 20 = 6.4 | 32-6.4 =25.6 euros.
        /// </summary>
        /// <param name="books"></param>
        [Theory]
        [ClassData(typeof(FourDifferentTitles))]
        public void FourDifferentBooks_Apply20PercentDiscount_returns(Book[] books)
        {
            var basket = new Basket(new DiscountCalculator());

            foreach (var book in books)
            {
                basket.Add(book);
            }

            Assert.True(basket.TotalPrice == 25.6m);
        }

        /// <summary>
        /// 8 * 5 = 40 | 40/100 = 0.4 * 25 = 10 | 40-10 =30 euros.
        /// </summary>
        /// <param name="books"></param>
        [Theory]
        [ClassData(typeof(FiveDifferentTitles))]
        public void FiveDifferentBooks_Apply25PercentDiscount_returns(Book[] books)
        {
            var basket = new Basket(new DiscountCalculator());

            foreach (var book in books)
            {
                basket.Add(book);
            }

            Assert.True(basket.TotalPrice == 30m);
        }

        /// <summary>
        /// 2 copies of the first book. => 5% discount applied to 2 books
        /// 1 copy of the fifth book. => 8 Euros
        /// </summary>
        /// <param name="books"></param>
        [Theory]
        [ClassData(typeof(ThreeBooksTwoDifferentTitles))]
        public void ThreeBooksTwoDifferentTitles_Apply10PercentDiscount_ReturnsTotal(Book[] books)
        {
            var basket = new Basket(new DiscountCalculator());

            foreach (var book in books)
            {
                basket.Add(book);
            }

            Assert.True(basket.TotalPrice == 23.2m);
        }

        /// <summary>
        /// MixedBag1
        /// 2 copies of the first book
        /// 2 copies of the second book
        /// 2 copies of the third book
        /// 1 copy of the fourth book
        /// 1 copy of the fifth book
        /// </summary>
        /// <param name="books"></param>
        [Theory]
        [ClassData(typeof(MixedBag1))]
        public void FourBooksTwoDifferent_Apply20PercentDiscount_returns(Book[] books)
        {
            var basket = new Basket(new DiscountCalculator());

            foreach (var book in books)
            {
                basket.Add(book);
            }

            Assert.True(basket.TotalPrice == 51.2m);
        }
    }
}
