using Application.Services.Repositories;
using Core.Persistance.Repositories;
using Persistance.Contexts;
using Domain.Entities;

namespace Persistance.Repositories;

public class TransmissionRepository : EfRepositoryBase<Transmission, Guid, BaseDbContext>, ITransmissionRepository
{
	public TransmissionRepository(BaseDbContext context) : base(context)
	{
	}
}
