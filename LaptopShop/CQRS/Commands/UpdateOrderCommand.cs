using LaptopShop.Models.database;
using MediatR;

namespace LaptopShop.CQRS.Commands
{
	public record UpdateOrederCommand(Order order):IRequest<Order>;
}
