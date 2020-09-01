using System;
using System.Collections.Generic;
using System.Text;
using KGSHOP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KGSHOP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext() : base() { }
        public DbSet<Product> Products { get; set; }
        public DbSet<GroupProduct> GroupProducts { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<CustomerBuy> CustomerBuys { get; set; }
        public DbSet<ProductsSelectedForAppointment> PSA { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Support> Supports { get; set; }

    }
}
