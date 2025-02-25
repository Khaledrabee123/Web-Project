using LaptopShop.Models.database;
using MediatR;

namespace LaptopShop.CQRS.Commands
{
	public record RemoveLaptopCommand (Laptop laptop): IRequest<Laptop>;
}
