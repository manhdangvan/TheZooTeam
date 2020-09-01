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

    public class ProvinceController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProvinceController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Provinces.ToList());
        }
        //Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Province province)
        {
            if (ModelState.IsValid)
            {
                _db.Add(province);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(province);
        }
        //GET Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var province = await _db.Provinces.FindAsync(id);
            if (province == null)
            {
                return NotFound();
            }

            return View(province);
        }
        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Province province)
        {
            if (id != province.Province_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(province);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(province);
        }
        //Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var province = await _db.Provinces.FindAsync(id);
            if (province == null)
            {
                return NotFound();
            }
            return View(province);
        }
        //Get Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var province = await _db.Provinces.FindAsync(id);
            if (province == null)
            {
                return NotFound();
            }

            return View(province);
        }
        //POST Delete action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var province = await _db.Provinces.FindAsync(id);
            _db.Provinces.Remove(province);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}