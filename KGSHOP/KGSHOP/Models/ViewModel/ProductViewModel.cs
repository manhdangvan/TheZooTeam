using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KGSHOP.Models.ViewModel
{
    public class ProductViewModel
    {
        public Product Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public IEnumerable<GroupProduct> GroupProducts { get; set; }
    }
}
