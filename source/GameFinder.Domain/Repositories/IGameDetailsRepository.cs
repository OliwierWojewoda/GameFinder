using GameFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Domain.Repositories
{
    public interface IGameDetailsRepository
    {
        Task<int> AddUserToGame(GameDetails gameDetails);
        Task<bool> DeleteUserFromGame(GameDetails gameDetails);
        Task<GameDetails> GetGameDetails(int gameId, int userId);
        Task<List<GameDetails>> GetAllGameUsers(int gameId);
        Task<List<GameDetails>> GetAllUsersInAllGame();
        Task<List<GameDetails>> GetAllUserGames(int userId);
    }
}
