using System.Security.Claims;
using System.Text;
using LaptopShop.Models.database;
using LaptopShop.Models.reposatorys;
using LaptopShop.Models.servive;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace LaptopShop.Controllers
{
    public class CardController : Controller
    {

        laptopSetvice laptopSetvice;
        DBlaptops DBlaptops;
        UserManager<User> userManager;
        private readonly IMemoryCache _cache;
        private readonly CartReposatory cartReposatory;
        public ILogger<CardController> _Logger;

        public CardController( laptopSetvice lp , DBlaptops dBlaptops, UserManager<User> userManager , ILogger<CardController> logger, IMemoryCache memory, CartReposatory cartReposatory )
        {
            this. userManager = userManager;
            _Logger = logger;
            laptopSetvice = lp;
            DBlaptops = dBlaptops;
            _cache = memory;
            this.cartReposatory = cartReposatory;
        }




        public async Task<IActionResult> viewCard(string username)
        {

            int totla = 0;
            string userID = User.FindFirst(ClaimTypes.NameIdentifier).Value; 
            
            var  data =cartReposatory.getUsersLaptops(userID);
           
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

            Cart cart =  cartReposatory.makeCart(UserId, Id);

            cartReposatory.AddToCart(cart);
            
            _Logger.LogInformation("{username} added this Product ID {id} to his Cart", username,Id);
            
            return RedirectToAction("Index","Home");
        }
        








        public async Task< ActionResult> deletitem(int Laptopid, string username)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();


            cartReposatory.DeleteFromCart(userId, Laptopid);

            
            _Logger.LogInformation("{username} deleted this Product ID {id} to his Cart", username, Laptopid);


            return RedirectToAction ("viewCard","Card",username);
        }














        public IActionResult buy()
        {
            return View();
        }
    }
}
