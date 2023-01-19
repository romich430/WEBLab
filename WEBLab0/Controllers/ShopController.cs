using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBLab0.Models;

namespace WEBLab0.Controllers
{
    public class ShopController : Controller
    {
        public static List<Shop> shops = new List<Shop>();
        public ActionResult Index()
        {
            if (shops.Count == 0)
            {
                shops.Add(new Shop() { id = 1, address = "м, вулиця Волоська, 55-57, Київ, 04070", name = "Стікер" });
                shops.Add(new Shop() { id = 2, address = "26, проспект Свободи, Київ, 04215", name = "Канц Плюс" });
            }
            return View(shops);
        }

        // GET: ShopController/Details/5
        public ActionResult Details(int id)
        {
            Shop shop = shops.Find(e => e.id == id);
            return View(shop);
        }

        // GET: ShopController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, string name, string address)
        {
            if (shops.Find(e => e.id == id) != null)
            {
                ViewData["wrongId"] = "this id is already in use";
                return View();
            }
            else
            {
                shops.Add(new Shop() { id = id, name = name,address=address });
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

        // GET: ShopController/Edit/5
        public ActionResult Edit(int id)
        {
            Shop shop = shops.Find(e => e.id == id);
            return View(shop);
        }

        // POST: ShopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string name,string address)
        {
            shops.Find(e=>e.id==id).name=name;
            shops.Find(e => e.id == id).address = address;
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopController/Delete/5
        public ActionResult Delete(int id)
        {
            Shop shop = shops.Find(e => e.id == id);
            return View(shop);
        }

        // POST: ShopController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (shops.Find(e => e.id == id) != null)
            {
                shops.Remove(shops.Find(e => e.id == id));
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
    }
}
