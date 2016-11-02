using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace GolfWeb.Models
{
    public class GolfHole
    {
        [Key]
        [Column(Order = 1)]
        public int GolfCourseID { get; set; }
        [Key]
        [Column(Order = 2)]
        [Display]
        public int HoleNum { get; set; }
        public int Par { get; set; }
        public int Handicap { get; set; }
        public virtual GolfCourse GolfCourse { get; set; }
        
    }
}
