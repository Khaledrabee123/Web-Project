using LaptopShop.Models.database;
using MediatR;

namespace LaptopShop.CQRS.Queries
{
	public record GetLaptopsByCategorieQuery(string brand) :IRequest<List<Laptop>>;
	
}
