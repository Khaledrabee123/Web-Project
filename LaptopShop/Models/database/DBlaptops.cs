using System.Reflection.Emit;
using System.Xml.Linq;
using Humanizer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop.Models.database
{
    public class DBlaptops :IdentityDbContext<User>
    {
        public DBlaptops()
        {
            
        }

        public DBlaptops( DbContextOptions options):base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =DESKTOP-T3ABVVQ\\MSSQLSERVER01;Initial Catalog =Laptopsdatabase;Integrated Security=true;TrustServerCertificate=True;Encrypt=False");
        }

        public virtual DbSet<Laptop> Laptops { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Order> Order { get; set; } 
        public virtual DbSet<Groups> Groups { get; set; }

    }
}
