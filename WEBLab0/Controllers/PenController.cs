using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBLab0.Models;
using System.Web;
using System.IO;
using WEBLab0.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;

namespace WEBLab0.Controllers
{
    public class PenController : Controller
    {
        public PenController(IWebHostEnvironment env)
        {
            _env = env;
        }
        private readonly IWebHostEnvironment _env;
        public static List<Pen> pens = new List<Pen>();
        public static Main main = new Main();
        // GET: penTypesController
        public ActionResult Index()
        {
            
            
            main.penTypes = PenTypesController.penTypes;
            main.penColors = PenColorsController.penColors;
            
            if (pens.Count == 0)
            {
                pens.Add(new Pen() { id = 1, description = "perfect description of the best pen ever! This pen is test one."
                    , name = "Corvina 51", id_pen_color = 5, id_pen_type = 1, photo_location = "/Files/photo1.jpg" });
            }
            if (main.penColors.Count == 0)
            {
                main.penColors.Add(new PenColors() { id = 1, name = "red" });
                main.penColors.Add(new PenColors() { id = 2, name = "green" });
                main.penColors.Add(new PenColors() { id = 3, name = "blue" });
                main.penColors.Add(new PenColors() { id = 5, name = "dark blue" });
                main.penColors.Add(new PenColors() { id = 6, name = "black" });
                main.penColors.Add(new PenColors() { id = 7, name = "pink" });
                main.penColors.Add(new PenColors() { id = 8, name = "yellow" });
            }
            if (main.penTypes.Count == 0)
            {
                main.penTypes.Add(new PenTypes() { id = 1, name = "ball pen" });
                main.penTypes.Add(new PenTypes() { id = 2, name = "gel pen" });
                main.penTypes.Add(new PenTypes() { id = 3, name = "fountain pen" });
            }
            
            main.rels = PenShopRelController.rels;
            if (main.rels.Count == 0)
            {
                main.rels.Add(new PenShopRelation() { id = 1, id_pen = 1, id_shop = 1, price = 245.5, pen_number = 100 });
                main.rels.Add(new PenShopRelation() { id = 1, id_pen = 1, id_shop = 2, price = 285.5, pen_number = 30 });
            }

            main.pens = pens;
            return View(main);
        }


        // GET: pensController/Details/5
        public ActionResult Details(int id)
        {
            main.rels = PenShopRelController.rels;
            main.shops = ShopController.shops;
            if (main.shops.Count == 0)
            {
                main.shops.Add(new Shop() { id = 1, address = "м, вулиця Волоська, 55-57, Київ, 04070", name = "Стікер" });
                main.shops.Add(new Shop() { id = 2, address = "26, проспект Свободи, Київ, 04215", name = "Канц Плюс" });
            }
            main.pen = pens.Where(e => e.id == id).FirstOrDefault();
            main.shops_extended = new List<PenColors>();
            foreach (var el in main.rels)
            {
                if (el.id_pen == id) 
                { 
                    string name = "";
                    name += main.shops.Find(e => e.id == el.id_shop).name + "; ";
                    name += el.price + " coins; " + el.pen_number + " pens available;";

                    main.shops_extended.Add(new PenColors() { id = el.id, name = name });
                }
            }
            main.pen_id = id;
            if (main.shops_extended.Count == 0)
            {
                main.shops_extended.Add(new PenColors() { id = -1, name ="No shops sell this pen!" });
                main.shops.Clear();
            }

            return View(main);
        }

        // GET: pensController/Create
        [HttpGet]
        public ActionResult Create()
        {
            main.pen = new Pen();
            main.penTypes = PenTypesController.penTypes;
            main.penColors = PenColorsController.penColors;
            return View(main);
        }

        // POST: pensController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Main main0)
        {
            if (pens.Find(e => e.id == main0.pen.id) != null)
            {
                ViewData["wrongId"] = "this id is already in use";
                return View();
            }
            else
            {
                Pen pen = new Pen();
                if (main0.upload != null)
                {
                    string webRootPath = _env.WebRootPath;
                    string path = "/Files/" + main0.upload.FileName;
                    using(var fs =new FileStream(webRootPath+ path, FileMode.Create))
                    {
                        main0.upload.CopyTo(fs);
                    }
                    pen.photo_location = path;

                }
                pen.name = main0.pen.name;
                pen.id_pen_type = main0.pen.id_pen_type;
                pen.id_pen_color = main0.pen.id_pen_color;
                pen.description = main0.pen.description;
                pen.id = main0.pen.id;
                pens.Add(pen);
            }

           

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: pensController/Edit/5
        public ActionResult Edit(int id)
        {
            main.pen = pens.Find(e=>e.id==id);
            main.penTypes = PenTypesController.penTypes;
            main.penColors = PenColorsController.penColors;
            return View(main);
        }

        // POST: pensController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Main main0)
        {
            if (pens.Find(e => e.id == main0.pen.id) != null)
            {
                ViewData["wrongId"] = "this id is already in use";
                return View();
            }
            else
            {
                Pen pen = new Pen();
                if (main0.upload != null)
                {
                    string path = "/Files/" + main0.upload.FileName;
                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        main0.upload.CopyTo(fs);
                    }
                    pen.photo_location = path;

                }
                pen.name = main0.pen.name;
                pen.id_pen_type = main0.pen.id_pen_type;
                pen.id_pen_color = main0.pen.id_pen_color;
                pen.description = main0.pen.description;
                
                pens.Add(pen);
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: pensController/Delete/5
        public ActionResult Delete(int id)
        {
            Pen pen = pens.Where(e => e.id == id).FirstOrDefault();
            return View(pen);
        }

        // POST: pensController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (pens.Find(e => e.id == id) != null)
            {
                pens.Remove(pens.Find(e => e.id == id));
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Buy(int shop_id,int pen_id)
        {
            if (shop_id > 0) { 
                main.rels.Find(e => (e.id_pen == pen_id) && (e.id_shop == shop_id)).pen_number--;
                PenShopRelController.rels = main.rels;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
