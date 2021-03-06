﻿using System;
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
    public class ResorcesController : Controller
    {
        private MasterDBContext db = new MasterDBContext();

        // GET: Resorces
        public ActionResult Index()
        {
            var resorce = db.Resorce.Include(r => r.Type);
            return View(resorce.ToList());
        }

        // GET: Resorces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resorce resorce = db.Resorce.Find(id);
            if (resorce == null)
            {
                return HttpNotFound();
            }
            return View(resorce);
        }

        // GET: Resorces/Create
        public ActionResult Create()
        {
            ViewBag.ResourceTypeID = new SelectList(db.ResourceType, "ID", "Type");
            return View();
        }

        // POST: Resorces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ResourceTypeID,DetailsXml")] Resorce resorce)
        {
            if (ModelState.IsValid)
            {
                db.Resorce.Add(resorce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResourceTypeID = new SelectList(db.ResourceType, "ID", "Type", resorce.ResourceTypeID);
            return View(resorce);
        }

        // GET: Resorces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resorce resorce = db.Resorce.Find(id);
            if (resorce == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResourceTypeID = new SelectList(db.ResourceType, "ID", "Type", resorce.ResourceTypeID);
            return View(resorce);
        }

        // POST: Resorces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ResourceTypeID,DetailsXml")] Resorce resorce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resorce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResourceTypeID = new SelectList(db.ResourceType, "ID", "Type", resorce.ResourceTypeID);
            return View(resorce);
        }

        // GET: Resorces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resorce resorce = db.Resorce.Find(id);
            if (resorce == null)
            {
                return HttpNotFound();
            }
            return View(resorce);
        }

        // POST: Resorces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resorce resorce = db.Resorce.Find(id);
            db.Resorce.Remove(resorce);
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
