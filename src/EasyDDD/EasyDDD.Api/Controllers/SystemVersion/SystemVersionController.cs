using EasyDDD.Application.SystemVersions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyDDD.Api.Controllers.SystemVersion
{
    [ApiController]
    [Area("SystemVersion")]
    [Route("version-controller")]
    public class SystemVersionController : ApiController
    {
        public SystemVersionController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpGet]
        [Route("release-number")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _mediator.Send(new GetSystemVersionQuery()));
        }
    }
}
