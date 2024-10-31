using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShop.Models.database
{
	public class Order
	{
		[Key]
		public string  Id { get; set; }
		[ForeignKey("User")]
		public string UserId { get; set; }
		public DateTime OrderDate { get; set; }
		public string Status { get; set; }
		public decimal TotalAmount { get; set; }
		public virtual User?User {  get; set; }
	}

	
}
