namespace LaptopShop.Models.database
{
    public interface IUserRepo
    {

        public List<Laptop> GetLaptops(string username);
        public void Addlaptop(string username,int id);
    }
}
