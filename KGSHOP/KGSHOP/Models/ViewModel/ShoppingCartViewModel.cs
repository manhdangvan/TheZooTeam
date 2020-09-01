using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KGSHOP.Models.ViewModel
{
    public class ShoppingCartViewModel
    {
        public List<Product> Products { get; set; }
        public CustomerBuy CustomerBuys { get; set; }
    }
}
