using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project1.Models
{
         [Table("DegreeQuestions")]
    public class DegreeQuestionsModels
    {
        [Key]
        public int degreeQuestionID { get; set; }
        public int degreeID { get; set; }
        public int userID { get; set; }
        public String question { get; set; }
        public String answer { get; set; }
    }

}