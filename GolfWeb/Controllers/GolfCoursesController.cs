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
    public class GolfCoursesController : Controller
    {
        private GolfDBContext db = new GolfDBContext();

        // GET: GolfCourses
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        // GET: GolfCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GolfCourse golfCourse = db.Courses.Find(id);
            if (golfCourse == null)
            {
                return HttpNotFound();
            }
/*            var holes = from h in db.GolfHoles
                        where h.GolfCourseID == id
                        select h;
            golfCourse.Holes = holes.ToList<GolfHole>();*/
            return View(golfCourse);
        }

        // GET: GolfCourses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GolfCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GolfCourseID,Name,CourseSlope,CourseRating")] GolfCourse golfCourse)
        {
            if (ModelState.IsValid)
            {
                //need to put a try catch here to maker sure the db action succeeds - primary keys may be invalid
                db.Courses.Add(golfCourse);
                db.SaveChanges();
                for(var i = 0; i < 18; i++)
                {
                    var h = new GolfHole();
                    h.HoleNum = i + 1;
                    h.Par = 4;
                    h.GolfCourseID = golfCourse.GolfCourseID;
                    db.GolfHoles.Add(h);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(golfCourse);
        }

        // GET: GolfCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GolfCourse golfCourse = db.Courses.Find(id);
            if (golfCourse == null)
            {
                return HttpNotFound();
            }
            
            return View(golfCourse);
        }

        // POST: GolfCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GolfCourseID,Name,CourseSlope,CourseRating,Holes")] GolfCourse golfCourse)
        {
            if (ModelState.IsValid)
            {

              foreach(var hole in golfCourse.Holes)
                {
                    db.Entry(hole).State = EntityState.Modified;        
                }
            
                db.Entry(golfCourse).State = EntityState.Modified;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(golfCourse);
        }

        // GET: GolfCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GolfCourse golfCourse = db.Courses.Find(id);
            if (golfCourse == null)
            {
                return HttpNotFound();
            }
            return View(golfCourse);
        }

        // POST: GolfCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GolfCourse golfCourse = db.Courses.Find(id);
            db.Courses.Remove(golfCourse);
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
