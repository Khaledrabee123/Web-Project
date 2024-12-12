using System.Text;
using book_store.models.database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;

namespace book_store.models.Repositories
{
    public class BookRepository : Ibook
    {
        public Storedb _db;
        private readonly IMemoryCache _Cache;
        
        
        public BookRepository(Storedb db, IMemoryCache cache)
        {

            _db = db;
            _Cache = cache;
        }

        public List<Book> GetAllBooks()
        {
            string key = "GetAllBooks";
            if (_Cache.TryGetValue(key, out List<Book> Books))
            {

                return Books;

            }

            // caching 
            var cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(5))
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15))
            .SetPriority(CacheItemPriority.Normal);

             Books = _db.Books.ToList();
            _Cache.Set(key, Books, cacheOptions);


            return Books;
          
        }


        // CURD
        public void AddBock(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }

        public void Deletebook(int id)
        {
            _db.Books.Remove(Getbook(id));
            _db.SaveChanges();
        }

        public Book Getbook(int id)
        {

            string key ="book"+ Convert.ToString(id);
            if (_Cache.TryGetValue(key, out Book book))
            {

                return book;

            }

            // caching 
             var cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(5))
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(15))
            .SetPriority(CacheItemPriority.Normal);

             book = _db.Books.FirstOrDefault(book => book.Id == id);
            _Cache.Set(key, book, cacheOptions);

            return _db.Books.FirstOrDefault(x => x.Id == id);
        }

        public void updateBook(Book book)
        {
            _db.Books.Update(book);
            _db.SaveChanges();
        }
    }
}
