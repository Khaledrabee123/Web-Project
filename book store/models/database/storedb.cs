using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace book_store.models.database
{
    public class Storedb : IdentityDbContext<User>
    {
        public Storedb()
        {

        }

        public Storedb(DbContextOptions options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =DESKTOP-T3ABVVQ\\MSSQLSERVER01;Initial Catalog =BookStore;Integrated Security=true;TrustServerCertificate=True;Encrypt=False");
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }


    }
}
