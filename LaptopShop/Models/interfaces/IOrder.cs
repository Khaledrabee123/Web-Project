using LaptopShop.Models.database;

namespace LaptopShop.Models.interfaces
{
    public interface IOrder
    {

        public void addOrder(Order order);
        public void removeOrder(Order order);
        public void updateOrder(Order order);
        public Order MakeOrder(string userID, decimal total);
        public Order oredr(decimal total, string id, string username);


	}
}
