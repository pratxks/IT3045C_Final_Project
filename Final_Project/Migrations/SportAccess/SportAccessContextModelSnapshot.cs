﻿// <auto-generated />
using Final_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Final_Project.Migrations.SportAccess
{
    [DbContext(typeof(SportAccessContext))]
    partial class SportAccessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Final_Project.Models.Sport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("favoritePlayer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("favoriteSport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("favoriteTeam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SportRecords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            favoritePlayer = "Virat Kohli",
                            favoriteSport = "Cricket",
                            favoriteTeam = "India",
                            fullName = "Pratik Chaudhari"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
