using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBLab0.Models;
using WEBLab0.Controllers;
namespace WEBLab0.Controllers
{
    public class PenColorsController : Controller
    {

        public static List<PenColors> penColors = new List<PenColors>();
        // GET: PenColorsController
        public ActionResult Index()
        {
            if(penColors.Count==0)
            {
                penColors.Add(new PenColors() { id = 1, name = "red" });
                penColors.Add(new PenColors() { id = 2, name = "green" });
                penColors.Add(new PenColors() { id = 3, name = "blue" });
                penColors.Add(new PenColors() { id = 5, name = "dark blue" });
                penColors.Add(new PenColors() { id = 6, name = "black" });
                penColors.Add(new PenColors() { id = 7, name = "pink" });
                penColors.Add(new PenColors() { id = 8, name = "yellow" });
            }
            return View(penColors);
        }
       

        // GET: PenColorsController/Details/5
        public ActionResult Details(int id)
        {
            PenColors penColor = penColors.Where(e => e.id == id).FirstOrDefault();
            return View(penColor);
        }

        // GET: PenColorsController/Create
        [HttpGet]
        public ActionResult Create()
        {           
            return View();
        }

        // POST: PenColorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, string name)
        {
            if(penColors.Find(e=>e.id==id) != null)
            {
                ViewData["wrongId"] = "this id is already in use";
                return View();
            }
            else
            {
                penColors.Add(new PenColors() { id = id, name = name });
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

        // GET: PenColorsController/Edit/5
        public ActionResult Edit(int id)
        {
            PenColors penColor = penColors.Where(e => e.id == id).FirstOrDefault();
            return View(penColor);
        }

        // POST: PenColorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string name)
        {
            penColors.Find(e => e.id == id).name = name;
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PenColorsController/Delete/5
        public ActionResult Delete(int id)
        {
            PenColors penColor = penColors.Where(e => e.id == id).FirstOrDefault();
            return View(penColor);
        }

        // POST: PenColorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if(penColors.Find(e => e.id == id) != null)
            {
                penColors.Remove(penColors.Find(e => e.id == id));
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
