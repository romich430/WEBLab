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
    public class PenTypeRESTController : ControllerBase
    {
        public static List<PenTypes> pt = new List<PenTypes>();
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(pt);
        }
        [HttpPost]
        public IActionResult Post(PenTypes pen)
        {
            if (pt.Find(e => e.id == pen.id) != null)
            {
                return new JsonResult("error");
            }
            else
            {
                pt.Add(pen);
                return new JsonResult("ok");
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (pt.Find(e => e.id == id) == null)
            {
                return new JsonResult("error");
            }
            else
            {
                pt.Remove(pt.Find(e => e.id == id));
                return new JsonResult("ok");
            }
        }

        [HttpPut]
        public IActionResult Put(PenTypes pen)
        {
            if (pt.Find(e => e.id == pen.id) == null)
            {
                return new JsonResult("error");
            }
            else
            {
                pt.Find(e => e.id == pen.id).name = pen.name;

                return new JsonResult("ok");
            }
        }
    }
}
