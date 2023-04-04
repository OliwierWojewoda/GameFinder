using GameFinder.Application.Features.Cities.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameFinder.Presentation.Controllers
{
    [Route("api/City")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("{name}")]
        public async Task<IActionResult> Create([FromRoute]CreateCityCommand command)
        {
            var result = await _mediator.Send(command);
            return Created($"api/City/{result}",null);
            
        }
    }
}
