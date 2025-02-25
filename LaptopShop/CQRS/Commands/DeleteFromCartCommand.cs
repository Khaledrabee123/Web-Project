using LaptopShop.Models.database;
using MediatR;

namespace LaptopShop.CQRS.Commands
{
	

public record DeleteFromCartCommand(string UserID, int laptopId) : IRequest<int>;
	
}
