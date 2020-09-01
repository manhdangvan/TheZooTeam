using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
    [Authorize(Roles=SD.AdminEndUser+","+SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class CustomerBuyController : Controller
    {
        private readonly ApplicationDbContext _db;
        private int PageSize = 3;

        public CustomerBuyController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int productPage = 1, string searchName = null, string searchEmail = null, string searchPhone = null, string searchDate = null)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            AppointmentViewModel appointmentVM = new AppointmentViewModel()
            {
                CustomerBuys = new List<Models.CustomerBuy>()
            };

            StringBuilder param = new StringBuilder();

            param.Append("/Admin/CustomerBuy?productPage=:");
            param.Append("&searchName=");
            if (searchName != null)
            {
                param.Append(searchName);
            }
            param.Append("&searchEmail=");
            if (searchEmail != null)
            {
                param.Append(searchEmail);
            }
            param.Append("&searchPhone=");
            if (searchPhone != null)
            {
                param.Append(searchPhone);
            }
            param.Append("&searchDate=");
            if (searchDate != null)
            {
                param.Append(searchDate);
            }

            appointmentVM.CustomerBuys = _db.CustomerBuys.Include(a => a.SalesPerson).ToList();
            if (User.IsInRole(SD.AdminEndUser))
            {
                appointmentVM.CustomerBuys = appointmentVM.CustomerBuys.Where(a => a.SalesPersonId == claim.Value).ToList();
            }


            if (searchName != null)
            {
                appointmentVM.CustomerBuys = appointmentVM.CustomerBuys.Where(a => a.CustomerName.ToLower().Contains(searchName.ToLower())).ToList();
            }
            if (searchEmail != null)
            {
                appointmentVM.CustomerBuys = appointmentVM.CustomerBuys.Where(a => a.CustomerEmail.ToLower().Contains(searchEmail.ToLower())).ToList();
            }
            if (searchPhone != null)
            {
                appointmentVM.CustomerBuys = appointmentVM.CustomerBuys.Where(a => a.CustomerPhoneNumber.ToLower().Contains(searchPhone.ToLower())).ToList();
            }
            if (searchDate != null)
            {
                try
                {
                    DateTime appDate = Convert.ToDateTime(searchDate);
                    appointmentVM.CustomerBuys = appointmentVM.CustomerBuys.Where(a => a.AppointmentDate.ToShortDateString().Equals(appDate.ToShortDateString())).ToList();
                }
                catch (Exception ex)
                {

                }

            }

            var count = appointmentVM.CustomerBuys.Count;

            appointmentVM.CustomerBuys = appointmentVM.CustomerBuys.OrderBy(p => p.AppointmentDate)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize).ToList();


            appointmentVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = count,
                urlParam = param.ToString()
            };


            return View(appointmentVM);
        }
        //GET Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productList = (IEnumerable<Product>)(from p in _db.Products
                                                      join a in _db.PSA
                                                      on p.ID equals a.ProductId
                                                      where a.CustomerID == id
                                                      select p).Include("GroupProducts");

            AppointmentDetailsViewModel objAppointmentVM = new AppointmentDetailsViewModel()
            {
                CustomerBuys = _db.CustomerBuys.Include(a => a.SalesPerson).Where(a => a.Id == id).FirstOrDefault(),
                SalesPerson = _db.ApplicationUsers.ToList(),
                Products = productList.ToList()
            };

            return View(objAppointmentVM);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AppointmentDetailsViewModel objAppointmentVM)
        {
            if (ModelState.IsValid)
            {
                objAppointmentVM.CustomerBuys.AppointmentDate = objAppointmentVM.CustomerBuys.AppointmentDate
                                    .AddHours(objAppointmentVM.CustomerBuys.AppointmentTime.Hour)
                                    .AddMinutes(objAppointmentVM.CustomerBuys.AppointmentTime.Minute);

                var appointmentFromDb = _db.CustomerBuys.Where(a => a.Id == objAppointmentVM.CustomerBuys.Id).FirstOrDefault();

                appointmentFromDb.CustomerName = objAppointmentVM.CustomerBuys.CustomerName;
                appointmentFromDb.CustomerEmail = objAppointmentVM.CustomerBuys.CustomerEmail;
                appointmentFromDb.CustomerPhoneNumber = objAppointmentVM.CustomerBuys.CustomerPhoneNumber;
                appointmentFromDb.AppointmentDate = objAppointmentVM.CustomerBuys.AppointmentDate;
                appointmentFromDb.isConfirmed = objAppointmentVM.CustomerBuys.isConfirmed;
                if (User.IsInRole(SD.SuperAdminEndUser))
                {
                    appointmentFromDb.SalesPersonId = objAppointmentVM.CustomerBuys.SalesPersonId;
                }
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));


            }

            return View(objAppointmentVM);
        }
        //GET Detials
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productList = (IEnumerable<Product>)(from p in _db.Products
                                                      join a in _db.PSA
                                                      on p.ID equals a.ProductId
                                                      where a.CustomerID == id
                                                      select p).Include("GroupProducts");

            AppointmentDetailsViewModel objAppointmentVM = new AppointmentDetailsViewModel()
            {
                CustomerBuys = _db.CustomerBuys.Include(a => a.SalesPerson).Where(a => a.Id == id).FirstOrDefault(),
                SalesPerson = _db.ApplicationUsers.ToList(),
                Products = productList.ToList()
            };

            return View(objAppointmentVM);

        }
        //GET Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productList = (IEnumerable<Product>)(from p in _db.Products
                                                      join a in _db.PSA
                                                      on p.ID equals a.ProductId
                                                      where a.CustomerID == id
                                                      select p).Include("GroupProducts");

            AppointmentDetailsViewModel objAppointmentVM = new AppointmentDetailsViewModel()
            {
                CustomerBuys = _db.CustomerBuys.Include(a => a.SalesPerson).Where(a => a.Id == id).FirstOrDefault(),
                SalesPerson = _db.ApplicationUsers.ToList(),
                Products = productList.ToList()
            };

            return View(objAppointmentVM);

        }


        //POST Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _db.CustomerBuys.FindAsync(id);
            _db.CustomerBuys.Remove(appointment);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}