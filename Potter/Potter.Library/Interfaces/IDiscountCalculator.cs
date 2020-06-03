namespace Potter.Library
{
    public interface IDiscountCalculator
    {
        decimal Calculate(Book[] books);
    }
}