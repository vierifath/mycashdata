using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiz2Fix.Entities;

namespace Quiz2Fix.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        // GET: Menus
        public ActionResult Index()
        {
            List<Student> m;
            using (var r = new StudentsEntities())
            {
                m = r.Students.ToList();
            }
            return View(m);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            var menusmodel = new Student();
            TryUpdateModel(menusmodel);

            using (var r = new StudentsEntities())
            {
                r.Students.Add(menusmodel);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var menumodel = new Student();
            TryUpdateModel(menumodel);

            using (var r = new StudentsEntities())
            {
                menumodel = r.Students.FirstOrDefault(x => x.Id == Id);
            }

            return View(menumodel);
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(int Id)
        {
            var menumodel = new Student();
            TryUpdateModel(menumodel);

            using (var r = new StudentsEntities())
            {
                menumodel = r.Students.Where(x => x.Id == Id).FirstOrDefault();
            }

            return View(menumodel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int Id)
        {
            var menumodel = new Student();
            TryUpdateModel(menumodel);

            using (var r = new StudentsEntities())
            {
                var m = r.Students.Where(x => x.Id == Id).FirstOrDefault();
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(int Id)
        {
            var menumodel = new Student();
            TryUpdateModel(menumodel);

            using (var r = new StudentsEntities())
            {
                menumodel = r.Students.FirstOrDefault(x => x.Id == Id);
            }

            return View(menumodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int Id)
        {
            var menumodel = new Student();
            TryUpdateModel(menumodel);

            using (var r = new StudentsEntities())
            {
                var m = r.Students.Remove(r.Students.FirstOrDefault(x => x.Id == Id));
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        
    }


}