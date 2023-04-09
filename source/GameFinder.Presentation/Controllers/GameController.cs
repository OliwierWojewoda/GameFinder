using GameFinder.Application.Features.GameService;
using GameFinder.Application.Models;
using GameFinder.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameFinder.Presentation.Controllers
{
    [Route("api/Game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _service;  
        public GameController(IGameService service)
        {
            _service = service; 
        }
        [HttpPost("/Add")]
        public async Task<ActionResult<Game>> AddGame(NewGameDto newgame)
        {
            return await _service.AddGame(newgame);
        }
    }
}
