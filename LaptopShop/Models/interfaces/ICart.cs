using LaptopShop.Models.database;

namespace LaptopShop.Models.interfaces
{
    public interface ICart
    {

        public List<Laptop> getUsersLaptops(string UserID);
        public void AddToCart(Cart cart);
        public Task DeleteFromCart(string UserID, int laptopId);
        public Cart makeCart(string userID, int laptopID);
    }
}
