using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.EntityFramework;
using System.Web.Security;


namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        StudentManagementSystemEntities1 db = new StudentManagementSystemEntities1();
        // domain/controller/action
        public ActionResult AdminLogin()
        {
            return View();
        }
       
        public ActionResult StudentLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StudentAuth(Student student)
        {
            var studentInDb = db.Student.FirstOrDefault(x => x.StudentID == student.StudentID && x.Password == student.Password);
            if(studentInDb != null)
            {
                FormsAuthentication.SetAuthCookie(studentInDb.StudentID.ToString(), false);
                return RedirectToAction("Index", "StudentCourses", new {id= studentInDb.StudentID});
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı ve Şifre";
                return View("StudentLogin");
            }
               
        }

        [HttpPost]
        public ActionResult AdminAuth(Admin admin)
        {
            var adminInDb = db.Admin.FirstOrDefault(x => x.AdminID == admin.AdminID && x.Password == admin.Password);
            if (adminInDb != null)
            {
                FormsAuthentication.SetAuthCookie(adminInDb.AdminID.ToString(), false);
                return RedirectToAction("Index", "Admin", new { id = adminInDb.AdminID });
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı ve Şifre";
                return View("AdminLogin");
            }

        }


    }

    
}