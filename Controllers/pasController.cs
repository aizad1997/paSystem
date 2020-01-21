using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using paSystem.Models;

namespace paSystem.Controllers
{
    public class pasController : Controller
    {
        private myDatabaseEntities db = new myDatabaseEntities();

        // GET: pas
        public ActionResult Index()
        {
            return View(db.pas.ToList());
        }

        // GET: pas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pa pa = db.pas.Find(id);
            if (pa == null)
            {
                return HttpNotFound();
            }
            return View(pa);
        }

        // GET: pas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: pas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,lectureID,studentID")] pa pa)
        {
            if (ModelState.IsValid)
            {
                db.pas.Add(pa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pa);
        }

        // GET: pas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pa pa = db.pas.Find(id);
            if (pa == null)
            {
                return HttpNotFound();
            }
            return View(pa);
        }

        // POST: pas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,lectureID,studentID")] pa pa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pa);
        }

        // GET: pas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pa pa = db.pas.Find(id);
            if (pa == null)
            {
                return HttpNotFound();
            }
            return View(pa);
        }

        // POST: pas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pa pa = db.pas.Find(id);
            db.pas.Remove(pa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
