using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Base.Controllers
{
    public abstract class BaseController: Controller
    {
        private IMediator? _mediator;
        protected IMediator Mediator => _mediator ??= (HttpContext.RequestServices.GetService(typeof(IMediator)) as IMediator)!;
        
    }
}