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
    public class PenColorRESTController : ControllerBase
    {
        public static List<PenColors> pc = new List<PenColors>();
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(pc);
        }
        [HttpPost]
        public IActionResult Post(PenColors pen)
        {
            if (pc.Find(e => e.id == pen.id) != null)
            {
                return new JsonResult("error");
            }
            else
            {
                pc.Add(pen);
                return new JsonResult("ok");
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (pc.Find(e => e.id == id) == null)
            {
                return new JsonResult("error");
            }
            else
            {
                pc.Remove(pc.Find(e => e.id == id));
                return new JsonResult("ok");
            }
        }

        [HttpPut]
        public IActionResult Put(PenColors pen)
        {
            if (pc.Find(e => e.id == pen.id) == null)
            {
                return new JsonResult("error");
            }
            else
            {
                pc.Find(e => e.id == pen.id).name = pen.name;
                
                return new JsonResult("ok");
            }
        }
    }
}
