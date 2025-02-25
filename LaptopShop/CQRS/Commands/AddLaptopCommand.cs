using LaptopShop.Models.database;
using MediatR;

namespace LaptopShop.CQRS.Commands
{
	public record AddLaptopCommand(Laptop Laptop) : IRequest<Laptop>;
	
}
