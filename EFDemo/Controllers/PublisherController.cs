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
    public class PublisherController : Controller
    {

        private readonly ApplicationDbContext _context; 

        public PublisherController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Publisher> objList = _context.Publishers.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            //create
            Publisher obj = new Publisher();
            if (id == null || id==0)
            {
                return View(obj);
            }
            //edit
            obj = _context.Publishers.FirstOrDefault(u => u.Publisher_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Publisher obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Publisher_Id == 0)
                {
                    await _context.Publishers.AddAsync(obj);
                }
                else
                {
                    _context.Publishers.Update(obj);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Publisher obj = new Publisher();
            obj = _context.Publishers.FirstOrDefault(u => u.Publisher_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Publishers.Remove(obj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
