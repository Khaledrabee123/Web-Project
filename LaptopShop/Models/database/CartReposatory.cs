
using Microsoft.EntityFrameworkCore;

namespace LaptopShop.Models.database
{
    public class CartReposatory : ICart
    {
        DBlaptops DBlaptops;
        public CartReposatory(DBlaptops db)
        {
            this.DBlaptops = db;
        }
        public void AddToCart(Cart cart)
        {

            DBlaptops.Carts.Add(cart);
            DBlaptops.SaveChanges();
        }

        public async Task DeleteFromCart(string UserID, int laptopId)
        {
             DBlaptops.Database.ExecuteSqlRaw("EXEC DeleteCartByUserIdAndLaptopId @p0, @p1", UserID, laptopId);
             DBlaptops.SaveChanges();
        }

        public List<Laptop> getUsersLaptops(string userID)
        {
            return DBlaptops.Laptops.FromSqlRaw("EXEC GeetUserLaptops @p0", userID).ToList();
        }

        public Cart makeCart(string userID, int laptopID)
        {
            Cart cart = new Cart();
            cart.lap_id = laptopID;
            cart.UserId = userID;
            return cart;

        }
    }
}
