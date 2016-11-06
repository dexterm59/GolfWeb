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
        public virtual List<HoleScore> Scores { get; set; }

        public void AddDefaultScores()
        {         
            var holes = GolfCourse.Holes.ToList();
            Scores = new List<HoleScore>();
            foreach (var hole in holes)
            {
                var hs = new HoleScore();
                hs.GolfCourseID = hole.GolfCourseID;
                hs.GolferID = Golfer.GolferID;
                hs.RoundTime = RoundTime;
                hs.HoleNum = hole.HoleNum;
                hs.Score = hole.Par;
                hs.FairwayAccuracy = HoleScore.Fairway.In;
                hs.ApproachAccuracy = HoleScore.Approach.On;
                hs.Chip = false;
                hs.Pitch = false;
                hs.Penalty = 0;
                hs.Putts = 2;
                hs.Sand = false;
                Scores.Add(hs);
            }
            return;
        }

    }
}