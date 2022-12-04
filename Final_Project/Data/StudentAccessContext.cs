using Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Data
{
    public class StudentAccessContext : DbContext
    {
        public StudentAccessContext(DbContextOptions<StudentAccessContext> options) : base(options) { }

        //Pratik Chaudhari
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>().HasData(
                new Student { Id = 1, fullName = "Pratik Chaudhari", birthDate = "09-02-2002", programName = "Information Technology", programYear = "2025" }
                );
        }

        //Pratik Chaudhari
        public DbSet<Student> Student { get; set; }
    }
}
