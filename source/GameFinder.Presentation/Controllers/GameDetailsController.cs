using GameFinder.Application.Features.Games.Commands;
using GameFinder.Application.Features.GameService.Commands;
using GameFinder.Application.Features.GameDetails.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameFinder.Presentation.Controllers
{
    [Route("api/GameDetails")]
    [ApiController]
    public class GameDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("/GetAllUsersInAllGames")]
        public async Task<IActionResult> GetAllUsersInAllGames([FromQuery] GetAllUsersInAllGamesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("/GetAllUserGames")]
        public async Task<IActionResult> GetAllUserGames([FromQuery] GetAllUserGamesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("/GetAllGameUsers")]
        public async Task<IActionResult> GetAllGameUsers([FromQuery] GetAllGameUsersCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("/DeleteUserFromGame")]
        public async Task<IActionResult> DeleteGame([FromBody] DeleteUserFromGameCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost("/AddUserToGame")]
        public async Task<IActionResult> AddUserToGame([FromBody] AddUserToGameCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
