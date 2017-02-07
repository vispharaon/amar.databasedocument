using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amar.DocumentDatabase.Models;

namespace Amar.DocumentDatabase.Controllers
{
    public class TestController : Controller
    {
        private amardatabaseEntities db = new amardatabaseEntities();

        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View(db.Test.ToList());
        }

        //
        // GET: /Test/Details/5

        public ActionResult Details(int id = 0)
        {
            Test test = db.Test.Single(t => t.ID == id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        //
        // GET: /Test/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Test/Create

        [HttpPost]
        public ActionResult Create(Test test)
        {
            if (ModelState.IsValid)
            {
                db.Test.AddObject(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test);
        }

        //
        // GET: /Test/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Test test = db.Test.Single(t => t.ID == id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        //
        // POST: /Test/Edit/5

        [HttpPost]
        public ActionResult Edit(Test test)
        {
            if (ModelState.IsValid)
            {
                db.Test.Attach(test);
                db.ObjectStateManager.ChangeObjectState(test, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(test);
        }

        //
        // GET: /Test/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Test test = db.Test.Single(t => t.ID == id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        //
        // POST: /Test/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = db.Test.Single(t => t.ID == id);
            db.Test.DeleteObject(test);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}