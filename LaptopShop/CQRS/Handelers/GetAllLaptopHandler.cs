using LaptopShop.CQRS.Queries;
using LaptopShop.Models.database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop.CQRS.Handelers
{
	public class GetAllLaptopHandler : IRequestHandler<GetAllLaptopsQuery, List<Laptop>>
	{
		private readonly DBlaptops db;

		public GetAllLaptopHandler(DBlaptops db)
		{
			this.db = db;
		}

		public async Task<List<Laptop>> Handle(GetAllLaptopsQuery request, CancellationToken cancellationToken)
		{
			return await db.Laptops.ToListAsync();
		}
	}
}
