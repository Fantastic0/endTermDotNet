using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastProject.Controllers
{
    public class HelloController : Controller
    {

        const string SessionName = "_Name";
        const string SessionAge = "_Age";
        const string SessionKeyDate = "_Date";
        // GET: Hello
        public ActionResult Index()
        {
            ViewBag.MyStatus = TempData["status"];
            if (HttpContext.Session != null)
            {
                ViewBag.Name = HttpContext.Session.GetString(SessionName);
                ViewBag.Age = HttpContext.Session.GetInt32(SessionAge);
                ViewBag.Date = HttpContext.Session.Get<DateTime>(SessionKeyDate);
            }


            return View();
        }

        // GET: Hello/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Hello/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hello/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Hello/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Hello/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Hello/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Hello/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}