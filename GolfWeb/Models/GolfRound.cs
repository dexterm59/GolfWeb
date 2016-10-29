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
        public int GolfRoundID { get; set; }
        public int GolferID { get; set; }

        public virtual Golfer Golfer { get; set; }
        public float Index { get; set; }
        public DateTime RoundTime { get; set; }
        
        public int GolfCourseID { get; set; }
        public virtual GolfCourse GolfCourse { get; set; }
        public virtual ICollection<HoleScore> Scores { get; set; }

    }
}