using System.Security.Claims;
using System.Security.Cryptography;
using LaptopShop.Models.database;
using LaptopShop.Models.interfaces;

namespace LaptopShop.Models.reposatorys
{
    public class OrderRepository : IOrder
    {
        private readonly DBlaptops dBlaptops;
        private readonly ILogger<OrderRepository> logger;
		public OrderRepository(DBlaptops dBlaptops, ILogger<OrderRepository> logger)
		{
			this.dBlaptops = dBlaptops;
			this.logger = logger;
		}
		public void addOrder(Order order)
        {

            dBlaptops.Order.Add(order);
            dBlaptops.SaveChanges();
        }

        public void removeOrder(Order order)
        {
            dBlaptops.Order.Remove(order);
            dBlaptops.SaveChanges();
        }

        public void updateOrder(Order order)
        {
            dBlaptops.Order.Update(order);
            dBlaptops.SaveChanges();
        }
        public Order MakeOrder(string id, decimal TotalAmount)
        {
            Random rnd = new Random();
            Order order = new Order();
            order.Id = rnd.Next(2000, 1000000).ToString();
            order.TotalAmount = TotalAmount;
            order.OrderDate = DateTime.Now;
            order.UserId = id;
            order.Status = "In warehouse products";
            return order;
        }
        public Order oredr(decimal total, string id , string username)
        {

			Order order = this.MakeOrder(id, total);

			this.addOrder(order);

			logger.LogInformation("{user} has orderd {@oredr}", username, order);
            return order;
			
		}
    }
}
