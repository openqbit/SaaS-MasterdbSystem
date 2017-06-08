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
    public class ResourceTypesController : Controller
    {
        private MasterDBContext db = new MasterDBContext();

        // GET: ResourceTypes
        public ActionResult Index()
        {
            return View(db.ResourceType.ToList());
        }

        // GET: ResourceTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceType resourceType = db.ResourceType.Find(id);
            if (resourceType == null)
            {
                return HttpNotFound();
            }
            return View(resourceType);
        }

        // GET: ResourceTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResourceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type")] ResourceType resourceType)
        {
            if (ModelState.IsValid)
            {
                db.ResourceType.Add(resourceType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resourceType);
        }

        // GET: ResourceTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceType resourceType = db.ResourceType.Find(id);
            if (resourceType == null)
            {
                return HttpNotFound();
            }
            return View(resourceType);
        }

        // POST: ResourceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type")] ResourceType resourceType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resourceType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resourceType);
        }

        // GET: ResourceTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceType resourceType = db.ResourceType.Find(id);
            if (resourceType == null)
            {
                return HttpNotFound();
            }
            return View(resourceType);
        }

        // POST: ResourceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResourceType resourceType = db.ResourceType.Find(id);
            db.ResourceType.Remove(resourceType);
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
