using Utilities.SaveSystem;

namespace BlazorLibrary
{
    public class BookLibrary
    {
        private static BookLibrary? instance;
        public static BookLibrary Instance => instance ??= new BookLibrary();

        public SaveDataCollection<BookData> books;
        private readonly SaveSystem<SaveDataCollection<BookData>> saveSystem = new();

        public BookLibrary()
        {
            books = saveSystem.Load() ?? [];
        }

        public void AddBook(BookData book)
        {
            books.Add(book);
            saveSystem.Save(books);
        }

        public void RemoveBook(BookData book)
        {
            if (books?.Contains(book) != true)
                return;

            books.Remove(book);
            saveSystem.Save(books);
        }
    }
}
