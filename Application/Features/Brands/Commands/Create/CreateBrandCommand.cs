using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

//api 'den buraya bir istek gelecek
public class CreateBrandCommand:IRequest<CreatedBrandResponse> //CreatedBrandResponse döndürecek
{
    public string Name { get; set; }

	//api 'den CreateBrandCommand geldiğinde aşağıdaki handler calisacak
	public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
	{
		private readonly IBrandRepository _brandRepository;
		private readonly IMapper _mapper;

		public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
		{
			_brandRepository = brandRepository;
			_mapper = mapper;
		}

		public async Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
		{
			//gelen requesti Brand 'e cevir
			Brand brand = _mapper.Map<Brand>(request); 
			brand.Id = Guid.NewGuid();

			await _brandRepository.AddAsync(brand);

			//result 'ı CreatedBrandResponse 'a cevir
			CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(result);

			return createdBrandResponse;
		}
	}
}