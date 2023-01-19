using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBLab0.Models
{
    public class Main
    {
        public List<Pen> pens { get; set; }
        public List<PenColors> penColors { get; set; }
        public List<PenTypes> penTypes { get; set; }
        public List<Shop> shops { get; set; }
        public List<PenShopRelation> rels { get; set; }
        public List<PenColors> shops_extended { get; set; }
        public Shop shop { get; set; }
        public Pen pen { get; set; }
        public IFormFile upload { get; set; }
        public int shop_id { get; set; }
        public PenShopRelation rel { get; set; }
        public int pen_id { get; set; }
    }
}
