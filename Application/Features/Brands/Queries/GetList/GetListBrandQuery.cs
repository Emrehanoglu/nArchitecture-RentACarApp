using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Response;
using Core.Persistance.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetList;

public class GetListBrandQuery:IRequest<GetListResponse<GetListBrandListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, GetListResponse<GetListBrandListItemDto>>
    {
        private readonly IBrandRepository _brandRepository;
		private readonly IMapper _mapper;

		public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
		{
			_brandRepository = brandRepository;
			_mapper = mapper;
		}

		public async Task<GetListResponse<GetListBrandListItemDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
		{
			//artık elimde Brand tablosundaki tüm datalar var
			Paginate<Brand> brands =  await _brandRepository.GetListAsync(
				index: request.PageRequest.PageIndex,
				size: request.PageRequest.PageSize,
				cancellationToken: cancellationToken
				);

			//yukarıda belirttiğim veri tipini artık mapleyip donebilirim
			GetListResponse<GetListBrandListItemDto> response = _mapper.Map<GetListResponse<GetListBrandListItemDto>>(brands);
			return response;
		}
	}
}
