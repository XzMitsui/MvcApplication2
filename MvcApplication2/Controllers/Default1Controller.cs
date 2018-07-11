using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class Default1Controller : Controller
    {
        private PeopleEntities db = new PeopleEntities();

        //
        // GET: /Default1/
        static int size = 2;
        static int pagenum = 1;
        public ActionResult Index(int? val)
        {
            var data = db.peopleinfo;

            int count = data.Count();

            var yeshu = (double)count / size;

            int zongyeshu = (int)Math.Ceiling(yeshu);

            if (val == 0 || val == null)
            {
                pagenum = 1;
            }
            //上一页
            else if (val == -1)
            {
                if (pagenum > 1)
                {
                    pagenum -= 1;
                }
                else if (pagenum == 1)
                {
                    pagenum = 1;
                }
            }
            //下一页
            else if (val == 1)
            {
                if (pagenum < zongyeshu)
                {
                    pagenum += 1;
                }
                else
                {
                    pagenum = zongyeshu;
                }

            }
            else if (val == 2)
            {
                pagenum = zongyeshu; ;
            }
            var data1 = data.OrderBy(p => p.ID).Skip((pagenum - 1) * size).Take(size);

            return PartialView(data1);
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            peopleinfo peopleinfo = db.peopleinfo.Find(id);
            if (peopleinfo == null)
            {
                return HttpNotFound();
            }
            return View(peopleinfo);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(peopleinfo peopleinfo)
        {
            if (ModelState.IsValid)
            {
                db.peopleinfo.Add(peopleinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peopleinfo);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            peopleinfo peopleinfo = db.peopleinfo.Find(id);
            if (peopleinfo == null)
            {
                return HttpNotFound();
            }
            return View(peopleinfo);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(peopleinfo peopleinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peopleinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peopleinfo);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            peopleinfo peopleinfo = db.peopleinfo.Find(id);
            if (peopleinfo == null)
            {
                return HttpNotFound();
            }
            return View(peopleinfo);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            peopleinfo peopleinfo = db.peopleinfo.Find(id);
            db.peopleinfo.Remove(peopleinfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}