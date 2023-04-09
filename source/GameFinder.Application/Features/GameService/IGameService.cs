using GameFinder.Application.Models;
using GameFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Application.Features.GameService
{
    public interface IGameService
    {
        Task<Game> AddGame(NewGameDto newgame);
    }
}
