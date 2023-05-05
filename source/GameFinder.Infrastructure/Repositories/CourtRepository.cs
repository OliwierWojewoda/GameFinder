using GameFinder.Domain.Entities;
using GameFinder.Domain.Repositories;
using GameFinder.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameFinder.Infrastructure.Repositories
{
    public class CourtRepository : ICourtRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CourtRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<int> CourtAddAsync(Court newCourt)
        {
            var result = await _dbContext.Court.AddAsync(newCourt);
            return result.Entity.CourtId;
        }

        public async Task<bool> Delete(Court courtToDelete)
        {
            _dbContext.Court.Remove(courtToDelete);
            return await Task.FromResult(true);
        }

        public async Task<Court> GetCourtById(int id)
        {
            return await _dbContext.Court.Include(x => x.Address).FirstOrDefaultAsync(court => court.CourtId == id);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<List<Court>> GetAllCourts()
        {
            return await _dbContext.Court.Include(x=> x.Address).ToListAsync();
        }
    }
}
