using GameFinder.Application.Features.Courts.Commands;
using GameFinder.Application.Features.UserService;
using GameFinder.Application.Models;
using GameFinder.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GameFinder.Presentation.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpPost("/Register")]
        public async Task<ActionResult<List<User>>> Register(NewUserDto newUser)
        {  
            return Ok(await _service.Register(newUser));
        }
        [HttpPost("/Login")]
        public async Task<ActionResult<User>> Login(LoginUserDto user)
        {
            return Ok(await _service.Login(user));
        }
    }
}
