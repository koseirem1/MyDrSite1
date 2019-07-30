using MyDrSite.Data;
using MyDrSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDrSite.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    public class FilmsController : Controller
    {
        // GET: Admin/Films
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var films = db.Films.Include("Category").ToList();
                return View(films);
            }
        }

        // GET: Admin/Films/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Films/Create
        public ActionResult Create()
        {
            var film = new Film();
            using (var db = new ApplicationDbContext())
            {
                ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            }

            return View(film);
        }

        // POST: Admin/Films/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Film film)
        {
            if (ModelState.IsValid)
            {

                using (var db = new ApplicationDbContext())
                {
                    db.Films.Add(film);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            using (var db = new ApplicationDbContext())
            {
                ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            }

            return View(film);
        }
        
        // GET: Admin/Films/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var film = db.Films.Where(x => x.Id == id).FirstOrDefault();
                if (film != null)
                {

                    ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");

                    return View(film);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        // POST: Admin/Films/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Film film)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                   
                    var oldproject = db.Films.Where(x => x.Id == film.Id).FirstOrDefault();
                    if (oldproject != null)
                    {
                        oldproject.Name = film.Name;
                        oldproject.Description = film.Description;
                        oldproject.Body = film.Body;
                        oldproject.CategoryId = film.CategoryId;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }


            using (var db = new ApplicationDbContext())
            {
                ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            }


            return View(film);
        }

        // GET: Admin/Films/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var project = db.Films.Where(x => x.Id == id).FirstOrDefault();
                if (project != null)
                {
                    db.Films.Remove(project);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return HttpNotFound();
                }

            }
        }

        // POST: Admin/Films/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
