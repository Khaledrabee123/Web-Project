using LaptopShop.Models.database;
using MediatR;

namespace LaptopShop.CQRS.Queries
{
	public record GetUsersLaptopsByUserIDQuery(string UserID):IRequest<List<Laptop>>;
	
}
