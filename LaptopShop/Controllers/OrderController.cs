using System.Security.Claims;
using LaptopShop.Models.database;
using LaptopShop.Models.reposatorys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace LaptopShop.Controllers
{
    public class OrderController : Controller
	{
		
		private readonly UserManager<User> userManager;
		ILogger<OrderController> _logger;
		public OrderRepository OrderRepository { get; }

		public OrderController(UserManager<User> userManager, OrderRepository orderRepository , ILogger<OrderController> logger)
		{
			_logger = logger;
			this.userManager = userManager;
			OrderRepository = orderRepository;
		}


		public IActionResult Order(Order order,string Username)
		{
			
			return View(order);
		}

		public async Task<IActionResult> AddOrder(int id,  int TotalAmount, string Username) {

			string Id = User.FindFirstValue(ClaimTypes.NameIdentifier);

			Order order = OrderRepository.MakeOrder(Id, TotalAmount);
			
			OrderRepository.addOrder(order);
            
			_logger.LogInformation("{user} has orderd {@oredr}", Username, order);
            
			ViewBag.UserName = Username;
            return View(order);

        }
	}
}
