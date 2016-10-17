using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace GolfWeb.Models
{
    public class GolfCourse
    {
        [Key]
        public int GolfCourseID {get; set;}
        public string Name { get; set; }
        public virtual ICollection<GolfHole> Holes { get; set; }
        public float CourseSlope { get; set; }
        public int CourseRating { get; set; }
        public GolfCourse()
        {
            this.Holes = new HashSet<GolfHole>();
            for(var i = 0; i < 18; i++)
            {
                GolfHole h = new GolfHole();
                this.Holes.Add(h);
            }
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