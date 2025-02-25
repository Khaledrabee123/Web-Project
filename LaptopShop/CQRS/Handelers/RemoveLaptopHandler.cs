using LaptopShop.CQRS.Commands;
using LaptopShop.Models.database;
using MediatR;

namespace LaptopShop.CQRS.Handelers
{
	public class RemoveLaptopHandler : IRequestHandler<RemoveLaptopCommand, Laptop>
	{
		private readonly DBlaptops db;

		public RemoveLaptopHandler(DBlaptops db)
		{
			this.db = db;
		}

		public async Task<Laptop> Handle(RemoveLaptopCommand request, CancellationToken cancellationToken)
		{
			db.Laptops.Remove(request.laptop);
			await db.SaveChangesAsync();
			return request.laptop;
		}
	}
}
