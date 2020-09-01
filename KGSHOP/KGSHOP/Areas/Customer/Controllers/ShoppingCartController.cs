using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KGSHOP.Data;
using KGSHOP.Extensions;
using KGSHOP.Models;
using KGSHOP.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KGSHOP.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ShoppingCartViewModel ShoppingCartVM { get; set; }

        public ShoppingCartController(ApplicationDbContext db)
        {
            _db = db;
            ShoppingCartVM = new ShoppingCartViewModel()
            {
                Products = new List<Models.Product>()
            };
        }
        public IActionResult Vieww()
        {
            return View();
        }
        //Get Index Shopping Cart
        public async Task<IActionResult> Index()
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (lstShoppingCart != null)
            {
                foreach (int cartItem in lstShoppingCart)
                {
                    Product prod = _db.Products.Include(p => p.GroupProducts).Where(p => p.ID == cartItem).FirstOrDefault();
                    ShoppingCartVM.Products.Add(prod);
                }
            }
            return View(ShoppingCartVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");

            ShoppingCartVM.CustomerBuys.AppointmentDate = ShoppingCartVM.CustomerBuys.AppointmentDate
                                                            .AddHours(ShoppingCartVM.CustomerBuys.AppointmentTime.Hour)
                                                            .AddMinutes(ShoppingCartVM.CustomerBuys.AppointmentTime.Minute);
            CustomerBuy customers = ShoppingCartVM.CustomerBuys;
            _db.CustomerBuys.Add(customers);
            _db.SaveChanges();
            

            int customerId = customers.Id;

            foreach (int productId in lstCartItems)
            {
                ProductsSelectedForAppointment productsSelectedForAppointment = new ProductsSelectedForAppointment()
                {
                    CustomerID = customerId,
                    ProductId = productId
                };
                _db.PSA.Add(productsSelectedForAppointment);
                
            }
            _db.SaveChanges();
            lstCartItems = new List<int>();
            HttpContext.Session.Set("ssShoppingCart", lstCartItems);
            return RedirectToAction("AppointmentConfirmation", "ShoppingCart", new { Id = customerId });

        }
        public IActionResult Remove(int id)
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");

            if (lstCartItems.Count > 0)
            {
                if (lstCartItems.Contains(id))
                {
                    lstCartItems.Remove(id);
                }
            }

            HttpContext.Session.Set("ssShoppingCart", lstCartItems);

            return RedirectToAction(nameof(Index));
        }
        //Get
        public IActionResult AppointmentConfirmation(int id)
        {
            ShoppingCartVM.CustomerBuys = _db.CustomerBuys.Where(a => a.Id == id).FirstOrDefault();
            List<ProductsSelectedForAppointment> objProdList = _db.PSA.Where(p => p.CustomerID == id).ToList();

            foreach (ProductsSelectedForAppointment prodAptObj in objProdList)
            {
                ShoppingCartVM.Products.Add(_db.Products.Include(p => p.GroupProducts).Where(p => p.ID == prodAptObj.ProductId).FirstOrDefault());
            }

            return View(ShoppingCartVM);
        }
    }
}