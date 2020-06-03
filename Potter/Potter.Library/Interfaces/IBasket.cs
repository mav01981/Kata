namespace Potter.Library
{
    public interface IBasket
    {
        decimal TotalPrice { get; }
        IBasket Add(Book book);
    }
}