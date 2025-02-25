using LaptopShop.CQRS.Commands;
using LaptopShop.Models.database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop.CQRS.Handelers
{
	public class DeleteFromCartHandler : IRequestHandler<DeleteFromCartCommand, int>
	{
		private readonly DBlaptops db;

		public DeleteFromCartHandler(DBlaptops db)
		{
			this.db = db;
		}

		async Task<int> IRequestHandler<DeleteFromCartCommand, int>.Handle(DeleteFromCartCommand request, CancellationToken cancellationToken)
		{
			db.Database.ExecuteSqlRaw("EXEC DeleteCartByUserIdAndLaptopId @p0, @p1", request.UserID, request.laptopId);
            await db.SaveChangesAsync();

			return await Task.FromResult(request.laptopId);
		}
	}
}
