using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KGSHOP.Data;
using KGSHOP.Models;
using KGSHOP.Models.ViewModel;
using KGSHOP.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KGSHOP.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.SuperAdminEndUser)]

    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public ShopViewModel ShopsVM { get; set; }
        public ShopController(ApplicationDbContext db)
        {
            _db = db;
            ShopsVM = new ShopViewModel
            {
                Provinces = _db.Provinces.ToList(),
                Shops = new Shop()
            };
        }
        public async Task<IActionResult> Index()
        {
            var shops = _db.Shops.Include(m => m.Provinces);
            return View(await shops.ToListAsync());
        }
        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(ShopsVM);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(ShopsVM);
            }

            _db.Shops.Add(ShopsVM.Shops);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //Edit
        //GET Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShopsVM.Shops = await _db.Shops.FindAsync(id);
            if (ShopsVM.Shops == null)
            {
                return NotFound();
            }

            return View(ShopsVM);
        }
        //POST EDIT
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost()
        {
            if (ModelState.IsValid)
            {
                _db.Update(ShopsVM.Shops);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ShopsVM);
        }
        //Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ShopsVM.Shops = await _db.Shops.FindAsync(id);
            if (ShopsVM == null)
            {
                return NotFound();
            }
            return View(ShopsVM);
        }
        //Get Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShopsVM.Shops = await _db.Shops.FindAsync(id);
            if (ShopsVM.Shops == null)
            {
                return NotFound();
            }

            return View(ShopsVM);
        }
        //POST Delete action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            ShopsVM.Shops = await _db.Shops.FindAsync(id);
            _db.Shops.Remove(ShopsVM.Shops);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}