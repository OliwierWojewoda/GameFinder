using GameFinder.Application.Data;
using GameFinder.Application.Models;
using GameFinder.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Application.Features.Courts.Commands
{
    public record CreateCourtCommand(NewCourtDto newCourtDto) : IRequest<int>;


    public class CreateCourtCommandHandler : IRequestHandler<CreateCourtCommand, int>
    {
        private readonly IDbContext _dbContext;

        public CreateCourtCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateCourtCommand request, CancellationToken cancellationToken)
        {
            var address = Address.New(
                request.newCourtDto.City,
                request.newCourtDto.Street,
                request.newCourtDto.Postal_Code);
            await _dbContext.Address.AddAsync(address);

            var newCourt = Court.New(address.AddressId, request.newCourtDto.CourtType);

            var result = await _dbContext.Court.AddAsync(newCourt);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return result.Entity.CourtId;
        }
    }

}
