﻿// <auto-generated />
using EFDataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFDataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240608122748_seedBookTable")]
    partial class seedBookTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFModels.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 5)
                        .HasColumnType("decimal(10,5)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            ISBN = "123456789",
                            Price = 10.5m,
                            Title = "Book 1"
                        },
                        new
                        {
                            BookId = 2,
                            ISBN = "987654321",
                            Price = 20.5m,
                            Title = "Book 2"
                        },
                        new
                        {
                            BookId = 3,
                            ISBN = "123456789",
                            Price = 30.5m,
                            Title = "Book 3"
                        },
                        new
                        {
                            BookId = 4,
                            ISBN = "987654321",
                            Price = 40.5m,
                            Title = "Book 4"
                        },
                        new
                        {
                            BookId = 5,
                            ISBN = "123456789",
                            Price = 50.5m,
                            Title = "Book 5"
                        });
                });

            modelBuilder.Entity("EFModels.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}