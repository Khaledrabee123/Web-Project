using System.Security.Claims;
using Elfie.Serialization;
using LaptopShop.CQRS.Commands;
using LaptopShop.Models.database;
using LaptopShop.Models.reposatorys;
using LaptopShop.Resources;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Stripe;

namespace LaptopShop.Controllers
{
    public class paymentController : Controller
    {   
        private readonly IMediator mediator;
        private readonly IConfiguration _configuration;
        private readonly ChargeService _chargeService;
        private readonly CustomerService _customerService;
        private readonly ILogger<paymentController> _logger;
		public paymentController(IConfiguration configuration, ChargeService chargeService, CustomerService customerService, ILogger<paymentController> logger, IMediator mediator)
		{
			_configuration = configuration;
			_chargeService = chargeService;
			_customerService = customerService;
			_logger = logger;
			this.mediator = mediator;
		}
		public IActionResult Index()
        {
            return View();
        }

   

        [HttpPost]
        public async Task<IActionResult> Charge(decimal totalPrice, string stripeToken)
        {

            var stripeKey = _configuration["StripeOptions:SecretKey"];
            if (string.IsNullOrEmpty(stripeKey))
            {
                throw new Exception("Stripe API key is missing from configuration.");
            }
            StripeConfiguration.ApiKey = stripeKey;

            try
            {
                Console.WriteLine($"TotalPrice: {totalPrice}, StripeToken: {stripeToken}");

                var customer = await _customerService.CreateAsync(new CustomerCreateOptions
                {
                    Name = User.FindFirstValue(ClaimTypes.Name),
                    Email = User.FindFirstValue(ClaimTypes.Email),
                    Source = stripeToken
                });

                var options = new ChargeCreateOptions
                {
                    Currency = "USD",
                    Amount = (long)(totalPrice* 100), // Convert to cents
                    ReceiptEmail = User.FindFirstValue(ClaimTypes.Email),
                    Customer = customer.Id
                };

              var order =     mapper.MakeOrder( User.FindFirstValue(ClaimTypes.NameIdentifier),totalPrice);
               await mediator.Send(new AddOrderCommand(order));
				Charge charge = await _chargeService.CreateAsync(options);
				ViewBag.UserName = order.User;

				return charge.Status == "succeeded"
					? RedirectToAction("Success", "payment")
					: RedirectToAction("Failure", "payment");
			}
            catch (StripeException ex)
            {
                return RedirectToAction("Failure", new { errorMessage = ex.Message });
            }
        }
        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Failure(string errorMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }

    }
}
