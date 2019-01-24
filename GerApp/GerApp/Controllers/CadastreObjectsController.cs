using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GerApp.Models;

namespace GerApp.Controllers
{
    public class CadastreObjectsController : Controller
    {
        private EFContext db = new EFContext();

        // GET: CadastreObjects
        public ActionResult Index()
        {
            //return View(db.CadastreObjects.ToList());
            return View(db.CadastreObjects.OrderBy(x => x.TypeCadastre));
        }

        // GET: CadastreObjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastreObjects cadastreObjects = db.CadastreObjects.Find(id);
            if (cadastreObjects == null)
            {
                return HttpNotFound();
            }
            return View(cadastreObjects);
        }

        // GET: CadastreObjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CadastreObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CadastreObjectsID,Price,TypeCadastre,RegistrationDate,Comment")] CadastreObjects cadastreObjects)
        {
            if (ModelState.IsValid)
            {
                db.CadastreObjects.Add(cadastreObjects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastreObjects);
        }

        // GET: CadastreObjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastreObjects cadastreObjects = db.CadastreObjects.Find(id);
            if (cadastreObjects == null)
            {
                return HttpNotFound();
            }
            return View(cadastreObjects);
        }

        // POST: CadastreObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CadastreObjectsID,Price,TypeCadastre,RegistrationDate,Comment")] CadastreObjects cadastreObjects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastreObjects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastreObjects);
        }

        // GET: CadastreObjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastreObjects cadastreObjects = db.CadastreObjects.Find(id);
            if (cadastreObjects == null)
            {
                return HttpNotFound();
            }
            return View(cadastreObjects);
        }

        // POST: CadastreObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CadastreObjects cadastreObjects = db.CadastreObjects.Find(id);
            db.CadastreObjects.Remove(cadastreObjects);
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
