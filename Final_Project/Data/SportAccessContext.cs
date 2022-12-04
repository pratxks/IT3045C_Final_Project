using Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Data
{
    public class SportAccessContext : DbContext
    {
        public SportAccessContext(DbContextOptions<SportAccessContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Sport>().HasData(
                new Sport { Id = 1, fullName = "Pratik Chaudhari", favoriteSport = "Cricket", favoriteTeam = "India", favoritePlayer = "Virat Kohli" }
                );
        }

        public DbSet<Sport> SportRecords { get; set; }
    }
}
