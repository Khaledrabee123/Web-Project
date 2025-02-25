using LaptopShop.CQRS.Commands;
using LaptopShop.Models.database;
using MediatR;
using NuGet.Protocol.Plugins;

namespace LaptopShop.CQRS.Handelers
{
	public class AddLaptopHandler : IRequestHandler<AddLaptopCommand, Laptop>
	{
	 private readonly	DBlaptops db;

		public AddLaptopHandler(DBlaptops db)
		{
			this.db = db;
		}

		public async Task<Laptop> Handle(AddLaptopCommand request, CancellationToken cancellationToken)
		{
			await db.Laptops.AddAsync(request.Laptop);
			await db.SaveChangesAsync();
			return request.Laptop;
		}
	}
}
