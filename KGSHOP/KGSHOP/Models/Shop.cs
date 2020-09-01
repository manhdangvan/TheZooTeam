using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KGSHOP.Models
{
    public class Shop
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        [Display(Name = "Province")]
        public int Province_ID { get; set; }
        [ForeignKey("Province_ID")]
        public virtual Province Provinces { get; set; }
    }
}
