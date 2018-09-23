using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FFbasEDataEF;

namespace MvcFFbasENew.Controllers
{
    public class CourseOfLectureController : Controller
    {
        private DBFFbasEEntities db = new DBFFbasEEntities();

        // GET: CourseOfLecture
        public ActionResult Index()
        {
            return View(db.COURSE_OF_LECTURE.ToList());
        }
        
        public ActionResult Edit(int id)
        {
            var course = (from c in db.COURSE_OF_LECTURE where c.CL_ID == id select c).First();
            return View(course);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditComplete(int id, FormCollection collection)
        {
            var course = (from c in db.COURSE_OF_LECTURE where c.CL_ID == id select c).First();
            try
            {
                UpdateModel(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(course);
            }
        }

        public ActionResult Delete(int id)
        {
            var course = (from c in db.COURSE_OF_LECTURE where c.CL_ID == id select c).First();
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteComplete(int id, FormCollection collection)
        {
            var course = (from c in db.COURSE_OF_LECTURE where c.CL_ID == id select c).First();
            try
            {
                db.COURSE_OF_LECTURE.Remove(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(course);
            }
        }

        public ActionResult Create()
        {
            COURSE_OF_LECTURE course = new COURSE_OF_LECTURE();
            return View(course);
        }

        [HttpPost, ActionName("Create")]
        public ActionResult CreateComplete(COURSE_OF_LECTURE course)
        {
            try
            {
                if (ModelState.IsValid)
                    db.COURSE_OF_LECTURE.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(course);
            }
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult DetailsStudentsClients(int id, FormCollection collection)
        {
            return PartialView(db.CLIENT.ToList());
        }

        public ActionResult DetailsLectures(int id, FormCollection collection)
        {
            return PartialView(db.LECTURE.ToList());
        }
    }
}