using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using station.DAL;
using station.Models;

namespace station.Controllers
{
    public class DataPointsController : Controller
    {
        private StationContext db = new StationContext();

        // GET: DataPoints
        public ActionResult Index()
        {
            return View(db.DataPoints.ToList());
        }

        // GET: DataPoints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataPoint dataPoint = db.DataPoints.Find(id);
            if (dataPoint == null)
            {
                return HttpNotFound();
            }
            return View(dataPoint);
        }

        // GET: DataPoints/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataPoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TimeStamp,Value")] DataPoint dataPoint)
        {
            if (ModelState.IsValid)
            {
                db.DataPoints.Add(dataPoint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dataPoint);
        }

        // GET: DataPoints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataPoint dataPoint = db.DataPoints.Find(id);
            if (dataPoint == null)
            {
                return HttpNotFound();
            }
            return View(dataPoint);
        }

        // POST: DataPoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TimeStamp,Value")] DataPoint dataPoint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dataPoint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dataPoint);
        }

        // GET: DataPoints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataPoint dataPoint = db.DataPoints.Find(id);
            if (dataPoint == null)
            {
                return HttpNotFound();
            }
            return View(dataPoint);
        }

        // POST: DataPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DataPoint dataPoint = db.DataPoints.Find(id);
            db.DataPoints.Remove(dataPoint);
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
