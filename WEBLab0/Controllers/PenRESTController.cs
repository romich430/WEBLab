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
    public class PenRESTController : ControllerBase
    {
        public static List<Pen> pens = new List<Pen>();
        public static List<PenColors> pc0 = new List<PenColors>();
        public static List<PenTypes> pt0 = new List<PenTypes>();
        
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(pens);
        }
        [HttpPost]
        public IActionResult Post(Pen pen)
        {
            pc0 = PenColorRESTController.pc;
            pt0 = PenTypeRESTController.pt;
            if ((pens.Find(e => e.id == pen.id) != null )
                ||( pc0.Find(e=>e.id==pen.id_pen_color)==null)
                || (pt0.Find(e => e.id == pen.id_pen_type) == null)
                )
            {
                return new JsonResult("error");
            }
            else
            {
                pens.Add(pen);
                return new JsonResult("ok");
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (pens.Find(e => e.id == id) == null)
            {
                return new JsonResult("error");
            }
            else
            {
                pens.Remove(pens.Find(e=>e.id==id));
                return new JsonResult("ok");
            }
        }

        [HttpPut]
        public IActionResult Put(Pen pen)
        {
            pc0 = PenColorRESTController.pc;
            pt0 = PenTypeRESTController.pt;
            if (pens.Find(e => e.id == pen.id) == null
                ||( pc0.Find(e=>e.id==pen.id_pen_color)==null)
                || (pt0.Find(e => e.id == pen.id_pen_type) == null)
                )
            {
                return new JsonResult("error");
            }
            else
            {
                pens.Find(e => e.id == pen.id).id_pen_color=pen.id_pen_color;
                pens.Find(e => e.id == pen.id).id_pen_type = pen.id_pen_type;
                pens.Find(e => e.id == pen.id).name = pen.name;
                pens.Find(e => e.id == pen.id).description = pen.description;
                pens.Find(e => e.id == pen.id).photo_location = pen.photo_location;
                return new JsonResult("ok");
            }
        }
    }
}
