using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBLab0.Models
{
    public class PenShopRelation
    {
        public int id { get; set; }
        public int id_pen { get; set; }
        public int id_shop { get; set; }
        public int pen_number { get; set; }
        public double price { get; set; }
    }
}
