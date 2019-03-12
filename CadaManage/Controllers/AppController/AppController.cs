using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadaManage.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CadaManage.Controllers.AppController
{
    public class AppController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: App
        [HttpGet, Authorize(Roles = "Admin, Engineer,Customer,Carlos,Vershin")]
        public ActionResult ListApp()
        {
            var items = db.Applications.Include(p => p.HandBookOfCOType).Include(p => p.User).Include(p => p.Status).Include(p => p.TypeCW);
            ApplicationUser user = UserManager.FindByEmail(User.Identity.Name);
            ViewBag.User = user;
            return View(items);
        }
        private ApplicationUserManager UserManager
        { get
            { return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        // GET: App/Create 
        [HttpGet, Authorize(Roles = "Customer, Admin")]
        public ActionResult AppCreate()
        {
            ApplicationUser user = UserManager.FindByEmail(User.Identity.Name);
            ViewBag.User = user;
            ViewBag.Date = DateTime.Now;
            // Формируем список типов КО для передачи в представление
            SelectList typeCO = new SelectList(db.HandBookOfCOTypes, "Id", "tHCOname");
            ViewBag.HandBookOfCOTypes = typeCO;
            // Формируем список типов КР для передачи в представление
            SelectList typeCW = new SelectList(db.TypeCWs, "Id", "tCWname");
            ViewBag.TypeCW = typeCW;
            ViewBag.Status = 2; 
            return View();
        }
        // POST: App/Create
        [HttpPost]
        public ActionResult AppCreate(Application App)
        {
            db.Applications.Add(App);
            db.SaveChanges();
            return RedirectToAction("ListApp");
        }

        // GET: App/Edit/5
        [HttpGet]
        public ActionResult AppEdit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            // Находим в бд выбранную заявку
            Application app = db.Applications.Find(id);
            if (app != null)
            {
                // Создаем список типо КО для передачи в представление
                SelectList typeCO = new SelectList(db.HandBookOfCOTypes, "Id", "tHCOname", app.fk_typeCO);
                ViewBag.HandBookOfCOTypes = typeCO;
                // Создаем список типо КР для передачи в представление
                SelectList typeCW = new SelectList(db.TypeCWs, "Id", "tCWname", app.fk_typeCW);
                ViewBag.TypeCW = typeCW;
                return View(app);
            }
            return RedirectToAction("ListApp");
        }

        // POST: App/Edit/5
        [HttpPost]
        public ActionResult AppEdit(Application app)
        {
            db.Entry(app).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ListApp");
        }
        // GET: App/Cancel/5
        [HttpGet]
        public ActionResult AppCancel(int id)
        {
            Application app = db.Applications.Find(id);
            if (app == null)
                return HttpNotFound();
            return View(app);
        }

        // POST: App/Cancel/5
        [HttpPost, ActionName("AppCancel")]
        public ActionResult AppCancelConfirmed(int id)
        {
            Application app = db.Applications.Find(id);
            if (app == null)            
                return HttpNotFound();
            app.fk_status=5;
            db.Entry(app).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ListApp");
        }
        // GET: App/Delete/5
        [HttpGet]
        public ActionResult AppDelete(int id)
        {
            Application app = db.Applications.Find(id);
            if (app == null)
                return HttpNotFound();
            return View(app);
        }

        // POST: App/Delete/5
        [HttpPost, ActionName("AppDelete")]
        public ActionResult AppDeleteConfirmed(int id)
        {
            Application app = db.Applications.Find(id);
            if (app == null)
                return HttpNotFound();            
            db.Applications.Remove(app);
            db.SaveChanges();
            return RedirectToAction("ListApp");
        }

        // GET: App/AppPay/5
        [HttpGet]
        public ActionResult AppPay(int? id)
        {
            if (id == null)
               return HttpNotFound();
            // Находим в бд выбранную заявку
            Application app = db.Applications.Find(id);
            if (app != null)
            {   return View(app);
            }
            return RedirectToAction("ListApp");
        }

        // POST: App/AppPay/5
        [HttpPost]
        public ActionResult AppPay(Application app)
        {
            db.Entry(app).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ListApp");
        }
    }
}
