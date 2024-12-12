using System.Security.Claims;
using book_store.models.database;
using book_store.models.Repositories;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace book_store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopingCartController : ControllerBase
    {

        UserManager<User> userManager;
        private readonly ILogger<ShopingCartController> logger;
        private readonly ICart cartReposatory;


        public ShopingCartController(UserManager<User> userManager, ICart cartReposatory, ILogger<ShopingCartController> logger)
        {
            this.userManager = userManager;

            this.cartReposatory = cartReposatory;
            this.logger = logger;
        }
        [HttpGet("view")]
        public async Task<IActionResult> viewCard(string username)
        {

            int totla = 0;
            string userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var data = cartReposatory.getUserBooks(userID);

            return Ok(data);

        }







        [HttpPost("add")]
        public IActionResult AddToCard(int Id)
        {
            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            logger.LogInformation("{username} has add the book of {id} id",User.FindFirst(ClaimTypes.Name),Id);
            ShoppingCart cart = cartReposatory.makeCart(UserId, Id);

            cartReposatory.AddToCart(cart);

            return Ok();
        }








        [HttpDelete("delete")]
        public async Task<ActionResult> deletitem(int bookID)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();
            logger.LogInformation("{username} has removed the book of {id} id", User.FindFirst(ClaimTypes.Name), bookID);

            cartReposatory.DeleteFromCart(userId, bookID);
            return Ok();
        }





    }
}
