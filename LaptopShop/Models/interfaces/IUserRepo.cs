using LaptopShop.Models.database;

namespace LaptopShop.Models.interfaces
{
    public interface IUserRepo
    {

        public List<Laptop> GetLaptops(string username);
        public void Addlaptop(string username, int id);
    }
}
