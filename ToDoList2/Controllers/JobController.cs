using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList2.Models;

namespace ToDoList2.Controllers
{
    public class JobController : Controller
    {
        ToDoListEntities db = new ToDoListEntities();

        public JsonResult Jobs()
        {
            var model = db.DoList.ToList();
            return Json(

                new
                {
                    Result = model
                }, JsonRequestBehavior.AllowGet
                );
        }
    }
}