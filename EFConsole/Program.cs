//// See https://aka.ms/new-console-template for more information
//using EFDataAccess.Data;
//using EFModels.Models;
//using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

////using(ApplicationDbContext context = new())
////{
////    context.Database.EnsureCreated();
////    if(context.Database.GetPendingMigrations().Count() > 0) 
////    {
////        context.Database.Migrate();
////    }
////}

////Add new books in the books table
////AddBooks();

////void AddBooks()
////{
////    using (ApplicationDbContext context = new())
////    {
////        context.Books.Add(new Book { Title = "Add book 1", ISBN = "123456789", Price = 10.5m, Publisher_Id = 1 });
////        context.Books.Add(new Book { Title = "Add book 2", ISBN = "123456789", Price = 10.5m, Publisher_Id = 1 });
////        context.SaveChanges();
////    }
////}

////Get data from books table
//GetAllBooks();

//void GetAllBooks()
//{
//    using (ApplicationDbContext context = new())
//    {
//        var books = context.Books.ToList();
//        foreach (var book in books)
//        {
//            Console.WriteLine($"BookId: {book.BookId}, Title: {book.Title}, Price: {book.Price}");
//        }
//    }
//}

////Get the first book from the books table
//GetFirstBook();

//void GetFirstBook()
//{
//    using (ApplicationDbContext context = new())
//    {
//        var books = context.Books.Where(b => b.Publisher_Id == 1);
//        foreach(var book in books)
//        {
//            Console.WriteLine($"BookId: {book.BookId}, Title: {book.Title}, Price: {book.Price}");
//        }
//    }
//}

//DeleteBook();

////method to delete a book
//void DeleteBook()
//{
//    using (ApplicationDbContext context = new())
//    {
//        var book = context.Books.Find(7);
//        context.Books.Remove(book);
//        context.SaveChanges();
//    }
//}

