using GameFinder.Domain.Entities;
using GameFinder.Domain.Repositories;
using GameFinder.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Infrastructure.Repositories
{
    public class GameDetailsRepository : IGameDetailsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GameDetailsRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<List<GameDetails>> GetAllUsersInAllGame()
        {
            var result = await _dbContext.Game_Details.ToListAsync();
            return result;
        }
        public async Task<List<GameDetails>> GetAllUserGames(int userId)
        {
            var result = await _dbContext.Game_Details.Where(x => x.UserId == userId).ToListAsync();
            return result;
        }
        public async Task<List<GameDetails>> GetAllGameUsers(int gameId)
        {
            var result = await _dbContext.Game_Details.Where(x => x.GameId == gameId).ToListAsync();
            return result;
        }
        public async Task<GameDetails> GetGameDetails(int gameId, int userId)
        {
            var result = await _dbContext.Game_Details.FirstOrDefaultAsync(x => x.GameId == gameId && x.UserId == userId);
            return result;
        }
        public async Task<bool> DeleteUserFromGame(GameDetails gameDetails)
        {
            _dbContext.Game_Details.Remove(gameDetails);
            return await Task.FromResult(true);
        }

        public async Task<int> AddUserToGame(GameDetails gameDetails)
        {
            var result = await _dbContext.Game_Details.AddAsync(gameDetails);
            return result.Entity.GameDetailsId;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
