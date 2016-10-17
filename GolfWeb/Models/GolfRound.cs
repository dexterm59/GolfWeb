using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GolfWeb.Models
{
    public class GolfRound
    {
        public int GolfRoundID { get; set; }
        public GolfRound()
        {
            this.Scores = new HashSet<HoleScore>();
        }
        
        public Golfer Golfer { get; set; }
        public float Index { get; set; }
        public DateTime RoundTime { get; set; }
        public GolfCourse Course { get; set; }
        public virtual ICollection<HoleScore> Scores { get; set; }

    }
}