using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BaseController:ControllerBase
{
	private IMediator? _mediator;
	//Implemente eden Controller içerisinde _mediator daha once set edilmişse kullan (?? dan öncesi)
	//_mediator set edilmemişse HttpContext servicelerinden IMediator'un karşılığını al ve set et (?? dan sonrası)
	protected IMediator? Mediator => _mediator??= HttpContext.RequestServices.GetService<IMediator>();
}
