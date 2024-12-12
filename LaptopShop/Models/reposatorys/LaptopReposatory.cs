using LaptopShop.Models.database;
using LaptopShop.Models.interfaces;
using LaptopShop.Views.viewmodels;

namespace LaptopShop.Models.reposatorys
{
    public class LaptopReposatory : ILaptop
    {
        DBlaptops DBlaptops;
        public LaptopReposatory(DBlaptops db)
        {
            DBlaptops = db;
        }
        public Laptop getLaptopbyid(int id)
        {
            return DBlaptops.Laptops.FirstOrDefault(e => e.Id == id);

        }
        public List<Laptop> getLaptopbyCategorie(string brand)
        {
            return DBlaptops.Laptops.Where(e => e.Brand == brand).ToList();

        }
        public List<Laptop> getAll()
        {
            return DBlaptops.Laptops.ToList();

        }
        public void add(Laptop laptop)
        {
            DBlaptops.Laptops.Add(laptop);
            DBlaptops.SaveChanges();
        }

        public void remove(Laptop laptop)
        {
            DBlaptops.Remove(laptop);
            DBlaptops.SaveChanges();

        }
        public void Edit(Laptop laptop)
        {
            DBlaptops.Update(laptop);
            DBlaptops.SaveChanges();
        }
        public List<Laptop> getbyCategorie(string categorie)
        {
            return DBlaptops.Laptops.Where(e => e.Brand == categorie).ToList();
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
