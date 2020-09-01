using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KGSHOP.Data;
using KGSHOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace KGSHOP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupportController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SupportController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Supports.ToList());
        }
        //Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Support sp)
        {
            if (ModelState.IsValid)
            {
                _db.Add(sp);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sp);
        }
        //GET Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sp = await _db.Supports.FindAsync(id);
            if (sp == null)
            {
                return NotFound();
            }

            return View(sp);
        }
        //POST EDIT
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostEdit(int id, Support sp)
        {
            if (id != sp.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var support = _db.Supports.Where(m => m.ID == id).FirstOrDefault();
                support.Reply = sp.Reply;
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sp);
        }
        //Get Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sp = await _db.Supports.FindAsync(id);
            if (sp == null)
            {
                return NotFound();
            }

            return View(sp);
        }
        //POST Delete action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var sp = await _db.Supports.FindAsync(id);
            _db.Supports.Remove(sp);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}