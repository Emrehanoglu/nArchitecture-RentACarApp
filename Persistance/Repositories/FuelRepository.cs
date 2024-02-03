using Application.Services.Repositories;
using Core.Persistance.Repositories;
using Persistance.Contexts;
using Domain.Entities;

namespace Persistance.Repositories;

public class FuelRepository : EfRepositoryBase<Fuel, Guid, BaseDbContext>, IFuelRepository
{
	public FuelRepository(BaseDbContext context) : base(context)
	{
	}
}
