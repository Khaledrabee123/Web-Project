using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopShop.Views.viewmodels
{
	public class ViewUser
	{
		[NotMapped]
	     public string? Id {  get; set; }
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public string UserName { get; set; }
		[Compare("Password")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

	}
}
