using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyDDD.Api.Controllers
{
    public class ApiController : ControllerBase
    {
        public readonly IMediator _mediator;

        public ApiController(IMediator mediator)
        {
            _mediator=mediator;
        }
    }
}
