using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBLab0.Models;

namespace WEBLab0.Controllers
{

    public class PenTypesController : Controller
    {
        public static List<PenTypes> penTypes = new List<PenTypes>();
        // GET: penTypesController
        public ActionResult Index()
        {
            if (penTypes.Count == 0)
            {
                penTypes.Add(new PenTypes() { id = 1, name = "ball pen" });
                penTypes.Add(new PenTypes() { id = 2, name = "gel pen" });
                penTypes.Add(new PenTypes() { id = 3, name = "fountain pen" });
            }
            return View(penTypes);
        }


        // GET: penTypesController/Details/5
        public ActionResult Details(int id)
        {
            PenTypes penColor = penTypes.Where(e => e.id == id).FirstOrDefault();
            return View(penColor);
        }

        // GET: penTypesController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: penTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, string name)
        {
            if (penTypes.Find(e => e.id == id) != null)
            {
                ViewData["wrongId"] = "this id is already in use";
                return View();
            }
            else
            {
                penTypes.Add(new PenTypes() { id = id, name = name });
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

        // GET: penTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            PenTypes penColor = penTypes.Where(e => e.id == id).FirstOrDefault();
            return View(penColor);
        }

        // POST: penTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string name)
        {
            penTypes.Find(e => e.id == id).name = name;
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: penTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            PenTypes penColor = penTypes.Where(e => e.id == id).FirstOrDefault();
            return View(penColor);
        }

        // POST: penTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (penTypes.Find(e => e.id == id) != null)
            {
                penTypes.Remove(penTypes.Find(e => e.id == id));
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
