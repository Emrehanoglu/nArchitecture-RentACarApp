using Application.Features.Brands.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules;

public class BrandBusinessRules
{
	private readonly IBrandRepository _brandRepository;

	public BrandBusinessRules(IBrandRepository brandRepository)
	{
		_brandRepository = brandRepository;
	}

	//Brand Name ekleme esnasında tekrar etmemeli
	public async Task BrandNameCannotBeDuplicatedWhenInserted(string name)
	{
		//böyle bir marka olmayabileceği için nullable işaretlendi
		Brand? result = await _brandRepository.GetAsync(predicate: b => b.Name.ToLower() == name);

		if (result != null) 
		{
			throw new BusinessException(BrandsMessages.BrandNameExists);
		}
	}
}
