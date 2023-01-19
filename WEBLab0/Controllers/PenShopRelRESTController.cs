using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBLab0.Models;

namespace WEBLab0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenShopRelRESTController : ControllerBase
    {
        public static List<PenShopRelation> rels = new List<PenShopRelation>();
        public static List<Pen> pens0 = new List<Pen>();
        public static List<Shop> shops0 = new List<Shop>();

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(rels);
        }
        [HttpPost]
        public IActionResult Post(PenShopRelation penShopRelation)
        {
            pens0 = PenRESTController.pens;
            shops0 = ShopRESTController.shops;
            if ((rels.Find(e => e.id == penShopRelation.id) != null)
                ||( pens0.Find(e=>e.id==penShopRelation.id_pen)==null)
                || (shops0.Find(e => e.id == penShopRelation.id_shop) == null)
                )
            {
                return new JsonResult("error");
            }
            else
            {
                rels.Add(penShopRelation);
                return new JsonResult("ok");
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (rels.Find(e => e.id == id) == null)
            {
                return new JsonResult("error");
            }
            else
            {
                rels.Remove(rels.Find(e => e.id == id));
                return new JsonResult("ok");
            }
        }

        [HttpPut]
        public IActionResult Put(PenShopRelation penShopRelation)
        {
            pens0 = PenRESTController.pens;
            shops0 = ShopRESTController.shops;
            if ((rels.Find(e => e.id == penShopRelation.id) == null)
                || (pens0.Find(e => e.id == penShopRelation.id_pen) == null)
                || (shops0.Find(e => e.id == penShopRelation.id_shop) == null)
                )
            {
                return new JsonResult("error");
            }
            else
            {
                rels.Find(e => e.id == penShopRelation.id).id_pen = penShopRelation.id_pen;
                rels.Find(e => e.id == penShopRelation.id).id_shop=penShopRelation.id_shop;
                rels.Find(e => e.id == penShopRelation.id).price = penShopRelation.price;
                rels.Find(e => e.id == penShopRelation.id).pen_number = penShopRelation.pen_number;
                return new JsonResult("ok");
            }
        }
    }
}
