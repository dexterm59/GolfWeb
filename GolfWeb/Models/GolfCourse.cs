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
        public int CourseSlope { get; set; }
        public float CourseRating { get; set; }
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