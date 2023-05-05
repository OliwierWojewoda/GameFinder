using GameFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Domain.Repositories
{
    public interface ICourtRepository
    {
        Task<int> CourtAddAsync(Court newCourt);
        Task<Court> GetCourtById(int id);
        Task<bool> Delete(Court courtToDelete);
        Task<List<Court>> GetAllCourts();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
