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
    public class AuthorsController : Controller
    {
        // GET: Admin/Authors
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var authors = db.Authors.ToList();
                return View(authors);
            }
            
        }

        // GET: Admin/Authors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Authors/Create
        public ActionResult Create()
        {
            var author = new Author();
            return View(author);
           
        }

        // POST: Admin/Authors/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Authors.Add(author);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(author);
        }

        // GET: Admin/Authors/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var author = db.Authors.Where(x => x.Id == id).FirstOrDefault();
                if (author != null)
                {
                    return View(author);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        // POST: Admin/Authors/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    var oldproject = db.Authors.Where(x => x.Id == author.Id).FirstOrDefault();
                    if (oldproject != null)
                    {
                        oldproject.FullName = author.FullName;
                        oldproject.Id = author.Id;


                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(author);
        }

        // GET: Admin/Authors/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var author = db.Authors.Where(x => x.Id == id).FirstOrDefault();
                var books = db.Books.Where(x => x.AuthorId == id).ToList();
                foreach (var item in books)
                {
                    item.AuthorId = null;
                }
                db.SaveChanges();
                db.Authors.Remove(author);
                db.SaveChanges();
                return RedirectToAction("Index");

                if (author != null)
                {
                    db.Authors.Remove(author);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return HttpNotFound();
                }

            }
        }

        // POST: Admin/Authors/Delete/5
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
