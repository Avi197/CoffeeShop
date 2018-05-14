using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Coffee3.Models.Entities;

namespace Coffee3.Controllers
{
    public class whatsupsController : Controller
    {
        private Coffee db = new Coffee();

        // GET: whatsups
        public ActionResult Index()
        {
            return View(db.whatsups.ToList());
        }

        // GET: whatsups/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            whatsup whatsup = db.whatsups.Find(id);
            if (whatsup == null)
            {
                return HttpNotFound();
            }
            return View(whatsup);
        }

        // GET: whatsups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: whatsups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "code,nameof,descriptions")] whatsup whatsup)
        {
            if (ModelState.IsValid)
            {
                db.whatsups.Add(whatsup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(whatsup);
        }

        // GET: whatsups/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            whatsup whatsup = db.whatsups.Find(id);
            if (whatsup == null)
            {
                return HttpNotFound();
            }
            return View(whatsup);
        }

        // POST: whatsups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "code,nameof,descriptions")] whatsup whatsup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(whatsup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(whatsup);
        }

        // GET: whatsups/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            whatsup whatsup = db.whatsups.Find(id);
            if (whatsup == null)
            {
                return HttpNotFound();
            }
            return View(whatsup);
        }

        // POST: whatsups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            whatsup whatsup = db.whatsups.Find(id);
            db.whatsups.Remove(whatsup);
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
