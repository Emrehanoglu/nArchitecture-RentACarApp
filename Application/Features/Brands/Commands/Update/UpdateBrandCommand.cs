using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Update;

public class UpdateBrandCommand:IRequest<UpdatedBrandResponse>
{
	//update işlemi için gelindiğinde aşağıdaki bilgiler ile gelinecek
	public Guid Id { get; set; }
	public string Name { get; set; }

	public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
	{
		private readonly IMapper _mapper;
		private readonly IBrandRepository _brandRepository;

		public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
		{
			_brandRepository = brandRepository;
			_mapper = mapper;
		}

		public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
		{
			//oncelikle ilgili Brand 'i veritabanında cekiyorum
			Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id);
			//asenkron operasyonlar için ikinci parameter olarak cancellationToken vermesende olur

			brand = _mapper.Map(request,brand); //id ile kayıt bulunduysa, ilgili request 'i Brand nesnesine cevir

			await _brandRepository.UpdateAsync(brand);

			//güncellenen brand nesnesini artık UpdatedBrandResponse 'a cevirip return edebilirim.
			UpdatedBrandResponse response = _mapper.Map<UpdatedBrandResponse>(brand);
			return response;
		}
	}
}
