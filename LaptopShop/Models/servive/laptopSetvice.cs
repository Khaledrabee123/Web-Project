using LaptopShop.Models.database;
using LaptopShop.Models.reposatorys;
using LaptopShop.Views.viewmodels;

namespace LaptopShop.Models.servive
{
    public class laptopSetvice
    {
        LaptopReposatory LaptopReposatory;
        public laptopSetvice(LaptopReposatory lp)
        {
            LaptopReposatory = lp;
        }
        public Laptop getLaptopbyid(int id)
        {
            return LaptopReposatory.getLaptopbyid(id);
        }

        public List<Laptop> getLaptopbyCategorie(string brand)
        {
            return LaptopReposatory.getLaptopbyCategorie(brand);
        }

        public List<Laptop> getAll()
        {
            return LaptopReposatory.getAll();


        }
        public void add(Laptop laptop)
        {
            LaptopReposatory.add(laptop);
        }
        public List<Laptop> getbyCategorie(string categorie)
        {
            return LaptopReposatory.getbyCategorie(categorie);
        }

        public void remove(Laptop laptop)
        {
            LaptopReposatory.remove(laptop);
        }
        public void Edit(Laptop laptop)
        {
            LaptopReposatory.Edit(laptop);
        }
        public Laptop MakeLaptop(Laptopview receivelaptop)
        {
            Laptop laptop = new Laptop();
            laptop.price = receivelaptop.price;
            laptop.description = receivelaptop.description;
            laptop.Display = receivelaptop.Display;
            laptop.Graphics = receivelaptop.Graphics;
            laptop.Brand = receivelaptop.Brand;
            laptop.Battery = receivelaptop.Battery;
            laptop.Image = receivelaptop.Image;
            laptop.Memory = receivelaptop.Memory;
            laptop.Processor = receivelaptop.Processor;
            laptop.Storage = receivelaptop.Storage;
            laptop.Image = receivelaptop.LaptopPhoto.FileName;
            laptop.name = receivelaptop.name;
            return laptop;

        }

    }
}
