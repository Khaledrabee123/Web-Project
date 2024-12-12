using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store.Models.DTO
{
    public class BookDTO
    {
        [NotMapped]
        public int Id { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        
        public string Author { get; set; }

        [Required]

        public string Category { get; set; }
        [Required]
        public decimal Price { get; set; }


    }
}
