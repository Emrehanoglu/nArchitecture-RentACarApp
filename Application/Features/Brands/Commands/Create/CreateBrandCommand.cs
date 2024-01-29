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
		public Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
		{
			CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
			createdBrandResponse.Name = request.Name;
			createdBrandResponse.Id = new Guid();
			return null;
		}
	}
}