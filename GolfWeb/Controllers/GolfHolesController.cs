using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GolfWeb.Models;

namespace GolfWeb.Controllers
{
    public class GolfHolesController : Controller
    {
        private GolfDBContext db = new GolfDBContext();

        // GET: GolfHoles
        public ActionResult Index()
        {
            var golfHoles = db.GolfHoles.Include(g => g.GolfCourse);
            return View(golfHoles.ToList());
        }

        // GET: GolfHoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GolfHole golfHole = db.GolfHoles.Find(id);
            if (golfHole == null)
            {
                return HttpNotFound();
            }
            return View(golfHole);
        }

        // GET: GolfHoles/Create
        public ActionResult Create()
        {
            ViewBag.GolfCourseID = new SelectList(db.Courses, "GolfCourseID", "Name");
            return View();
        }

        // POST: GolfHoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GolfHoleID,GolfCourseID,HoleNum,Par,Handicap")] GolfHole golfHole)
        {
            if (ModelState.IsValid)
            {
                db.GolfHoles.Add(golfHole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GolfCourseID = new SelectList(db.Courses, "GolfCourseID", "Name", golfHole.GolfCourseID);
            return View(golfHole);
        }

        // GET: GolfHoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GolfHole golfHole = db.GolfHoles.Find(id);
            if (golfHole == null)
            {
                return HttpNotFound();
            }
            ViewBag.GolfCourseID = new SelectList(db.Courses, "GolfCourseID", "Name", golfHole.GolfCourseID);
            return View(golfHole);
        }

        // POST: GolfHoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GolfHoleID,GolfCourseID,HoleNum,Par,Handicap")] GolfHole golfHole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(golfHole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GolfCourseID = new SelectList(db.Courses, "GolfCourseID", "Name", golfHole.GolfCourseID);
            return View(golfHole);
        }

        // GET: GolfHoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GolfHole golfHole = db.GolfHoles.Find(id);
            if (golfHole == null)
            {
                return HttpNotFound();
            }
            return View(golfHole);
        }

        // POST: GolfHoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GolfHole golfHole = db.GolfHoles.Find(id);
            db.GolfHoles.Remove(golfHole);
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
