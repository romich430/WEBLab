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
    public class ShopRESTController : ControllerBase
    {
        public static List<Shop> shops = new List<Shop>();

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(shops);
        }
        [HttpPost]
        public IActionResult Post(Shop Shop)
        {
            if (shops.Find(e => e.id == Shop.id) != null)
            {
                return new JsonResult("error");
            }
            else
            {
                shops.Add(Shop);
                return new JsonResult("ok");
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (shops.Find(e => e.id == id) == null)
            {
                return new JsonResult("error");
            }
            else
            {
                shops.Remove(shops.Find(e => e.id == id));
                return new JsonResult("ok");
            }
        }

        [HttpPut]
        public IActionResult Put(Shop Shop)
        {
            if (shops.Find(e => e.id == Shop.id) == null)
            {
                return new JsonResult("error");
            }
            else
            {
                shops.Find(e => e.id == Shop.id).name = Shop.name;
                shops.Find(e => e.id == Shop.id).address = Shop.address;
                return new JsonResult("ok");
            }
        }
    }
}
