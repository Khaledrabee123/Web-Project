using LaptopShop.Models.interfaces;

namespace LaptopShop.Models.reposatorys
{
    public class Randomreposatory : IRandom
    {
        Random Random = new Random();
        public int randomNumber()
        {
            return Random.Next(10000, 10000000);
        }
    }
}
