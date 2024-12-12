using LaptopShop.Models.database;
using LaptopShop.Views.viewmodels;

namespace LaptopShop.Models.interfaces
{
    public interface ILaptop
    {
        public Laptop getLaptopbyid(int id);

        public List<Laptop> getLaptopbyCategorie(string brand);

        public List<Laptop> getAll();
        public List<Laptop> getbyCategorie(string categorie);
        public void add(Laptop laptop);
        public void remove(Laptop laptop);
        public void Edit(Laptop laptop);

        public Laptop MakeLaptop(Laptopview laptop);

    }
}
