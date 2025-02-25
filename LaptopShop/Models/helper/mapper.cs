using System.Security.Cryptography;
using LaptopShop.Models.database;
using LaptopShop.Views.viewmodels;

namespace LaptopShop.Models.reposatorys
{
    public class mapper
    {
        public static Order MakeOrder(string id, decimal TotalAmount)
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

        public static Laptop MakeLaptop(Laptopview receivelaptop)
        {

            Laptop laptop = new Laptop();
            laptop.price = receivelaptop.price;
            laptop.description = receivelaptop.description;
            laptop.Display = receivelaptop.Display;
            laptop.Graphics = receivelaptop.Graphics;
            laptop.Brand = receivelaptop.Brand;
            laptop.Battery = receivelaptop.Battery;
            laptop.Memory = receivelaptop.Memory;
            laptop.Processor = receivelaptop.Processor;
            laptop.Storage = receivelaptop.Storage;
            laptop.Image = receivelaptop.LaptopPhoto.FileName;
            laptop.name = receivelaptop.name;
            return laptop;
        }

        public static  Cart makeCart(string userID, int laptopID)
		{
			Cart cart = new Cart();
			cart.lap_id = laptopID;
			cart.UserId = userID;
			return cart;

		}
	}
}
