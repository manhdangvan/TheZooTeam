using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KGSHOP.Models
{
    public class Support
    {
        [Key]
        public int ID { get; set; }
        public string Content { get; set; }
        public string Reply { get; set; }
    }
}
