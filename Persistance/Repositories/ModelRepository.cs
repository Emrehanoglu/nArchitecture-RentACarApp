using Application.Services.Repositories;
using Core.Persistance.Repositories;
using Persistance.Contexts;
using Domain.Entities;

namespace Persistance.Repositories;

public class ModelRepository : EfRepositoryBase<Model, Guid, BaseDbContext>, IModelRepository
{
	public ModelRepository(BaseDbContext context) : base(context)
	{
	}
}
