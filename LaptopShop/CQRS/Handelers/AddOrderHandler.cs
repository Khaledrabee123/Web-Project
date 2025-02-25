using LaptopShop.CQRS.Commands;
using LaptopShop.Models.database;
using MediatR;

namespace LaptopShop.CQRS.Handelers
{
	public class AddOrderHandler : IRequestHandler<AddOrderCommand, Order>
	{
		private readonly DBlaptops db;

		public AddOrderHandler(DBlaptops db)
		{
			this.db = db;
		}

		public async Task<Order> Handle(AddOrderCommand request, CancellationToken cancellationToken)
		{
			db.Order.Add(request.order);
		    await db.SaveChangesAsync();
			return request.order;
		}
	}
}
