using LaptopShop.CQRS.Queries;
using LaptopShop.Models.database;
using LaptopShop.Models.servive;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace LaptopShop.Controllers
{
    [Authorize]
    public class LaptopController : Controller
    {
        private readonly IMediator mediator;
        ILogger<LaptopController> _logger;
        IMemoryCache _Cache;
		public LaptopController( ILogger<LaptopController> logger, IMemoryCache cache, IMediator mediator)
		{
			_logger = logger;
			_Cache = cache;
			this.mediator = mediator;
		}

		public async Task< IActionResult> Index()
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
            data = await mediator.Send(new GetAllLaptopsQuery());
            _Cache.Set(key, data, cacheOptions);
            
            
            _logger.LogInformation("Not found in the cache");
            
            
            return View(data);
        }







        public async Task<IActionResult> gitbyid(int Id)
        {
			return  View(await mediator.Send(new GetLaptopByIdQuery(Id)));
		}

        public async Task<IActionResult> getcatagory(String catagory)
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
            data = await mediator.Send(new GetLaptopsByCategorieQuery(catagory));
            _Cache.Set(key, data, cacheOptions);
            
            
            _logger.LogInformation("Not found in the cache");
            
            
            
            return View("Index", data);
        }


    }
}
