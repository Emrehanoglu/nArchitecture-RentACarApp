﻿using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

//api 'den buraya bir istek gelecek
//CreatedBrandResponse döndürecek
public class CreateBrandCommand:IRequest<CreatedBrandResponse>, ITransactionalRequest 
{
    public string Name { get; set; }

	//api 'den CreateBrandCommand geldiğinde aşağıdaki handler calisacak
	public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
	{
		private readonly IBrandRepository _brandRepository;
		private readonly IMapper _mapper;
		private readonly BrandBusinessRules _brandBusinessRules;

		public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
		{
			_brandRepository = brandRepository;
			_mapper = mapper;
			_brandBusinessRules = brandBusinessRules;
		}

		public async Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
		{
			//iş kurallarını kontrol edelim...
			await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.Name);

			//gelen requesti Brand 'e cevir
			Brand brand = _mapper.Map<Brand>(request); 
			brand.Id = Guid.NewGuid();

			Brand brand2 = _mapper.Map<Brand>(request);
			brand2.Id = Guid.NewGuid();

			await _brandRepository.AddAsync(brand);
			await _brandRepository.AddAsync(brand2);

			//result 'ı CreatedBrandResponse 'a cevir
			CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(brand);

			return createdBrandResponse;
		}
	}
}