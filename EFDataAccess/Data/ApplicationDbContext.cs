using EFModels.FluentModels;
using EFModels.Models;
using EFModels.Models.FluentModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<BookDetail> BookDetails { get; set; }

        //rename to Fluent_BookDetail
        public DbSet<Fluent_BookDetail> BookDetail_fluent { get; set; }

        public DbSet<Fluent_Book> Fluent_Books { get; set; }

        public DbSet<Fluent_Author> Fluent_Authors { get; set; }

        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=EFCoreDB;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //use Fluent API for data annotation in FLuent_BookDetail
            modelBuilder.Entity<Fluent_BookDetail>().ToTable("Fluent_BookDetails");
            modelBuilder.Entity<Fluent_BookDetail>().Property(bd => bd.NumberOfChapters).HasColumnName("NoOfChapters");
            modelBuilder.Entity<Fluent_BookDetail>().HasKey(bd => bd.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>().Property(bd => bd.NumberOfChapters).IsRequired();
            modelBuilder.Entity<Fluent_BookDetail>().HasOne(bd => bd.Book).WithOne(b => b.BookDetail).HasForeignKey<Fluent_BookDetail>(bd => bd.Book_Id);

            //use Fluent API for data annotation in FLuent_Book
            modelBuilder.Entity<Fluent_Book>().Property(b => b.ISBN).HasMaxLength(50);
            modelBuilder.Entity<Fluent_Book>().HasKey(b => b.BookId);
            modelBuilder.Entity<Fluent_Book>().Property(b => b.ISBN).IsRequired();
            modelBuilder.Entity<Fluent_Book>().Ignore(b => b.PriceRange);

            //use Fluent API for data annotation in FLuent_Author
            modelBuilder.Entity<Fluent_Author>().HasKey(a => a.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(a => a.FirstName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(a => a.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Fluent_Author>().Property(a => a.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(a => a.FullName);

            //use Fluent API for data annotation in FLuent_Publisher
            modelBuilder.Entity<Fluent_Publisher>().HasKey(p => p.Publisher_Id);
            modelBuilder.Entity<Fluent_Publisher>().Property(p => p.Name).IsRequired();



            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);

            modelBuilder.Entity<BookAuthorMap>().HasKey(ba => new { ba.Book_Id, ba.Author_Id });

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "Book 1",
                    ISBN = "123456789",
                    Price = 10.5m,
                    Publisher_Id = 1
                },
                new Book
                {
                    BookId = 2,
                    Title = "Book 2",
                    ISBN = "987654321",
                    Price = 20.5m,
                    Publisher_Id = 2
                }
                );

            var bookList = new Book[]
            {
                new Book
                {
                    BookId = 3,
                    Title = "Book 3",
                    ISBN = "123456789",
                    Price = 30.5m,
                    Publisher_Id = 2
                },
                new Book
                {
                    BookId = 4,
                    Title = "Book 4",
                    ISBN = "987654321",
                    Price = 40.5m,
                    Publisher_Id = 3
                },
                new Book
                {
                    BookId = 5,
                    Title = "Book 5",
                    ISBN = "123456789",
                    Price = 50.5m,
                    Publisher_Id = 3
                }
            };
            modelBuilder.Entity<Book>().HasData(bookList);


            modelBuilder.Entity<Publisher>().HasData(
                new Publisher
                {
                    Publisher_Id = 1,
                    Name = "Publisher 1",
                    Location = "Location 1"
                },
                new Publisher
                {
                    Publisher_Id = 2,
                    Name = "Publisher 2",
                    Location = "Location 2"
                },
                new Publisher
                {
                    Publisher_Id = 3,
                    Name = "Publisher 3",
                    Location = "Location 3"
                }
            );
        }
    }
}
