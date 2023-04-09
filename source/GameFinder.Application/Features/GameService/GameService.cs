using GameFinder.Application.Data;
using GameFinder.Application.Models;
using GameFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Application.Features.GameService
{
    public class GameService : IGameService
    {
        private readonly IDbContext _context;
        public GameService(IDbContext context)
        {
            _context = context;
        }
        public async Task<Game> AddGame(NewGameDto newgame)
        {
            Game game = new Game()
            {
               CourtId = newgame.CourtId,
               SportId = newgame.SportId,
               Start = newgame.Start,
               PrecictedEnd = newgame.PrecictedEnd
            };
            await _context.Game.AddAsync(game);
            await _context.SaveChangesAsync();
            return game;
        }
    }
}
