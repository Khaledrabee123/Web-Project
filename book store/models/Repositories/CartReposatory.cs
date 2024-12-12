using System.Net;
using book_store.models.database;
using Microsoft.EntityFrameworkCore;

namespace book_store.models.Repositories
{
    public class CartReposatory : ICart
    {
        Storedb storedb;
        public CartReposatory(Storedb db)
        {
            storedb = db;
        }
        public void AddToCart(ShoppingCart cart)
        {

            storedb.ShoppingCarts.Add(cart);
            storedb.SaveChanges();
        }

        public async Task DeleteFromCart(string UserID, int bookID)
        {
            var cartsToDelete = storedb.ShoppingCarts
             .Where(c => c.User_Id == UserID && c.book_id == bookID);

            storedb.ShoppingCarts.RemoveRange(cartsToDelete);
            storedb.SaveChanges();
        }

        public List<Book> getUserBooks(string userID)
        {
            return storedb.Books.FromSqlRaw("EXEC GetBooksFromShoppingCartByUserId @p0", userID).ToList();
        }

        public ShoppingCart makeCart(string userID, int bookID)
        {
            ShoppingCart cart = new ShoppingCart();
            cart.book_id = bookID;
            cart.User_Id = userID;
            return cart;

        }
    }
}
