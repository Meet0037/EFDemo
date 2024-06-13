using EFModels.Models;
using EFModels.Models.FluentModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFDataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<BookDetail> BookDetails { get; set; }

        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }

        //rename to Fluent_BookDetail
        public DbSet<Fluent_BookDetail> BookDetail_fluent { get; set; }

        public DbSet<Fluent_Book> Fluent_Books { get; set; }

        public DbSet<Fluent_Author> Fluent_Authors { get; set; }

        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }

        public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMaps { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=EFCoreDB;TrustServerCertificate=True;Trusted_Connection=True;")
            //    .LogTo(System.Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<BookAuthorMap>().HasKey(ba => new { ba.Book_Id, ba.Author_Id });

            modelBuilder.ApplyConfiguration(new FluentConfig.FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentConfig.FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentConfig.FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentConfig.FluentPublisherConfig());
            modelBuilder.ApplyConfiguration(new FluentConfig.FluentBookAuthorMapConfig());


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
