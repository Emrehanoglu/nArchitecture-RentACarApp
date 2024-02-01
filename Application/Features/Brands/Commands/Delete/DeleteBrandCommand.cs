using Application.Features.Brands.Commands.Update;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommand:IRequest<DeletedBrandResponse>
{
    //silmek istediğim datanın Id 'si
    public Guid Id { get; set; }

	public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
	{
		private readonly IMapper _mapper;
		private readonly IBrandRepository _brandRepository;

		public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
		{
			_brandRepository = brandRepository;
			_mapper = mapper;
		}

		public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
		{
			//oncelikle ilgili Brand 'i veritabanında cekiyorum
			Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id);
			//asenkron operasyonlar için ikinci parameter olarak cancellationToken vermesende olur

			await _brandRepository.DeleteAsync(brand); //soft delete yapıyoruz burada, permanent false olduğu için kalıcı silmez

			//güncellenen brand nesnesini artık UpdatedBrandResponse 'a cevirip return edebilirim.
			DeletedBrandResponse response = _mapper.Map<DeletedBrandResponse>(brand);
			return response;
		}
	}
}
