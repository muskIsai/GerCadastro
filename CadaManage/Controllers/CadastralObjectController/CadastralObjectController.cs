using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadaManage.Models;

namespace CadaManage.Controllers.COController
{
    public class CadastralObjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CO
        [HttpGet, Authorize(Roles = "Admin, Engineer,Customer,Carlos,Vershin")]
        public ActionResult ListCO()
        {
            var items = db.CadastralObjects.Include(p => p.HandBookOfCOType).Include(p => p.LegalStatus);
            return View(items.ToList());
        } 
        // GET: CO/Create      
        [HttpGet]
        public ActionResult COCreate()
        {
            // Формируем список типов КО для передачи в представление
            SelectList type = new SelectList(db.HandBookOfCOTypes, "Id", "tHCOname");
            ViewBag.HandBookOfCOTypes = type;
            // Формируем список статусов для передачи в представление
            SelectList status = new SelectList(db.LegalStatus, "Id", "lsName");
            ViewBag.LegalStatus = status; 
            return View();
        }
        // POST: CO/Create
        [HttpPost]
        public ActionResult COCreate(CadastralObject co)
        {
            //Добавляем КО в таблицу
            db.CadastralObjects.Add(co);
            db.SaveChanges();
            return RedirectToAction("ListCO");
        }

        // GET: CO/Edit/5
        [HttpGet]
        public ActionResult COEdit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            // Находим в бд выбранный KO
            CadastralObject co = db.CadastralObjects.Find(id);
            if (co != null)
            {
                // Создаем список типо КО для передачи в представление
                SelectList type = new SelectList(db.HandBookOfCOTypes, "Id", "tHCOname", co.fk_typeCO);
                ViewBag.HandBookOfCOTypes = type;
                // Формируем список статусов для передачи в представление
                SelectList status = new SelectList(db.LegalStatus, "Id", "lsName", co.fk_legalStatus);
                ViewBag.LegalStatus = status; return View(co);
            }
            return RedirectToAction("ListCO");            
        }
        // POST: CO/Edit/5
        [HttpPost]
        public ActionResult COEdit(CadastralObject co)
        {
            db.Entry(co).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ListCO");
        }
        // GET: CO/Delete/5
        [HttpGet]
        public ActionResult CODelete(int id)
        {
            CadastralObject co = db.CadastralObjects.Find(id);
            if (co == null)
            {
                return HttpNotFound();
            }
            return View(co);
        }
        // POST: CO/Delete/5
        [HttpPost, ActionName("CODelete")]
        public ActionResult CODeleteConfirmed(int id)
        {
            CadastralObject co = db.CadastralObjects.Find(id);
            if (co == null)
            {
                return HttpNotFound();
            }
            db.CadastralObjects.Remove(co);
            db.SaveChanges();
            return RedirectToAction("ListCO");
        }
    }
}
