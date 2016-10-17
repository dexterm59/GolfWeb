using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace GolfWeb.Models
{
    public class HoleScore
    {
        public int HoleScoreID { get; set; }
        public int Score { get; set; }
        public enum Fairway { In, Left, Right }
        public enum Approach {On, Short, Long, Right, Left}
        public int Putts { get; set; }
        public int FirstPuttLength { get; set; }
        public int MadePuttLength { get; set; }
        public bool Chip { get; set; }
        public bool Pitch { get; set; }
        public bool Sand { get; set; }
        public int Penalty { get; set; }
        [ForeignKey("GolfRound")]
        public int RoundID { get; set; }
        public virtual GolfRound GolfRound { get; set; }
        [ForeignKey("GolfHole")]
        public int GolfHoleID { get; set; }
        public virtual GolfHole GolfHole { get; set; }
    }
}
