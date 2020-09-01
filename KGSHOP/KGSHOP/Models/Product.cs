using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KGSHOP.Models
{
    public class Product
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Detail { get; set; }
        public float Price { get; set; }
        public float PriceNew { get; set; }
     //   [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int Order { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        [Display(Name = "Product Group")]
        public int ProductGroup_ID { get; set; }
        [ForeignKey("ProductGroup_ID")]
        public virtual GroupProduct GroupProducts { get; set; }
    }
}
