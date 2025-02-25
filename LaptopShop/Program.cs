using System.Reflection;
using LaptopShop.ChatHub;
using LaptopShop.Models.database;
using LaptopShop.Models.reposatorys;
using LaptopShop.Models.servive;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using MediatR;
using Stripe;
namespace LaptopShop
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddScoped<CustomerService>();
			builder.Services.AddScoped<ChargeService>();

			StripeConfiguration.ApiKey = builder.Configuration.GetValue<string>("StripeOptions:SecretKey");

			builder.Services.AddControllersWithViews();
			builder.Services.AddSignalR();
			builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

			builder.Services.AddMemoryCache();
			builder.Services.AddSerilog();
			builder.Host.UseSerilog((context, configuration) =>
				configuration.ReadFrom.Configuration(context.Configuration));


			builder.Services.AddDbContext<DBlaptops>(OptionsBuilder =>
			{
				OptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
			});

			
			builder.Services.AddTransient<ISenderEmail, EmailSender>();


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
