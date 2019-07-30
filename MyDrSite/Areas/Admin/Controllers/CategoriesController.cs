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
    public class CategoriesController : Controller
    {
        // GET: Admin/Categories
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var categories = db.Categories.ToList();
                return View(categories);
            }
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            var category = new Category();
            return View(category);
        }

        // POST: Admin/Categories/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var category = db.Categories.Where(x => x.Id == id).FirstOrDefault();
                if (category != null)
                {
                    return View(category);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        // POST: Admin/Categories/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var oldproject = db.Categories.Where(x => x.Id == category.Id).FirstOrDefault();
                    if (oldproject != null)
                    {
                        oldproject.Name = category.Name;
                        oldproject.Id = category.Id;


                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var category = db.Categories.Where(x => x.Id == id).FirstOrDefault();
                var films = db.Films.Where(x => x.CategoryId == id).ToList();
                foreach (var item in films)
                {
                    item.CategoryId = null;
                }
                db.SaveChanges();
                db.Categories.Remove(category);
                db.SaveChanges();
                return RedirectToAction("Index");

                if (category != null)
                {
                    db.Categories.Remove(category);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return HttpNotFound();
                }

            }
        }

        // POST: Admin/Categories/Delete/5
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
