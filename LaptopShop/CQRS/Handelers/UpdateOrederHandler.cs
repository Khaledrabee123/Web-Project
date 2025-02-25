using LaptopShop.CQRS.Commands;
using LaptopShop.Models.database;
using MediatR;

namespace LaptopShop.CQRS.Handelers
{
	public class UpdateOrederHandler : IRequestHandler<UpdateOrederCommand, Order>
	{
		private readonly DBlaptops db;

		public UpdateOrederHandler(DBlaptops db)
		{
			this.db = db;
		}

		public async Task<Order> Handle(UpdateOrederCommand request, CancellationToken cancellationToken)
		{
			db.Order.Update(request.order);
			await db.SaveChangesAsync();
			return request.order;
		}
	}
}
