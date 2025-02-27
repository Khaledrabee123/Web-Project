using System.Security.Claims;
using System.Text;
using LaptopShop.CQRS.Commands;
using LaptopShop.CQRS.Queries;
using LaptopShop.Models.database;
using LaptopShop.Models.reposatorys;
using LaptopShop.Models.servive;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace LaptopShop.Controllers
{
    public class CartController : Controller
    {
        IMediator mediator;
        private readonly IMemoryCache _cache;
        public ILogger<CartController> _Logger;

		public CartController( DBlaptops dBlaptops, ILogger<CartController> logger, IMemoryCache memory, IMediator mediator)
		{
			_Logger = logger;
			
			_cache = memory;
			this.mediator = mediator;
		}




		public async Task<IActionResult> viewCart(string username)
        {

            int totla = 0;
            string userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var data = await mediator.Send(new GetUsersLaptopsByUserIDQuery(userID));
           
            foreach (var item in data)
            {
                totla += item.price;
            }
            ViewBag.Total = totla;

            return View(data);
          
        }








        public async Task<IActionResult> AddToCard(string username, int Id)
        {
            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Cart cart =  mapper.makeCart(UserId,Id);

              await mediator.Send(new AddToCartCommand(cart));
            
            _Logger.LogInformation("{username} added this Product ID {id} to his Cart", username,Id);
            
            return RedirectToAction("Index", "Laptop");
        }
        








        public async Task< ActionResult> deletitem(int Laptopid, string username)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();


            await   mediator.Send(new DeleteFromCartCommand(userId, Laptopid));

            
            _Logger.LogInformation("{username} deleted this Product ID {id} to his Cart", username, Laptopid);


            return RedirectToAction ("viewCart","Cart",username);
        }














        public IActionResult buy()
        {
            return View();
        }
    }
}
