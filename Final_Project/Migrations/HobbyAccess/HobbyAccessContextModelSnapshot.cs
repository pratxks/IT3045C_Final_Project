﻿// <auto-generated />
using Final_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Final_Project.Migrations.HobbyAccess
{
    //AutoAdded by Add-Migration command - Pratik Chaudhari
    [DbContext(typeof(HobbyAccessContext))]
    partial class HobbyAccessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Final_Project.Models.Hobby", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("favoriteBoardGame")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("favoriteVideoGame")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hobby")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HobbyRecords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            favoriteBoardGame = "Chess",
                            favoriteVideoGame = "Call of Duty",
                            fullName = "Pratik Chaudhari",
                            hobby = "Swimming"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
