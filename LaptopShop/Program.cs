using LaptopShop.ChatHub;
using LaptopShop.Models.database;
using LaptopShop.Models.interfaces;
using LaptopShop.Models.reposatorys;
using LaptopShop.Models.servive;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Stripe;
using LaptopShop.Services;

namespace LaptopShop
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddSignalR();
			builder.Services.AddDbContext<DBlaptops>(OptionsBuilder =>
			{
				OptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
			});

            builder.Services.AddScoped<TokenService>();
            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<ChargeService>();

            builder.Services.AddScoped<IStripeService, StripeService>();
            StripeConfiguration.ApiKey = builder.Configuration.GetValue<string>("StripeOptions:SecretKey");

            builder.Services.AddScoped<laptopSetvice>();
			builder.Services.AddScoped<LaptopReposatory>();
			builder.Services.AddScoped<OrderRepository>();
			builder.Services.AddScoped<CartReposatory>();
            builder.Services.AddScoped<Randomreposatory>();
            builder.Services.AddScoped<ILaptop, LaptopReposatory>();
            builder.Services.AddScoped<IRandom, Randomreposatory>();
            builder.Services.AddScoped<IOrder, OrderRepository>();
			builder.Services.AddScoped<ICart, CartReposatory>();

            builder.Services.AddMemoryCache();
			builder.Services.AddSerilog();
			builder.Host.UseSerilog((context, configuration) =>
				configuration.ReadFrom.Configuration(context.Configuration));

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
             .AddEntityFrameworkStores<DBlaptops>()
                  .AddDefaultTokenProviders(); // This li
            builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(3); // Set token expiration time as needed
            });

            builder.  Services.AddTransient<ISenderEmail, EmailSender>();
            builder.Services.AddAuthentication().AddGoogle(options =>
			{
				var googleAuthSettings = builder.Configuration.GetSection("Authentication:Google");
				options.ClientId = googleAuthSettings["ClientId"];
				options.ClientSecret = googleAuthSettings["ClientSecret"];
			});


			var app = builder.Build();
			app.UseSerilogRequestLogging();


			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.MapHub<Chathub>("/Chat");
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}/{username?}/{TotalAmount?}");

			app.Run();
		}
	}
}
