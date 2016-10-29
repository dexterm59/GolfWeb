using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace GolfWeb.Models
{
    public enum Fairway { In, Left, Right }
    public enum Approach { On, Short, Long, Right, Left }
    public class HoleScore
    {
        public int HoleScoreID { get; set; }
        public int Score { get; set; }
        public enum Fairway { In, Left, Right }
        public enum Approach {On, Short, Long, Right, Left}
        [Required]
        public Fairway FairwayAccuracy { get; set; }
        [Required]
        public Approach ApproachAccuracy { get; set; }
        public int Putts { get; set; }
        public int FirstPuttLength { get; set; }
        public int MadePuttLength { get; set; }
        public bool Chip { get; set; }
        public bool Pitch { get; set; }
        public bool Sand { get; set; }
        public int Penalty { get; set; }
        
        public int RoundID { get; set; }
        public virtual GolfRound GolfRound { get; set; }
  
        public int GolfHoleID { get; set; }
        public virtual GolfHole GolfHole { get; set; }
    }
    
}
