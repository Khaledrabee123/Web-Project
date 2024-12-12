using LaptopShop.Models.database;
using LaptopShop.Models.servive;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace LaptopShop.Controllers
{
    [Authorize]
    public class LaptopController : Controller
    {
        laptopSetvice laptopSetvice;
        ILogger<LaptopController> _logger;
        IMemoryCache _Cache;
        public LaptopController(laptopSetvice lp, ILogger<LaptopController> logger, IMemoryCache cache)
        {
            laptopSetvice = lp;
            _logger = logger;
            _Cache = cache;
        }

        public IActionResult Index()
        {
            string key = "GetAllLaptops";
            if (_Cache.TryGetValue(key, out List<Laptop> data))
            {
                _logger.LogInformation("found in the cache");
                return View(data);

            }
           
            
            var cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(5))
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
            .SetPriority(CacheItemPriority.Normal);
            data = laptopSetvice.getAll();
            _Cache.Set(key, data, cacheOptions);
            
            
            _logger.LogInformation("Not found in the cache");
            
            
            return View(data);
        }







        public IActionResult gitbyid(int Id)
        {
            return View(laptopSetvice.getLaptopbyid(Id));
        }

        public IActionResult getcatagory(String catagory)
        {
            string key = "Catagorty" + catagory;
            if (_Cache.TryGetValue(key, out List<Laptop> data))
            {
                _logger.LogInformation("found in the cache");
                return View("Index", data);

            }
            
            var cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(5))
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
            .SetPriority(CacheItemPriority.Normal);
            data = laptopSetvice.getbyCategorie(catagory);
            _Cache.Set(key, data, cacheOptions);
            
            
            _logger.LogInformation("Not found in the cache");
            
            
            
            return View("Index", data);
        }


    }
}
