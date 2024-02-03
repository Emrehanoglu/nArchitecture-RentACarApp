using Application.Services.Repositories;
using Core.Persistance.Repositories;
using Persistance.Contexts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories;

public class BrandRepository : EfRepositoryBase<Brand, Guid, BaseDbContext>, IBrandRepository
{
	public BrandRepository(BaseDbContext context) : base(context)
	{
	}
}