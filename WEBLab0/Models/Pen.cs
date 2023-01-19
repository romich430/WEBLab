using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEBLab0.Models
{
    public class Pen
    {
        public int id { get; set; }
        public string photo_location { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [Display(Name ="Color")]
        public int id_pen_color { get; set; }
        [Required]
        [Display(Name = "Type")]
        public int id_pen_type { get; set; }

        public string description { get; set; }
    }
}
