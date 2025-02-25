using LaptopShop.CQRS.Queries;
using LaptopShop.Models.database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop.CQRS.Handelers
{
	public class GetUsersLaptopsByUserIDHandler : IRequestHandler<GetUsersLaptopsByUserIDQuery, List<Laptop>>
	{
		private readonly DBlaptops db;

		public GetUsersLaptopsByUserIDHandler(DBlaptops db)
		{
			this.db = db;
		}

		public async Task<List<Laptop>> Handle(GetUsersLaptopsByUserIDQuery request, CancellationToken cancellationToken)
		{
			return await db.Laptops.FromSqlRaw("EXEC GeetUserLaptops @p0", request.UserID).ToListAsync();

		}
	}
}
