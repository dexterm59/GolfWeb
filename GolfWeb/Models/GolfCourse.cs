using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace GolfWeb.Models
{
    public class GolfCourse
    {
        private GolfDBContext db = new GolfDBContext();
        [Key]
        public int GolfCourseID {get; set;}
        public string Name { get; set; }
        public virtual List<GolfHole> Holes { get; set; }
        public int CourseSlope { get; set; }
        public float CourseRating { get; set; }
        public void AddHoles(int golfCourseID)
        {
            var golfCourse = db.Courses.Find(golfCourseID);
            for (var i = 0; i < 18; i++)
            {
                var h = new GolfHole();
                h.HoleNum = i + 1;
                h.Par = 4;
                h.GolfCourseID = golfCourse.GolfCourseID;
                db.GolfHoles.Add(h);
            }
            db.SaveChanges();
        }
    }
   
    public class GolfDBContext : DbContext
    {
        public DbSet<GolfCourse> Courses { get; set; }
        public DbSet<GolfHole> GolfHoles { get; set; }
        public DbSet<Golfer> Golfers { get; set; }
        public DbSet<GolfRound> GolfRounds { get; set; }
        public DbSet<HoleScore> HoleScores { get; set; }
        
    }
}