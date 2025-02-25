using LaptopShop.Models.database;
using MediatR;

namespace LaptopShop.CQRS.Queries
{
	public record GetLaptopByIdQuery (int id):IRequest<Laptop>;

}
