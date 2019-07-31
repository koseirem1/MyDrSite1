using MyDrSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDrSite.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Books()
        {
           

            return View();
        }

        public ActionResult Films()
        {
           

            return View();
        }

        public ActionResult Contact()
        {
            List<string> Gunler = new List<string>();
            Gunler.Add("Pazartesi");
            Gunler.Add("Salı");
           
            ViewBag.Gunler = new SelectList(Gunler);

            return View();

        
          
          
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel model)//formu gönderince bu method çalışır. validasyonlar gerçekleşir.
        {
            if (ModelState.IsValid)
            {
                //TODO:mail gönder
                {
                    System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

                    mailMessage.From = new System.Net.Mail.MailAddress("koseirem1@gmail.com", "İrem Köse");
                    mailMessage.Subject = "İletişim Formu: " + model.FirstName;

                    mailMessage.To.Add("koseirem1@gmail.com,koseirem1@gmail.com");

                    string body;

                    body = "E-posta: " + model.Email + "<br />";
                    body += "Ad: " + model.FirstName + "<br />";
                    body += "Soyad: " + model.LastName + "<br />";
                    body += "Konu Başlığı" + model.Gunlere + "<br/>";
                    body += "Mesaj: " + model.Message + "<br />";
                    //  body += "Tarih: " + DateTime.Now.ToString("dd MMMM yyyy") + "<br />";
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = body;

                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new System.Net.NetworkCredential("koseirem1@gmail.com", "sifre");
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                    ViewBag.Message = "Mesajınız gönderildi. Teşekkür ederiz.";
                }

            }
            return View();
        }

       




        public ActionResult Kvkk()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}