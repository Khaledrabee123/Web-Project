namespace LaptopShop.Models.database
{
	public interface  IOrder
	{

		public void addOrder(Order order);
		public void removeOrder(Order order);
		public void updateOrder(Order order);
		public Order MakeOrder(string userID, int total);

    }
}
