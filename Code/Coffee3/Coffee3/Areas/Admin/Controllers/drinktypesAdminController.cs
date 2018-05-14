using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Coffee3.Models.Entities;
using Coffee3.Models.Function;
using Coffee3.Models.Security;

namespace Coffee3.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class drinktypesAdminController : Controller
    {
        private Coffee db = new Coffee();

        // GET: Admin/drinktypesAdmin
        public ActionResult Index()
        {
            return View(db.drinktypes.ToList());
        }

        // GET: Admin/drinktypesAdmin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drinktype drinktype = db.drinktypes.Find(id);
            if (drinktype == null)
            {
                return HttpNotFound();
            }
            return View(drinktype);
        }

        // GET: Admin/drinktypesAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/drinktypesAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "code,nameof")] drinktype drinktype)
        {
            if (ModelState.IsValid)
            {
                db.drinktypes.Add(drinktype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drinktype);
        }

        // GET: Admin/drinktypesAdmin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drinktype drinktype = db.drinktypes.Find(id);
            if (drinktype == null)
            {
                return HttpNotFound();
            }
            return View(drinktype);
        }

        // POST: Admin/drinktypesAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "code,nameof")] drinktype drinktype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drinktype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drinktype);
        }

        // GET: Admin/drinktypesAdmin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drinktype drinktype = db.drinktypes.Find(id);
            if (drinktype == null)
            {
                return HttpNotFound();
            }
            return View(drinktype);
        }

        // POST: Admin/drinktypesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            drinktype drinktype = db.drinktypes.Find(id);
            db.drinktypes.Remove(drinktype);
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
