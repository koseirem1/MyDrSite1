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
    public class BookController : Controller
    {
        // GET: Admin/Book
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var books = db.Books.Include("Author").ToList();
                return View(books);
            }
            
        }

        // GET: Admin/Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Book/Create
        public ActionResult Create()
        {
            var book = new Book();
            using (var db = new ApplicationDbContext())
            {
                ViewBag.Authors = new SelectList(db.Authors.ToList(), "Id", "FullName");
            }

            return View(book);
            
        }

       
        // POST: Admin/Book/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {

                using (var db = new ApplicationDbContext())
                { 
                    try
                    {
                        
                    }
                    catch (Exception ex)
                    {
                        //upload sırasında hata oluşursa view da görüntüülemek üzere hatayı modelstate ekle
                        ViewBag.Error = ex.Message;
                        //hata oluştuğu için projeyi veritabanına eklemek yerine view'ı tekrar göster ve metottan çık
                        ViewBag.Authors = new SelectList(db.Authors.ToList(), "Id", "FullName");
                        return View(book);
                    }
                    db.Books.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            using (var db = new ApplicationDbContext())
            {
                ViewBag.Authors = new SelectList(db.Authors.ToList(), "Id", "FullName");
            }

            return View(book);
        }

        // GET: Admin/Book/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var book = db.Books.Where(x => x.Id == id).FirstOrDefault();
                if (book != null)
                {

                    ViewBag.Authors = new SelectList(db.Authors.ToList(), "Id", "FullName");

                    return View(book);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        // POST: Admin/Book/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                   
                    var oldproject = db.Books.Where(x => x.Id == book.Id).FirstOrDefault();
                    if (oldproject != null)
                    {
                        oldproject.Name = book.Name;
                       
                        oldproject.AuthorId = book.AuthorId;
                        oldproject.Publisher = book.Publisher;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }


            using (var db = new ApplicationDbContext())
            {
                ViewBag.Authors = new SelectList(db.Authors.ToList(), "Id", "FullName");
            }


            return View(book);
        }

        // GET: Admin/Book/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var book = db.Books.Where(x => x.Id == id).FirstOrDefault();
                if (book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return HttpNotFound();
                }

            }
        }

        // POST: Admin/Book/Delete/5
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
