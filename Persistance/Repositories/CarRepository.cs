using Application.Services.Repositories;
using Core.Persistance.Repositories;
using Persistance.Contexts;
using Domain.Entities;

namespace Persistance.Repositories;

public class CarRepository : EfRepositoryBase<Car, Guid, BaseDbContext>, ICarRepository
{
	public CarRepository(BaseDbContext context) : base(context)
	{
	}
}
