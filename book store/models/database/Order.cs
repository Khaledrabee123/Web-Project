using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace book_store.models.database
{
    public class Order
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("shoppingCart")]
        public int ShoppingCart_ID;
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual ShoppingCart shoppingCart { get; set; }


    }
}
