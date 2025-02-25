using System.Security.Claims;
using LaptopShop.CQRS.Commands;
using LaptopShop.Models.database;
using LaptopShop.Models.reposatorys;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace LaptopShop.Controllers
{
    public class OrderController : Controller
	{
		
		private readonly UserManager<User> userManager;
		ILogger<OrderController> _logger;
		IMediator mediator;
		public OrderController(UserManager<User> userManager, ILogger<OrderController> logger, IMediator mediator)
		{
			_logger = logger;
			this.userManager = userManager;
			this.mediator = mediator;
		}


		public IActionResult Order(Order order,string Username)
		{
			
			return View(order);
		}

		public async Task<IActionResult> AddOrder(int id,  int TotalAmount, string Username) {

			string Id = User.FindFirstValue(ClaimTypes.NameIdentifier);

			Order order = mapper.MakeOrder(Id, TotalAmount);

			await mediator.Send(new AddOrderCommand(order));

			_logger.LogInformation("{user} has orderd {@oredr}", Username, order);
            
			ViewBag.UserName = Username;
            return View(order);

        }
	}
}
