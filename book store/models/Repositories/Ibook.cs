using book_store.models.database;

namespace book_store.models.Repositories
{
    public interface Ibook
    {
        public List<Book> GetAllBooks();

        //CURD
        public Book Getbook(int id);
        public void Deletebook(int id);
        public void updateBook(Book book);
        public void AddBock(Book book);

    }
}
