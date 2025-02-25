using LaptopShop.Models.database;
using MediatR;

namespace LaptopShop.CQRS.Commands
{
	public record AddOrderCommand (Order order): IRequest<Order>;
	
}
