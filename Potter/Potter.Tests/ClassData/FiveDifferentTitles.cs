using Potter.Library;
using System.Collections;
using System.Collections.Generic;

namespace Potter.Tests
{
    public class FiveDifferentTitles : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new Book[] {
                    new Book() { Name = "Harry Potter and the Philosopher's Stone", Price = 8m, },
                    new Book() { Name = "Harry Potter and the Chamber of Secrets", Price = 8m },
                    new Book() { Name = "Harry Potter and the Prisoner of Azkaban", Price = 8m },
                    new Book() { Name = "Harry Potter and the Goblet of Fire", Price = 8m },
                    new Book() { Name = "Harry Potter and the Order of the Phoenix", Price = 8m }
                }
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
