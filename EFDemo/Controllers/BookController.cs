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
    }
}
