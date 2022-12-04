using Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Data
{
    public class HobbyAccessContext : DbContext
    {
        public HobbyAccessContext(DbContextOptions<HobbyAccessContext> options) : base(options) { }

        //Pratik Chaudhari
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Hobby>().HasData(
                new Hobby { Id = 1, fullName = "Pratik Chaudhari", hobby = "Swimming", favoriteVideoGame = "Call of Duty", favoriteBoardGame = "Chess" }
                );
        }

        //Pratik Chaudhari
        public DbSet<Hobby> HobbyRecords { get; set; }
    }
}
