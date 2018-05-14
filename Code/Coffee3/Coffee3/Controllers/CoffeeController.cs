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
    public class CoffeeController : Controller
    {
        private Coffee db = new Coffee();

        // GET: Coffee
        public ActionResult Index()
        {
            var drinks = db.drinks.Include(d => d.drinktype);
            return View(drinks.ToList());
        }

        // GET: Coffee/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drink drink = db.drinks.Find(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }

        // GET: Coffee/Create
        public ActionResult Create()
        {
            ViewBag.drinktypecode = new SelectList(db.drinktypes, "code", "nameof");
            return View();
        }

        // POST: Coffee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "code,nameof,drinktypecode")] drink drink)
        {
            if (ModelState.IsValid)
            {
                db.drinks.Add(drink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.drinktypecode = new SelectList(db.drinktypes, "code", "nameof", drink.drinktypecode);
            return View(drink);
        }

        // GET: Coffee/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drink drink = db.drinks.Find(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            ViewBag.drinktypecode = new SelectList(db.drinktypes, "code", "nameof", drink.drinktypecode);
            return View(drink);
        }

        // POST: Coffee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "code,nameof,drinktypecode")] drink drink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.drinktypecode = new SelectList(db.drinktypes, "code", "nameof", drink.drinktypecode);
            return View(drink);
        }

        // GET: Coffee/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drink drink = db.drinks.Find(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }

        // POST: Coffee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            drink drink = db.drinks.Find(id);
            db.drinks.Remove(drink);
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
