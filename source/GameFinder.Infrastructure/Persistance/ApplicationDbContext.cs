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
        public DbSet<Address> Address { get; set; }
        public DbSet<Court> Court { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Game_Details> Game_Details { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Sport> Sport { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=DESKTOP-2UA5DVQ;Database=GameFinderDb;Trusted_Connection=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>()
                .HasData(
                new Role() { Role_Id = 1, Name = "Player" },
                new Role() { Role_Id = 2, Name = "Admin" });

            modelBuilder.Entity<Sport>()
                .HasData(
                new Sport { Sport_Id = 1, Name = "Soccer"},
                new Sport { Sport_Id = 2, Name = "Basketball"},
                new Sport { Sport_Id = 3, Name = "Volleyball"},
                new Sport { Sport_Id = 4, Name = "Tennis" });
        }
    }
}
