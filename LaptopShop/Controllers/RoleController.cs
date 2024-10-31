using LaptopShop.Views.viewmodels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using LaptopShop.Views.viewmodels;
using System.Data;
namespace LaptopShop.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddRoel(Roleview roleview)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = roleview.RoleName;
                IdentityResult res  = await  roleManager.CreateAsync(identityRole);
                
                if ( res.Succeeded)
                {
                    return RedirectToAction("Index");
                }
              
            }
            return View(roleview);

        }
    }
}
