using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FFbasEDataEF;

namespace MvcFFbasENew.Controllers
{
    public class StudentController : Controller
    {
        private DBFFbasEEntities db = new DBFFbasEEntities();

        // GET: Student
        public ActionResult Index()
        {
            return View(db.STUDENT.ToList());
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ClientList = db.CLIENT.ToList();
            ViewBag.CourseList = db.COURSE_OF_LECTURE.ToList();
            var student = (from s in db.STUDENT where s.S_ID == id select s).First();
            return View(student);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditComplete(int id, FormCollection collection)
        {
            var student = (from s in db.STUDENT where s.S_ID == id select s).First();
            try
            {
                UpdateModel(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(student);
            }
        }

        public ActionResult Details(int id, FormCollection collection)
        {
            var student = (from s in db.STUDENT where s.S_ID == id select s).First();
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult Delete(int id)
        {
            var student = (from s in db.STUDENT where s.S_ID == id select s).First();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteComplete(int id, FormCollection collection)
        {
            var student = (from s in db.STUDENT where s.S_ID == id select s).First();
            try
            {
                db.STUDENT.Remove(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(student);
            }
        }

        public ActionResult Create()
        {
            STUDENT student = new STUDENT();
            ViewBag.ClientList = db.CLIENT.ToList();
            ViewBag.CourseList = db.COURSE_OF_LECTURE.ToList();
            return View(student);
        }

        [HttpPost, ActionName("Create")]
        public ActionResult CreateComplete(STUDENT student)
        {
            try
            {
                if (ModelState.IsValid)
                    db.STUDENT.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(student);
            }
        }
    }
}