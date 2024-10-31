using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop.Models.database
{
    public class Laptop
    {

        [Required]
        [Key]  
        public  int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        [Required]
        [StringLength(200)]
        public string description { get; set; }
        [Required]
        [StringLength(50)]
        public string Memory { get; set; }
        [Required]
        [StringLength(50)]
        public string Processor { get; set; }
        [Required]
        [StringLength(50)]
        public string Storage { get; set; }
        [Required]
        [StringLength(50)]
        public string Battery { get; set; }
        [Required]
        [StringLength(50)]
        public string Display {  get; set; }
        [Required]
        [StringLength(50)]
        public string Graphics { get; set; }
        [Required]
        [StringLength(50)]
        public string Image { get; set; }
        [Required]
        [StringLength(50)]
        public string Brand { get; set; }
        [Required]
        [NotMapped]
        public IFormFile LaptopPhoto { get; set; }

        [Required]

        public int price { get; set; }
        [NotMapped]
        [ForeignKey("Carts")]

        public int card_id { get; set; }
    
        public virtual List<Cart> Carts { get; set; }
        

        


    }
}
