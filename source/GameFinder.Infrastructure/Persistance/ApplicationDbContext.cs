using GameFinder.Application.Data;
using GameFinder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public DbSet<City> City { get; set; }
        public DbSet<Court> Court { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Game_Details> Game_Details { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Sport> Sport { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseInMemoryDatabase(databaseName: "Production_Database");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>()
                .HasData(
                new Role() { Role_Id = 1, Name = "Player" },
                new Role() { Role_Id = 2, Name = "Admin" });
        }
    }
}
