using LaptopShop.CQRS.Commands;
using LaptopShop.Models.database;
using MediatR;

namespace LaptopShop.CQRS.Handelers
{
	public class AddToCartHandler : IRequestHandler<AddToCartCommand,Cart>
	{
		private readonly DBlaptops db;

		public AddToCartHandler(DBlaptops db)
		{
			this.db = db;
		}

		public async Task<Cart> Handle(AddToCartCommand request, CancellationToken cancellationToken)
		{
		    await  db.Carts.AddAsync(request.Cart);
			await  db.SaveChangesAsync();
			return request.Cart;
		}
	}
}
