using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1.Models
{
     [Table("Degrees")]
    public class DegreesModels
    {
        [Key]
        public int degreeID { get; set; }
        public String degreeName { get; set; }
        public String degreeCoordinator { get; set; }
        public String coordinatorTitle { get; set; }
        public String coordinatorOfficeAddress { get; set; }
        public String PhDEducation { get; set; }
        public String mastersEducation { get; set; }
        public String bachelorsEducation { get; set; }
        public String coordinatorPicture { get; set; }
    }

   
    
}