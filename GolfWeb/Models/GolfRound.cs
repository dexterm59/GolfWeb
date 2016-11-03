using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GolfWeb.Models
{
    public class GolfRound
    {
       [Key]
       [Column(Order = 1)]
        public int GolferID { get; set; }
        [Key]
        [Column(Order=2)]
        public DateTime RoundTime { get; set; }
        public virtual Golfer Golfer { get; set; }
        public float Index { get; set; }
        
        
        public int GolfCourseID { get; set; }
        public virtual GolfCourse GolfCourse { get; set; }
        public virtual ICollection<GolfHole> Scores { get; set; }

    }
}