using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.EntityFramework;

namespace WebApp.Controllers
{
    public class StudentCourseWithCourse
    {
        public StudentCourses StudentCourses { get; set; }
        public Course Course { get; set; }
    }
    public class StudentCourseAddDelete
    {
        public Course Course { get; set; }
        public bool MevcutMu { get; set; }
    }
    public class StudentCoursesController : Controller
    {
         StudentManagementSystemEntities1 db = new StudentManagementSystemEntities1();
      

        // GET: StudentCourses
        [Authorize]
        public ActionResult Index(int id)
        {
            var model = db.StudentCourses.Join(db.Course, x => x.CourseID, y => y.CourseID, (x, y) => new StudentCourseWithCourse { StudentCourses = x, Course = y }).Where(x => x.StudentCourses.StudentID == id).ToList();
            
            return View(model);
        }

        [Authorize]
        public ActionResult DersEkleSil(int id)
        {
            var tumDersler = db.Course.ToList();
            var model2 = db.StudentCourses.Where(x => x.StudentID == id).ToList();

            var yeniModel = tumDersler.Select(ders => new StudentCourseAddDelete
            {
                Course = ders,
                MevcutMu = model2.Any(m => m.CourseID == ders.CourseID)
            }).ToList();

            return View(yeniModel);
        }


       
        public ActionResult Sil(int id,int studentId)
        {
            var secilenDers = db.StudentCourses.FirstOrDefault(x => x.StudentID == studentId && x.CourseID == id);
            if (secilenDers == null)
            {
                return HttpNotFound();
            }

            db.StudentCourses.Remove(secilenDers); // Remove the student from the database
            db.SaveChanges();

            return RedirectToAction("Index", new { id = secilenDers.StudentID });
        }

        public ActionResult Ekle(int id, int studentId)
        {
            var eklenenDers = new StudentCourses()
            {
                CourseID = id,
                StudentID = studentId,
                isApproved = false,
            };

            db.StudentCourses.Add(eklenenDers);
            db.SaveChanges();
            db.SaveChanges();

            return RedirectToAction("Index", new { id = studentId });
        }


    }
}
