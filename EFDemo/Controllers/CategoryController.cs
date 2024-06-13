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
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _context; 

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> objList = _context.Categories.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            //create
            Category obj = new Category();
            if (id == null || id==0)
            {
                return View(obj);
            }
            //edit
            obj = _context.Categories.FirstOrDefault(u => u.CategoryId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.CategoryId == 0)
                {
                    await _context.Categories.AddAsync(obj);
                }
                else
                {
                    _context.Categories.Update(obj);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Category obj = new Category();
            obj = _context.Categories.FirstOrDefault(u => u.CategoryId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(obj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple2()
        {
            List<Category> Categories = new List<Category>();
            for(int i=0; i<2; i++)
            {
                Categories.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
            }
            _context.Categories.AddRange(Categories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple5()
        {
            List<Category> Categories = new List<Category>();
            for (int i = 0; i < 5; i++)
            {
                Categories.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
            }
            _context.Categories.AddRange(Categories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveMultiple2()
        {
            List<Category> categories = await _context.Categories.OrderByDescending(u => u.CategoryId).Take(2).ToListAsync(); 
            _context.Categories.RemoveRange(categories);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveMultiple5()
        {
            List<Category> categories = await _context.Categories.OrderByDescending(u => u.CategoryId).Take(5).ToListAsync();
            _context.Categories.RemoveRange(categories);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
