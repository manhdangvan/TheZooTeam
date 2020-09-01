using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KGSHOP.Data;
using KGSHOP.Models;
using KGSHOP.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KGSHOP.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.SuperAdminEndUser)]

    public class GroupProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GroupProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.GroupProducts.ToList());
        }
        //Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroupProduct Gproduct)
        {
            if (ModelState.IsValid)
            {
                _db.Add(Gproduct);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Gproduct);
        }
        //GET Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupproduct = await _db.GroupProducts.FindAsync(id);
            if (groupproduct == null)
            {
                return NotFound();
            }

            return View(groupproduct);
        }
        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GroupProduct groupproduct)
        {
            if (id != groupproduct.ProductGroup_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(groupproduct);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupproduct);
        }
        //Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var groupProduct = await _db.GroupProducts.FindAsync(id);
            if (groupProduct == null)
            {
                return NotFound();
            }
            return View(groupProduct);
        }
        //Get Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupproduct = await _db.GroupProducts.FindAsync(id);
            if (groupproduct == null)
            {
                return NotFound();
            }

            return View(groupproduct);
        }
        //POST Delete action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var groupProduct = await _db.GroupProducts.FindAsync(id);
            _db.GroupProducts.Remove(groupProduct);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}