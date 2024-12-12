using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using book_store.models.database;
using lapAPIshop.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public UserManager<User> UserManager { get; set; }
        public UserController(UserManager<User> userManager, IConfiguration configuration)
        {
            UserManager = userManager;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> register(UserRegestertionDTO userregister)
        {
            if (ModelState.IsValid)
            {

                User user = new User();
                user.UserName = userregister.UserName;
                user.Email = userregister.Email;

                var res = await UserManager.CreateAsync(user, userregister.Password);
                if (res.Succeeded)
                {
                    return Ok("acount created");
                }
                else
                {
                    return BadRequest(res.Errors.FirstOrDefault().ToString());
                }
            }
            return BadRequest(ModelState);

        }
        [HttpPost("login")]
        public async Task<IActionResult> login(UserLoginDTO loginUser)
        {
            if (ModelState.IsValid)
            {
                User user = await UserManager.FindByNameAsync(loginUser.Username);
                if (user != null && await UserManager.CheckPasswordAsync(user, loginUser.Password))
                {



                    //create claim
                    List<Claim> Claims = new List<Claim>();
                    Claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    Claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    Claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                    //Create Role
                    var rols = await UserManager.GetRolesAsync(user);
                    foreach (var item in rols)
                    {
                        Claims.Add(new Claim(ClaimTypes.Role, item));
                    }

                    // signing credentials 
                    SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(s: configuration["JWT:Secret"]));
                    SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                    JwtSecurityToken token = new JwtSecurityToken(
                        issuer: configuration["JWT:ValidIssuer"],
                        audience: configuration["JWT:Validaudience"],
                        claims: Claims,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: signingCredentials


                        );
                    return Ok(new
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo

                    });



                }


            }
            return BadRequest(ModelState);
        }




    }
}
