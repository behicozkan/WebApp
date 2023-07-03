using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.EntityFramework;
using System.Web.Security;

namespace WebApp.Controllers
{
    public class dersOnayModel
    {
        public StudentCourses StudentCourses { get; set; }
        public Course Course { get; set; }

        public Student Student { get; set; }
    }
    public class AdminController : Controller

    {
        
        // GET: Admin
        StudentManagementSystemEntities1 db = new StudentManagementSystemEntities1();

        [Authorize]
        public ActionResult Index(int id)
        {
            //onaya gelen dersler
           
            var model = db.StudentCourses.Join(db.Course, sc => sc.CourseID, c => c.CourseID, (sc, c) => new { StudentCourses = sc, Course = c }).Join(db.Student, sc_c => sc_c.StudentCourses.StudentID, s => s.StudentID, (sc_c, s) => new { StudentCourses = sc_c.StudentCourses, Course = sc_c.Course, Student = s }).Where(sc_c_s => sc_c_s.StudentCourses.StudentID == id).Select(sc_c_s => new dersOnayModel
            {
        StudentCourses = sc_c_s.StudentCourses,
        Course = sc_c_s.Course,
        Student = sc_c_s.Student
    }).Where(x=> x.StudentCourses.isApproved==false).ToList();

            return View(model);
        }


        public ActionResult GelenKutusu(int id)
        {
            var model = db.Messages.Where(x => x.ReceiverID == id).ToList();
            return View(model);

        }

        public ActionResult Onayla(int studentCourseId, int adminId)
        {
            var model = db.StudentCourses.FirstOrDefault(x => x.StudentCoursesID == studentCourseId);

            model.isApproved=true;

            db.SaveChanges();

            return RedirectToAction("Index", "Admin", new { id = adminId }); ;

        }




    }
}