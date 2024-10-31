using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace LaptopShop.Models.database
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("laptops")]
        public int lap_id { get; set; }
        public virtual User User { get; set; }
        public virtual List<Laptop> laptops { get; set; }
        

    }
}
