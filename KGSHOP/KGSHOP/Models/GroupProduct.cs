using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KGSHOP.Models
{
    public class GroupProduct
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProductGroup_ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
    }
}
