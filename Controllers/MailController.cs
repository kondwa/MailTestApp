using MailTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MailTestApp.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost()]
        public ActionResult Index(MailModel mail)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "mail.mra.mw";
            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.Send(mail.From, mail.To, mail.Subject, mail.Message);
                ViewBag.success = "Email sent.";
            }catch(Exception e)
            {
                ViewBag.errors = e.Message;
            }
            
            return View(mail);
        }
    }
}