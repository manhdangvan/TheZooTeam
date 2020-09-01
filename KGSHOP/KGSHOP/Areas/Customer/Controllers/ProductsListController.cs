using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KGSHOP.Data;
using KGSHOP.Models;
using KGSHOP.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KGSHOP.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductsListController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductsListViewModel ProductsListVM { get; set; }

        private int PageSize = 3;

        public ProductsListController(ApplicationDbContext db)
        {
            _db = db;
            ProductsListVM = new ProductsListViewModel()
            {
                Products = new List<Product>(),
                GroupProducts = _db.GroupProducts.ToList(),
            };
        }

        public async Task<IActionResult> Index(int productPage = 1, string searchName = null, string groupProductsSelected = "Default")
        {
            ProductsListVM.Products = await _db.Products.Include(m => m.GroupProducts).ToListAsync();

            StringBuilder param = new StringBuilder();
            param.Append("/Customer/ProductsList?productPage=:");

            if (searchName != null)
            {
                param.Append("&searchName=");
                param.Append(searchName);
            }

            if (searchName != null)
            {
                ProductsListVM.Products = ProductsListVM.Products.Where(p => p.Name.ToLower().Trim().Contains(searchName.ToLower().Trim())).ToList();
            }

            var count = ProductsListVM.Products.Count();

            ProductsListVM.Products = ProductsListVM.Products.OrderBy(p => p.Date)
                .Skip((productPage - 1) * PageSize).Take(PageSize).ToList();

            if (!groupProductsSelected.Equals("Default"))
            {
                ProductsListVM.Products = ProductsListVM.Products.OrderBy(p => p.Date)
                .Skip((productPage - 1) * PageSize).Take(PageSize).Where(m => m.GroupProducts.Name.Equals(groupProductsSelected)).ToList();
            }

            ProductsListVM.PagingInfo = new PagingInfo()
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = count,
                urlParam = param.ToString()
            };

            return View(ProductsListVM);
        }
    }
}