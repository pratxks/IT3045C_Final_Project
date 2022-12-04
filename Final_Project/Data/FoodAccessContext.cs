using Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Data
{
    public class FoodAccessContext : DbContext
    {
        public FoodAccessContext(DbContextOptions<FoodAccessContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Food>().HasData(
                new Food { Id = 1, fullName = "Pratik Chaudhari", favoriteBreakfast = "Sandwitch", favoriteLunch = "Pizza", favoriteDinner = "Burger" }
                );
        }

        public DbSet<Food> FoodRecords { get; set; }
    }
}
