﻿using GameFinder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Application.Data
{
    public interface IDbContext
    {
        DbSet<Address> Address { get; set; }
        DbSet<Court> Court { get; set; }
        DbSet<Game> Game { get; set; }
        DbSet<GameDetails> Game_Details { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<Sport> Sport { get; set; }
        DbSet<User> User { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
