using GameFinder.Domain.Entities;
using GameFinder.Domain.Repositories;
using GameFinder.Infrastructure.Persistance;
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

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
