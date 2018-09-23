using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FFbasEDataEF;

namespace MvcFFbasENew.Controllers
{
    public class ClientController : Controller
    {
        private DBFFbasEEntities db = new DBFFbasEEntities();

        // GET: Client
        public ActionResult Index()
        {
            return View(db.CLIENT.ToList());
        }

        public ActionResult ClientByStatus(int id)
        {
            ViewBag.StatusName = db.STATUS.Where(x => x.SG_ID == id).First().SG_NAME;
            return View(db.CLIENT.Where(x => x.C_SG == id).ToList());
        }

        public ActionResult ClientDetails(int id)
        {
            return PartialView(db.CLIENT.Include("STUDENT").First(x => x.C_ID == id));
        }

        public ActionResult Edit(int id)
        {
            ViewBag.CmpList = db.STATUS.ToList();
            var client = (from c in db.CLIENT where c.C_ID == id select c).First();
            return View(client);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditComplete(int id, FormCollection collection)
        {
            var client = (from c in db.CLIENT where c.C_ID == id select c).First();
            try
            {
                UpdateModel(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(client);
            }
        }

        public ActionResult Delete(int id)
        {
            var client = (from c in db.CLIENT where c.C_ID == id select c).First();
            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteComplete(int id, FormCollection collection)
        {
            var client = (from c in db.CLIENT where c.C_ID == id select c).First();
            try
            {
                db.CLIENT.Remove(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View(client);
            }
        }

        public ActionResult Create()
        {
            CLIENT client = new CLIENT();
            ViewBag.CmpList = db.STATUS.ToList();
            return View(client);
        }

        [HttpPost, ActionName("Create")]
        public ActionResult CreateComplete(CLIENT client)
        {
            try
            {
                if (ModelState.IsValid)
                    db.CLIENT.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View(client);
            }
        }
    }
}