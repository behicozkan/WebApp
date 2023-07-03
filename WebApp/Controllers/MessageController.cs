using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.EntityFramework;
using System.Web.Security;

namespace WebApp.Controllers
{
    public class MessageController : Controller
    {
        StudentManagementSystemEntities1 db = new StudentManagementSystemEntities1();

      
        public ActionResult MesajGonder(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Gonder(int id, string Mesaj)
        {
            var student = db.Student.FirstOrDefault(x => x.StudentID == id);
            var mentorId = student.MentorID; 

            Messages newMessage = new Messages
            {
                SenderID = id,
                ReceiverID = mentorId,
                Date = DateTime.Now,
                MessageText = Mesaj,
            };

            db.Messages.Add(newMessage);
            db.SaveChanges();


            ViewBag.Message = "Mesaj başarıyla gönderildi.";

            return RedirectToAction("MesajGonder", "Message", new { id = student.StudentID }); ;
        }


    }
}