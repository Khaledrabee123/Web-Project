using System.Drawing.Drawing2D;
using LaptopShop.CQRS.Queries;
using LaptopShop.Models.database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop.CQRS.Handelers
{
	public class GetLaptopsByCategorieHandler : IRequestHandler<GetLaptopsByCategorieQuery, List<Laptop>>
	{
		private readonly DBlaptops db;

		public GetLaptopsByCategorieHandler(DBlaptops db)
		{
			this.db = db;
		}

		public async Task<List<Laptop>> Handle(GetLaptopsByCategorieQuery request, CancellationToken cancellationToken)
		{
			return await db.Laptops.Where(e => e.Brand == request.brand).ToListAsync();
		}
	}
}
