using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Masterdb.DataAccsess.DAL;
using OpenQbit.Masterdb.Common.Models;

namespace Masterdb.Presentation.Web.Controllers
{
    public class DetailsController : Controller
    {
        private MasterDBContext db = new MasterDBContext();

        // GET: Details
        public ActionResult Index()
        {
            var details = db.Details.Include(d => d.R).Include(d => d.ResourceHierachy);
            return View(details.ToList());
        }

        // GET: Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Details details = db.Details.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }

        // GET: Details/Create
        public ActionResult Create()
        {
            ViewBag.RID = new SelectList(db.Resorce, "ID", "DetailsXml");
            ViewBag.ResourceHierachyID = new SelectList(db.ResourceHierachy, "ID", "ID");
            return View();
        }

        // POST: Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RID,PRID,ResourceHierachyID")] Details details)
        {
            if (ModelState.IsValid)
            {
                db.Details.Add(details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RID = new SelectList(db.Resorce, "ID", "DetailsXml", details.RID);
            ViewBag.ResourceHierachyID = new SelectList(db.ResourceHierachy, "ID", "ID", details.ResourceHierachyID);
            return View(details);
        }

        // GET: Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Details details = db.Details.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            ViewBag.RID = new SelectList(db.Resorce, "ID", "DetailsXml", details.RID);
            ViewBag.ResourceHierachyID = new SelectList(db.ResourceHierachy, "ID", "ID", details.ResourceHierachyID);
            return View(details);
        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RID,PRID,ResourceHierachyID")] Details details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RID = new SelectList(db.Resorce, "ID", "DetailsXml", details.RID);
            ViewBag.ResourceHierachyID = new SelectList(db.ResourceHierachy, "ID", "ID", details.ResourceHierachyID);
            return View(details);
        }

        // GET: Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Details details = db.Details.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Details details = db.Details.Find(id);
            db.Details.Remove(details);
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
