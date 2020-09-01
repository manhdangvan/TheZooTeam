using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KGSHOP.Models.ViewModel
{
    public class AppointmentViewModel
    {
        public List<CustomerBuy> CustomerBuys { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
