using EFDataAccess.Data;
using EFModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDemo.Controllers
{
    public class AuthorController : Controller
    {

        private readonly ApplicationDbContext _context; 

        public AuthorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Author> objList = _context.Authors.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Author obj = new Author();
            if (id == null || id == 0)
            {
                return View(obj);
            }
            //edit
            obj = _context.Authors.FirstOrDefault(u => u.Author_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Author obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Author_Id == 0)
                {
                    await _context.Authors.AddAsync(obj);
                }
                else
                {
                    _context.Authors.Update(obj);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Author obj = new Author();
            obj = _context.Authors.FirstOrDefault(u => u.Author_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Authors.Remove(obj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
