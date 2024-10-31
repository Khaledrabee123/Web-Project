using System.Security.Claims;
using LaptopShop.Models.database;
using LaptopShop.Views.viewmodels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaptopShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly laptopSetvice laptopSetvice;
        ILogger<AdminController> _logger;
        public IWebHostEnvironment _hostingEnvironment { get; }

        public AdminController(laptopSetvice laptopSetvice, IWebHostEnvironment hostingEnvironment, ILogger<AdminController> logger)
        {
            this.laptopSetvice = laptopSetvice;
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

                Laptop laptop = laptopSetvice.MakeLaptop(receivelaptop);

                if (laptop.LaptopPhoto != null && laptop.LaptopPhoto.Length > 0)
                {

                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "imges");
                    var filePath = Path.Combine(uploads, laptop.LaptopPhoto.FileName);
                    await laptop.LaptopPhoto.CopyToAsync(new FileStream(filePath, FileMode.Create));

                }


                laptopSetvice.add(laptop);

                var admin = User.FindFirst(ClaimTypes.Name).Value.ToString();

                _logger.LogDebug("{admin} add {@laptop}", admin, laptop);

                return RedirectToAction("Index");
            }

            return View(receivelaptop);

        }

        public IActionResult remove(int id)
        {
            Laptop laptop = laptopSetvice.getLaptopbyid(id);

            laptopSetvice.remove(laptop);
            
            var admin = User.FindFirst(ClaimTypes.Name);

            _logger.LogDebug("{admin} removed laptop  {laptopid}", admin, id);

            return RedirectToAction("Index", "Laptop");


        }




    }
}
