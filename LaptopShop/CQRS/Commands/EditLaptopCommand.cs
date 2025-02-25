using LaptopShop.Models.database;
using MediatR;

namespace LaptopShop.CQRS.Commands
{
	public record EditLaptopCommand(Laptop laptop):IRequest<Laptop>;
	
}
