using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace book_store.models.database
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string BookName { get; set; }
        [Required]

        public decimal Price { get; set; }
        [Required]

        public string Category { get; set; }

        [Required]
        public string Author { get; set; }
        [NotMapped]
        [ForeignKey("ShoppingCarts")]
        public int ShopingCart_id { get; set; }

        public virtual List<ShoppingCart>? ShoppingCarts { get; set; }
    }
}
