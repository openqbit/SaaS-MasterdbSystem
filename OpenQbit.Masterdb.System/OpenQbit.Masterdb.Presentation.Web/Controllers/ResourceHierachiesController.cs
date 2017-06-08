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
    public class ResourceHierachiesController : Controller
    {
        private MasterDBContext db = new MasterDBContext();

        // GET: ResourceHierachies
        public ActionResult Index()
        {
            var resourceHierachy = db.ResourceHierachy.Include(r => r.Type);
            return View(resourceHierachy.ToList());
        }

        // GET: ResourceHierachies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceHierachy resourceHierachy = db.ResourceHierachy.Find(id);
            if (resourceHierachy == null)
            {
                return HttpNotFound();
            }
            return View(resourceHierachy);
        }

        // GET: ResourceHierachies/Create
        public ActionResult Create()
        {
            ViewBag.TypeID = new SelectList(db.ResourceHierachyType, "ID", "Type");
            return View();
        }

        // POST: ResourceHierachies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TypeID")] ResourceHierachy resourceHierachy)
        {
            if (ModelState.IsValid)
            {
                db.ResourceHierachy.Add(resourceHierachy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypeID = new SelectList(db.ResourceHierachyType, "ID", "Type", resourceHierachy.TypeID);
            return View(resourceHierachy);
        }

        // GET: ResourceHierachies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceHierachy resourceHierachy = db.ResourceHierachy.Find(id);
            if (resourceHierachy == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeID = new SelectList(db.ResourceHierachyType, "ID", "Type", resourceHierachy.TypeID);
            return View(resourceHierachy);
        }

        // POST: ResourceHierachies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TypeID")] ResourceHierachy resourceHierachy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resourceHierachy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeID = new SelectList(db.ResourceHierachyType, "ID", "Type", resourceHierachy.TypeID);
            return View(resourceHierachy);
        }

        // GET: ResourceHierachies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceHierachy resourceHierachy = db.ResourceHierachy.Find(id);
            if (resourceHierachy == null)
            {
                return HttpNotFound();
            }
            return View(resourceHierachy);
        }

        // POST: ResourceHierachies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResourceHierachy resourceHierachy = db.ResourceHierachy.Find(id);
            db.ResourceHierachy.Remove(resourceHierachy);
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
