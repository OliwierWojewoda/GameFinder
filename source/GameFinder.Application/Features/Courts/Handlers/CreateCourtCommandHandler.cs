using GameFinder.Application.Data;
using GameFinder.Application.Features.Courts.Commands;
using GameFinder.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Application.Features.Courts.Handlers
{
    internal sealed class CreateCourtCommandHandler : IRequestHandler<CreateCourtCommand>
    {
        private readonly IDbContext _dbContext;

        public CreateCourtCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CreateCourtCommand request, CancellationToken cancellationToken)
        {
            var newCourt = Court.New(request.city_Id);

            await _dbContext.Court.AddAsync(newCourt);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
