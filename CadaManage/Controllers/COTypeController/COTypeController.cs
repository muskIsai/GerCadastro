using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadaManage.Models;

namespace CadaManage.Controllers.COTypeController
{
    public class COTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: COType        
        [HttpGet]
        public ActionResult ShowHandBookOfCOType()
        {
            return View(db.HandBookOfCOTypes.ToList());
        }
        // GET: COType/Details/5
        public ActionResult typeCODetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            HandBookOfCOType typeCO = db.HandBookOfCOTypes.Find(id);
            if (typeCO == null)
            {
                return HttpNotFound();
            }
            typeCO.co = db.CadastralObjects.Where(m => m.fk_typeCO == typeCO.Id);
            return View(typeCO);
        }

        // GET: COType/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        // POST: COType/Create
        [HttpPost]
        public ActionResult Create(HandBookOfCOType type)
        {
            db.HandBookOfCOTypes.Add(type);
            db.SaveChanges();
            return RedirectToAction("ShowHandBookOfCOType");
        }

        // GET: COType/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            HandBookOfCOType type = db.HandBookOfCOTypes.Find(id);
            if (type != null)
            {
                return View(type);
            }
            return HttpNotFound();
        }
        // POST: COType/Edit/5
        [HttpPost]
        public ActionResult Edit(HandBookOfCOType type)
        {
            db.Entry(type).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ShowHandBookOfCOType");
        }

        // GET: COType/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            HandBookOfCOType type = db.HandBookOfCOTypes.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        // POST: COType/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult typeDelete(int id)
        {
            HandBookOfCOType type = db.HandBookOfCOTypes.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            db.HandBookOfCOTypes.Remove(type);
            db.SaveChanges();
            return RedirectToAction("ShowHandBookOfCOType");
        }
    }
}
