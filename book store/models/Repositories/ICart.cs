using book_store.models.database;

namespace book_store.models.Repositories
{
    public interface ICart
    {

        public List<Book> getUserBooks(string UserID);
        public void AddToCart(ShoppingCart cart);
        public Task DeleteFromCart(string UserID, int bookID);
        public ShoppingCart makeCart(string userID, int bookID);
    }
}
