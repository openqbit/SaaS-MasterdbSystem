using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenQbit.Masterdb.Common.Model;
using OpenQbit.Masterdb.DataAccsess.DAL;

namespace OpenQbit.Masterdb.Presentation.Web.Controllers
{
    public class ResourceHierachyTypesController : Controller
    {
        private MasterDBContext db = new MasterDBContext();

        // GET: ResourceHierachyTypes
        public ActionResult Index()
        {
            return View(db.ResourceHierachyType.ToList());
        }

        // GET: ResourceHierachyTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceHierachyType resourceHierachyType = db.ResourceHierachyType.Find(id);
            if (resourceHierachyType == null)
            {
                return HttpNotFound();
            }
            return View(resourceHierachyType);
        }

        // GET: ResourceHierachyTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResourceHierachyTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type")] ResourceHierachyType resourceHierachyType)
        {
            if (ModelState.IsValid)
            {
                db.ResourceHierachyType.Add(resourceHierachyType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resourceHierachyType);
        }

        // GET: ResourceHierachyTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceHierachyType resourceHierachyType = db.ResourceHierachyType.Find(id);
            if (resourceHierachyType == null)
            {
                return HttpNotFound();
            }
            return View(resourceHierachyType);
        }

        // POST: ResourceHierachyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type")] ResourceHierachyType resourceHierachyType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resourceHierachyType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resourceHierachyType);
        }

        // GET: ResourceHierachyTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceHierachyType resourceHierachyType = db.ResourceHierachyType.Find(id);
            if (resourceHierachyType == null)
            {
                return HttpNotFound();
            }
            return View(resourceHierachyType);
        }

        // POST: ResourceHierachyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResourceHierachyType resourceHierachyType = db.ResourceHierachyType.Find(id);
            db.ResourceHierachyType.Remove(resourceHierachyType);
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
