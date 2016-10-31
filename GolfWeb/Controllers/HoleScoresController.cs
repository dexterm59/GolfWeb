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
    public class HoleScoresController : Controller
    {
        private GolfDBContext db = new GolfDBContext();

        // GET: HoleScores
        public ActionResult Index()
        {
            var holeScores = db.HoleScores.Include(h => h.GolfHole).Include(h => h.GolfRound);
            return View(holeScores.ToList());
        }

        // GET: HoleScores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoleScore holeScore = db.HoleScores.Find(id);
            if (holeScore == null)
            {
                return HttpNotFound();
            }
            return View(holeScore);
        }

        // GET: HoleScores/Create
        public ActionResult Create()
        {
            ViewBag.GolfHoleID = new SelectList(db.GolfHoles, "GolfHoleID", "GolfHoleID");
            ViewBag.GolferID = new SelectList(db.GolfRounds, "GolferID", "GolferID");
            ViewBag.RoundTime = new SelectList(db.GolfRounds, "RoundTime", "RoundTime");
            return View();
        }

        // POST: HoleScores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HoleScoreID,Score,FairwayAccuracy,ApproachAccuracy,Putts,FirstPuttLength,MadePuttLength,Chip,Pitch,Sand,Penalty,GolferID,RoundTime,GolfHoleID")] HoleScore holeScore)
        {
            if (ModelState.IsValid)
            {
                db.HoleScores.Add(holeScore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GolfHoleID = new SelectList(db.GolfHoles, "GolfHoleID", "GolfHoleID", holeScore.GolfHoleID);
            ViewBag.GolferID = new SelectList(db.GolfRounds, "GolferID", "GolferID", holeScore.GolferID);
            return View(holeScore);
        }

        // GET: HoleScores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoleScore holeScore = db.HoleScores.Find(id);
            if (holeScore == null)
            {
                return HttpNotFound();
            }
            ViewBag.GolfHoleID = new SelectList(db.GolfHoles, "GolfHoleID", "GolfHoleID", holeScore.GolfHoleID);
            ViewBag.GolferID = new SelectList(db.GolfRounds, "GolferID", "GolferID", holeScore.GolferID);
            return View(holeScore);
        }

        // POST: HoleScores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HoleScoreID,Score,FairwayAccuracy,ApproachAccuracy,Putts,FirstPuttLength,MadePuttLength,Chip,Pitch,Sand,Penalty,GolferID,RoundTime,GolfHoleID")] HoleScore holeScore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(holeScore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GolfHoleID = new SelectList(db.GolfHoles, "GolfHoleID", "GolfHoleID", holeScore.GolfHoleID);
            ViewBag.GolferID = new SelectList(db.GolfRounds, "GolferID", "GolferID", holeScore.GolferID);
            return View(holeScore);
        }

        // GET: HoleScores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoleScore holeScore = db.HoleScores.Find(id);
            if (holeScore == null)
            {
                return HttpNotFound();
            }
            return View(holeScore);
        }

        // POST: HoleScores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoleScore holeScore = db.HoleScores.Find(id);
            db.HoleScores.Remove(holeScore);
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
