using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GolfWeb.Models
{
   
    public class Golfer
    {
        
        public int GolferID { get; set; }
        [DisplayName("Last Name")]
        [StringLength(30)]
        public string LastName { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage = "A first name is required")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [DisplayName("GHIN Number")]
        [StringLength(7)]
        public string GhinNum { get; set; }
    }
}