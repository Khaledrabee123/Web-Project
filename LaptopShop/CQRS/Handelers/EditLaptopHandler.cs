using LaptopShop.CQRS.Commands;
using LaptopShop.Models.database;
using MediatR;

namespace LaptopShop.CQRS.Handelers
{
	public class EditLaptopHandler : IRequestHandler<EditLaptopCommand,Laptop>
	{

		private readonly DBlaptops db;

		public EditLaptopHandler(DBlaptops db)
		{
			this.db = db;
		}

		async Task<Laptop> IRequestHandler<EditLaptopCommand, Laptop>.Handle(EditLaptopCommand request, CancellationToken cancellationToken)
		{
			db.Laptops.Update(request.laptop);
			await db.SaveChangesAsync();
			return request.laptop;
		
		}
	}
}
