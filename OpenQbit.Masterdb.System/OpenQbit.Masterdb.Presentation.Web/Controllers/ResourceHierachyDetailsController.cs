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
    public class ResourceHierachyDetailsController : Controller
    {
        private MasterDBContext db = new MasterDBContext();

        // GET: ResourceHierachyDetails
        public ActionResult Index()
        {
            var details = db.Details.Include(r => r.ChildResorce).Include(r => r.ParentResorce).Include(r => r.ResourceHierachy);
            return View(details.ToList());
        }

        // GET: ResourceHierachyDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceHierachyDetails resourceHierachyDetails = db.Details.Find(id);
            if (resourceHierachyDetails == null)
            {
                return HttpNotFound();
            }
            return View(resourceHierachyDetails);
        }

        // GET: ResourceHierachyDetails/Create
        public ActionResult Create()
        {
            ViewBag.RID = new SelectList(db.Resorce, "ID", "DetailsXml");
            ViewBag.PRID = new SelectList(db.Resorce, "ID", "DetailsXml");
            ViewBag.ResourceHierachyID = new SelectList(db.ResourceHierachy, "ID", "ID");
            return View();
        }

        // POST: ResourceHierachyDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RID,PRID,ResourceHierachyID")] ResourceHierachyDetails resourceHierachyDetails)
        {
            if (ModelState.IsValid)
            {
                db.Details.Add(resourceHierachyDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RID = new SelectList(db.Resorce, "ID", "DetailsXml", resourceHierachyDetails.RID);
            ViewBag.PRID = new SelectList(db.Resorce, "ID", "DetailsXml", resourceHierachyDetails.PRID);
            ViewBag.ResourceHierachyID = new SelectList(db.ResourceHierachy, "ID", "ID", resourceHierachyDetails.ResourceHierachyID);
            return View(resourceHierachyDetails);
        }

        // GET: ResourceHierachyDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceHierachyDetails resourceHierachyDetails = db.Details.Find(id);
            if (resourceHierachyDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.RID = new SelectList(db.Resorce, "ID", "DetailsXml", resourceHierachyDetails.RID);
            ViewBag.PRID = new SelectList(db.Resorce, "ID", "DetailsXml", resourceHierachyDetails.PRID);
            ViewBag.ResourceHierachyID = new SelectList(db.ResourceHierachy, "ID", "ID", resourceHierachyDetails.ResourceHierachyID);
            return View(resourceHierachyDetails);
        }

        // POST: ResourceHierachyDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RID,PRID,ResourceHierachyID")] ResourceHierachyDetails resourceHierachyDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resourceHierachyDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RID = new SelectList(db.Resorce, "ID", "DetailsXml", resourceHierachyDetails.RID);
            ViewBag.PRID = new SelectList(db.Resorce, "ID", "DetailsXml", resourceHierachyDetails.PRID);
            ViewBag.ResourceHierachyID = new SelectList(db.ResourceHierachy, "ID", "ID", resourceHierachyDetails.ResourceHierachyID);
            return View(resourceHierachyDetails);
        }

        // GET: ResourceHierachyDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceHierachyDetails resourceHierachyDetails = db.Details.Find(id);
            if (resourceHierachyDetails == null)
            {
                return HttpNotFound();
            }
            return View(resourceHierachyDetails);
        }

        // POST: ResourceHierachyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResourceHierachyDetails resourceHierachyDetails = db.Details.Find(id);
            db.Details.Remove(resourceHierachyDetails);
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
