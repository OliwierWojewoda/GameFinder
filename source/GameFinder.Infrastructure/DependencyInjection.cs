using GameFinder.Application.Data;
using GameFinder.Domain.Repositories;
using GameFinder.Infrastructure.Persistance;
using GameFinder.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Infrastructure 
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<IDbContext,ApplicationDbContext>();
            services.AddScoped<ICourtRepository, CourtRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
