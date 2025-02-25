using LaptopShop.Models.database;
using MediatR;

namespace LaptopShop.CQRS.Queries
{
	public record GetAllLaptopsQuery : IRequest<List<Laptop>>;
}
