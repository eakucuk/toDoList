using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList2.Models;
using ToDoList2.ViewModels;

namespace ToDoList2.Controllers
{
    public class HomeController : Controller
    {
        ToDoListEntities db = new ToDoListEntities();
        public ActionResult Index()
        {
            Jobs jobs = new Jobs();
            jobs.doList = db.DoList.ToList();
            return View(jobs);
        }
        public JsonResult Ekle(DoList doList)
        {
            db.DoList.Add(doList);
            db.SaveChanges();
            return Json("1");
        }

        public ActionResult Delete(int id)
        {
            var deleteuser = db.DoList.Find(id);
            if (deleteuser == null)
                return HttpNotFound();
            db.DoList.Remove(deleteuser);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = db.DoList.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("Guncelle", model);
        }

        [HttpPost]
        public ActionResult Guncelle(DoList doList)
        {
            var update = db.DoList.Find(doList.ID);
            if (update == null)
            {
                return HttpNotFound();
            }
            update.toDo = doList.toDo;
            update.date = doList.date;
            db.SaveChanges();
            return View("Index");
        }

    }
}