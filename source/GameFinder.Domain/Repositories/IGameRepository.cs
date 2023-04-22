using GameFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Domain.Repositories
{
    public interface IGameRepository
    {
        Task<int> AddGame(Game newGame);
        Task<Game> GetGameById(int id);
        Task<bool> DeleteGame(Game gameToDelete);
        Task<List<Game>> GetAllGames();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
