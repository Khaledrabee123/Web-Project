using LaptopShop.CQRS.Queries;
using LaptopShop.Models.database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace LaptopShop.CQRS.Handelers
{
	public class GetLaptopByIdHandler : IRequestHandler<GetLaptopByIdQuery, Laptop>
	{
		private readonly DBlaptops db;

		public GetLaptopByIdHandler(DBlaptops db)
		{
			this.db = db;
		}
		public async Task<Laptop> Handle(GetLaptopByIdQuery request, CancellationToken cancellationToken)
		{
			return await db.Laptops.FirstOrDefaultAsync(e => e.Id == request.id);
		}
	}
}
