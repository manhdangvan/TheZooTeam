using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KGSHOP.Models.ViewModel
{
    public class ShopViewModel
    {
        public Shop Shops { get; set; }
        public IEnumerable<Province> Provinces { get; set; }
    }
}
