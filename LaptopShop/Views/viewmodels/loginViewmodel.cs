using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace LaptopShop.Views.viewmodels
{
	public class loginViewmodel
	{
		public string Username { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public bool RememberMe { get; set; }


		public IEnumerable<AuthenticationScheme>? Schemes { get; set; }
	}
}
