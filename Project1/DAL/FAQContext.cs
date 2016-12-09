using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Project1.Models;

namespace Project1.DAL
{
    public class FAQContext : DbContext
    {
        public FAQContext()
            : base("FAQContext")
        {

        }

        public DbSet<DegreesModels> Degrees { get; set; }
        public DbSet<UsersModels> Users { get; set; }
        public DbSet<DegreeQuestionsModels> DegreeQuestions { get; set; }
        
    }
}