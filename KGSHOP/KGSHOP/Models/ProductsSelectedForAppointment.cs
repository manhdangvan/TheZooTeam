using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KGSHOP.Models
{
    public class ProductsSelectedForAppointment
    {
        public int Id { get; set; }

        public int CustomerID { get; set; }

        [ForeignKey("AppointmentId")]
        public virtual CustomerBuy Customers { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Products { get; set; }
    }
}
