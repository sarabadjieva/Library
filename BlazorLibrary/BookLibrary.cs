using Utilities;

namespace BlazorLibrary
{
    public class BookLibrary
    {
        private static BookLibrary? instance;
        public static BookLibrary Instance => instance ??= new BookLibrary();

        public List<BookData> books;

        public BookLibrary()
        {
            books = SaveSystem<BookData>.LoadArray()?.ToList() ?? [];
        }

        public void AddBook(BookData book)
        {
            books.Add(book);
            SaveSystem<BookData>.Save([.. books]);
        }

        public void RemoveBook(BookData book)
        {
            if (books?.Contains(book) != true)
                return;

            books.Remove(book);
            SaveSystem<BookData>.Save([.. books]);
        }
    }
}
