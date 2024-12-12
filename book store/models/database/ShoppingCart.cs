using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace book_store.models.database
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string User_Id { get; set; }
        [ForeignKey("Books")]
        public int book_id { get; set; }
        public virtual User User { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
