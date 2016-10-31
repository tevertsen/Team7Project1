using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BSIS()
        {
            ViewBag.Message = "BSIS Faqs";
            ViewBag.DegreeName = "Bachelors of Science Information Systems";
            ViewBag.Cordinator = "Dr. Conan Albrecht";
            ViewBag.Title = "Executive Chairman of BSIS";
            ViewBag.OfficeAddress = "<address><strong>BYU Department of Incoming Students for Information Systems </strong><br />Provo, UT 84601-5647<br /><abbr title='Phone'>P:</abbr> 801-657-4765<br /><a href='mailto:DepartmentofIsysFAQs@byu.edu'>InformationSystemBSIS</a><br /></address>";
            ViewBag.PhD = "PhD at Arizona State University";
            ViewBag.Masters = "Masters of Information Systems Management at Brigham Young University";
            ViewBag.Bachelors = "Bachelors of Information Systems at Brigham Young University";
            ViewBag.Image = "albrecht.jpg";
                

            
            return View();
        }

        public ActionResult MISM()
        {
            ViewBag.Message = "MISM Faqs";

            ViewBag.DegreeName = "Masters of Information Systems Management";
            ViewBag.Cordinator = "Dr. Bonnie Anderson";
            ViewBag.Title = "Executive Chairman of MISM";
            ViewBag.OfficeAddress = "<address><strong>BYU Information Systems MISM </strong><br />Provo, UT 84601-5647<br /><abbr title='Phone'>P:</abbr> 801-657-47854<br /><a href='mailto:DepartmentofIsysFAQs@byu.edu'>InformationSystemMISM@byu.edu</a><br /></address>";
            ViewBag.PhD = "Accounting Information Systems PhD at Stanford University";
            ViewBag.Masters = "Masters of Accounting at Brigham Young University";
            ViewBag.Bachelors = "Bachelors of Science Accounting at Brigham Young University";
            ViewBag.Image = "anderson.jpg";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Dedicated to helping our future students";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Get in contact with us";

            return View();
        }
    }
}