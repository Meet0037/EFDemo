using EFDataAccess.Data;
using EFModels.Models;
using EFModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDemo.Controllers
{
    public class BookController : Controller
    {

        private readonly ApplicationDbContext _context; 

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Book> objList = _context.Books.ToList();
            foreach (var obj in objList)
            {
                //obj.Publisher = _context.Publishers.Find(obj.Publisher_Id);

                //Avoid duplicate calls to the database for the same publisher id
                _context.Entry(obj).Reference(p => p.Publisher).Load();
            }
            return View(objList);
        }

        //upsert get action method
        public IActionResult Upsert(int? id)
        {
            //create
            BookVM obj = new BookVM();

            obj.PublisherList = _context.Publishers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            });

            if (id == null || id == 0)
            {
                return View(obj);
            }
            //edit
            obj.Book = _context.Books.FirstOrDefault(u => u.BookId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Book.BookId == 0)
                {
                    await _context.Books.AddAsync(obj.Book);
                }
                else
                {
                    _context.Books.Update(obj.Book);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            BookDetail obj = new();

            //edit

            obj = _context.BookDetails.Include(u => u.Book).FirstOrDefault(u => u.Book_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(BookDetail obj)
        {
            if (obj.BookDetail_Id == 0)
            {
                //create
                await _context.BookDetails.AddAsync(obj);
            }
            else
            {
                //update
                _context.BookDetails.Update(obj);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            Book obj = new Book();
            obj = _context.Books.FirstOrDefault(u => u.BookId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Books.Remove(obj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ManageAuthors(int id)
        {
            BookAuthorVM obj = new BookAuthorVM()
            {
                BookAuthorList = _context.BookAuthorMaps.Include(u => u.Author).Include(u => u.Book).Where(u => u.Book_Id == id).ToList(),
                BookAuthor = new BookAuthorMap() { Book_Id = id },
                Book = _context.Books.FirstOrDefault(u => u.BookId == id),
            };

            List<int> tempListOfAssignedAuthors = obj.BookAuthorList.Select(u => u.Author_Id).ToList();

            //Not in List
            //get all authors whos id is not in the tempListOfAssignedAuthors
            var tempList = _context.Authors.Where(u => !tempListOfAssignedAuthors.Contains(u.Author_Id)).ToList();
            obj.AuthorList = tempList.Select(i => new SelectListItem
            {
                Text = i.FullName,
                Value = i.Author_Id.ToString()
            });

            return View(obj);
        }

        [HttpPost]
        public IActionResult ManageAuthors(BookAuthorVM obj)
        {
            if (ModelState.IsValid)
            {
                if(obj.BookAuthor.Author_Id !=0 && obj.BookAuthor.Book_Id != 0)
                {
                    _context.BookAuthorMaps.Add(obj.BookAuthor);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction(nameof(ManageAuthors), new { @id = obj.BookAuthor.Book_Id });
        }

        [HttpPost]
        public IActionResult RemoveAuthors(int authorId, BookAuthorVM obj)
        {
            int bookId = obj.Book.BookId;
            BookAuthorMap bookAuthorMap = _context.BookAuthorMaps.FirstOrDefault(u => u.Author_Id == authorId && u.Book_Id == bookId);
            
            _context.BookAuthorMaps.Remove(bookAuthorMap);
            _context.SaveChanges();

            return RedirectToAction(nameof(ManageAuthors), new { @id = bookId });
        }
    }
}
