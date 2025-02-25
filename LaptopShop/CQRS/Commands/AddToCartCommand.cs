using LaptopShop.Models.database;
using MediatR;

namespace LaptopShop.CQRS.Commands
{
	public record AddToCartCommand(Cart Cart):IRequest<Cart>;
	
}
