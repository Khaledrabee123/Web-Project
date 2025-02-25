using System.Security.Claims;
using LaptopShop.CQRS.Commands;
using LaptopShop.CQRS.Queries;
using LaptopShop.Models.database;
using LaptopShop.Models.reposatorys;
using LaptopShop.Models.servive;
using LaptopShop.Views.viewmodels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaptopShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IMediator mediator;
        ILogger<AdminController> _logger;
        public IWebHostEnvironment _hostingEnvironment { get; }

        public AdminController(IMediator mediator , IWebHostEnvironment hostingEnvironment, ILogger<AdminController> logger)
        {
            this.mediator = mediator;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }


        
        [HttpGet]
        public IActionResult addLaptop()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addLaptop(Laptopview receivelaptop)
        {
            if (ModelState.IsValid)
            {

                Laptop laptop = mapper.MakeLaptop(receivelaptop);

                if (laptop.LaptopPhoto != null && laptop.LaptopPhoto.Length > 0)
                {

                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "imges");
                    var filePath = Path.Combine(uploads, laptop.LaptopPhoto.FileName);
                    await laptop.LaptopPhoto.CopyToAsync(new FileStream(filePath, FileMode.Create));

                }


               await mediator.Send(new AddLaptopCommand(laptop));
                var admin = User.FindFirst(ClaimTypes.Name).Value.ToString();

                _logger.LogDebug("{admin} add {@laptop}", admin, laptop);

                return RedirectToAction("Index");
            }

            return View(receivelaptop);

        }

        public async Task< IActionResult> remove(int id)
        {
            Laptop laptop = await mediator.Send(new GetLaptopByIdQuery(id));

            await mediator.Send(new RemoveLaptopCommand(laptop));            
            var admin = User.FindFirst(ClaimTypes.Name);

            _logger.LogDebug("{admin} removed laptop  {laptopid}", admin, id);

            return RedirectToAction("Index", "Laptop");


        }




    }
}
