using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBLab0.Models;

namespace WEBLab0.Controllers
{
    public class PenShopRelController : Controller
    {
        public static Main main = new Main();
        public static List<PenShopRelation> rels = new List<PenShopRelation>();
        public ActionResult Index()
        {
            if (rels.Count == 0)
            {
                rels.Add(new PenShopRelation() { id = 1, id_pen = 1, id_shop = 1, price = 245.5, pen_number = 100 });
                rels.Add(new PenShopRelation() { id = 2, id_pen = 1, id_shop = 2, price = 285.5, pen_number = 30 });
            }
            main.pens = PenController.pens;
            main.shops = ShopController.shops;
            main.rels = rels;
            if (main.shops.Count == 0)
            {
                main.shops.Add(new Shop() { id = 1, address = "м, вулиця Волоська, 55-57, Київ, 04070", name = "Стікер" });
                main.shops.Add(new Shop() { id = 2, address = "26, проспект Свободи, Київ, 04215", name = "Канц Плюс" });
            }
            if (main.pens.Count == 0)
            {
                main.pens.Add(new Pen()
                {
                    id = 1,
                    description = "perfect description of the best pen ever! This pen is test one."
                    ,
                    name = "BestPen1",
                    id_pen_color = 2,
                    id_pen_type = 1,
                    photo_location = "/Files/photo1.jpg"
                });
            }
            return View(main);
        }

        

        // GET: PenShopRelController/Create
        public ActionResult Create()
        {
            main.rel = new PenShopRelation();
            return View(main);
        }

        // POST: PenShopRelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Main main)
        {
            if (rels.Find(e => e.id == main.rel.id) != null)
            {
                ViewData["wrongId"] = "this id is already in use";
                return View();
            }
            else
            {
                rels.Add(new PenShopRelation() { id = main.rel.id, id_pen= main.rel.id_pen,id_shop= main.rel.id_shop
                    ,price= main.rel.price,pen_number= main.rel.pen_number });
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

        // GET: PenShopRelController/Edit/5
        public ActionResult Edit(int id)
        {
            main.pens = PenController.pens;
            main.shops = ShopController.shops;
            main.rels = rels;
            main.rel = rels.Find(e => e.id == id);
            return View(main);
        }

        // POST: PenShopRelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int id_pen, int id_shop, double price, int pen_number)
        {
            rels.Find(e => e.id == id).id_pen = id_pen;
            rels.Find(e => e.id == id).id_shop = id_shop;
            rels.Find(e => e.id == id).pen_number = pen_number;
            rels.Find(e => e.id == id).price = price;
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PenShopRelController/Delete/5
        public ActionResult Delete(int id)
        {
            PenShopRelation rel = rels.Find(e => e.id == id);
            return View(rel);
        }

        // POST: PenShopRelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            rels.Remove(rels.Find(e => e.id == id));
            main.rels = rels;
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
