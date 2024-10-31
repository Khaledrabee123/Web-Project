using System.Security.Cryptography;

namespace LaptopShop.Models.database
{
	public class OrderRepository : IOrder
	{
		private readonly DBlaptops dBlaptops;

		public OrderRepository(DBlaptops dBlaptops)
        {
			this.dBlaptops = dBlaptops;
		}
        public void addOrder( Order order)
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
		public Order MakeOrder(string id , int TotalAmount)
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
	}
}
