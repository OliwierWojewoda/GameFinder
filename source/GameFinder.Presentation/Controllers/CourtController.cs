using GameFinder.Application.Features.Courts.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Presentation.Controllers
{
    [Route("api/Court")]
    public class CourtController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourtController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/AddCourt")]
        public async Task<IActionResult> AddCourt([FromBody] CreateCourtCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
