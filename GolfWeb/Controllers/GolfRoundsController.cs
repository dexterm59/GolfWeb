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
    public class GolfRoundsController : Controller
    {
        private GolfDBContext db = new GolfDBContext();

        // GET: GolfRounds
        public ActionResult Index()
        {
            var golfRounds = db.GolfRounds.Include(g => g.GolfCourse).Include(g => g.Golfer);
            return View(golfRounds.ToList());
        }

        // GET: GolfRounds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GolfRound golfRound = db.GolfRounds.Find(id);
            if (golfRound == null)
            {
                return HttpNotFound();
            }
            return View(golfRound);
        }

        // GET: GolfRounds/Create
        public ActionResult Create()
        {
            ViewBag.GolfCourseID = new SelectList(db.Courses, "GolfCourseID", "Name");
            ViewBag.GolferID = new SelectList(db.Golfers, "GolferID", "LastName");
            return View();
        }

        // POST: GolfRounds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GolferID,RoundTime,Index,GolfCourseID")] GolfRound golfRound)
        {
            if (ModelState.IsValid)
            {
                db.GolfRounds.Add(golfRound);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GolfCourseID = new SelectList(db.Courses, "GolfCourseID", "Name", golfRound.GolfCourseID);
            ViewBag.GolferID = new SelectList(db.Golfers, "GolferID", "LastName", golfRound.GolferID);
            return View(golfRound);
        }

        // GET: GolfRounds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GolfRound golfRound = db.GolfRounds.Find(id);
            if (golfRound == null)
            {
                return HttpNotFound();
            }
            ViewBag.GolfCourseID = new SelectList(db.Courses, "GolfCourseID", "Name", golfRound.GolfCourseID);
            ViewBag.GolferID = new SelectList(db.Golfers, "GolferID", "LastName", golfRound.GolferID);
            return View(golfRound);
        }

        // POST: GolfRounds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GolferID,RoundTime,Index,GolfCourseID")] GolfRound golfRound)
        {
            if (ModelState.IsValid)
            {
                db.Entry(golfRound).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GolfCourseID = new SelectList(db.Courses, "GolfCourseID", "Name", golfRound.GolfCourseID);
            ViewBag.GolferID = new SelectList(db.Golfers, "GolferID", "LastName", golfRound.GolferID);
            return View(golfRound);
        }

        // GET: GolfRounds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GolfRound golfRound = db.GolfRounds.Find(id);
            if (golfRound == null)
            {
                return HttpNotFound();
            }
            return View(golfRound);
        }

        // POST: GolfRounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GolfRound golfRound = db.GolfRounds.Find(id);
            db.GolfRounds.Remove(golfRound);
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
