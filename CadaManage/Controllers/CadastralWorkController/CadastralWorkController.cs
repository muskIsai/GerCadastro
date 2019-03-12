using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadaManage.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace CadaManage.Controllers.CWController
{
    public class CadastralWorkController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CW
        [HttpGet, Authorize(Roles = "Admin, Engineer,Carlos,Vershin")]
        public ActionResult ListCW()
        {
            var items = db.CadastralWorks.Include(p => p.User).Include(p => p.app);
            return View(items);
        }
        private ApplicationUserManager UserManager
        {   get
            {return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        // GET: CW/Create
        [HttpGet]
        public ActionResult CWCreate(int id)
        {
            ApplicationUser user = UserManager.FindByEmail(User.Identity.Name);
            ViewBag.User = user;
            Application app = db.Applications.Find(id);
            ViewBag.App = app;
            return View();
        }
        // POST: CW/Create
        [HttpPost]
        public ActionResult CWCreate(CadastralWork cw, int id)
        {
            Application app = db.Applications.Find(id);
            if (app == null)
                return HttpNotFound();
            app.fk_status = 4;
            db.Entry(app).State = EntityState.Modified;
            db.SaveChanges();
            db.CadastralWorks.Add(cw);
            db.SaveChanges();
            return RedirectToAction("ListCW");
        }

        // GET: CW/Edit/5
        [HttpGet]
        public ActionResult CWEdit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            // Находим в бд выбранную КР
            CadastralWork cw = db.CadastralWorks.Find(id);
            if (cw != null)
              return View(cw);
            
            return RedirectToAction("ListCW");
        }
        // POST: CW/Edit/5
        [HttpPost]
        public ActionResult CWEdit(CadastralWork cw)
        {
            db.Entry(cw).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ListCW");            
        }

        // GET: CW/Delete/5
        [HttpGet]
        public ActionResult CWDelete(int id)
        {
            CadastralWork cw = db.CadastralWorks.Find(id);
            if (cw == null)
                return HttpNotFound();

            return View(cw);
        }
        // POST: CW/Delete/5
        [HttpPost, ActionName("CWDelete")]
        public ActionResult CWDeleteConfirmed(int id)
        {
            CadastralWork cw = db.CadastralWorks.Find(id);
            if (cw == null)
            {
                return HttpNotFound();
            }
            db.CadastralWorks.Remove(cw);
            db.SaveChanges();
            return RedirectToAction("ListCW");
        }
        // GET: CW/Complete 
        [HttpGet]
        public ActionResult CWComplete(int id)
        {
            CadastralWork cw = db.CadastralWorks.Find(id);
            ViewBag.CW = cw;
            ViewBag.Date = DateTime.Now;
            // Формируем список статусов для передачи в представление
            SelectList status = new SelectList(db.LegalStatus, "Id", "lsName");
            ViewBag.LegalStatus = status;
            return View();
        }
        // POST: CW/Complete
        [HttpPost]
        public ActionResult CWComplete(CadastralObject co, int id)
        {
            CadastralWork cw = db.CadastralWorks.Find(id);
            if (cw == null)
                return HttpNotFound();
            cw.app.fk_status = 6;
            db.Entry(cw).State = EntityState.Modified;
            db.SaveChanges();
            db.CadastralObjects.Add(co);
            db.SaveChanges();
            return RedirectToAction("ListCO", "CO");
        }
    }
}
