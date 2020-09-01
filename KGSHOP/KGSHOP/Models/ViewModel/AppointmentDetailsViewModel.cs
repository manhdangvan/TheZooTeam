using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KGSHOP.Models.ViewModel
{
    public class AppointmentDetailsViewModel
    {
        public CustomerBuy CustomerBuys { get; set; }
        public List<ApplicationUser> SalesPerson { get; set; }
        public List<Product> Products { get; set; }
    }
}
