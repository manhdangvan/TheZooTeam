using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KGSHOP.Models
{
    public class Province
    {
        [Key]
        public int Province_ID { get; set; }
        public string Name { get; set; }
    }
}
