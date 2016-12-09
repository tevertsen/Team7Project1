using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1.DAL;
using Project1.Models;
using System.Web.Security;

/*
 * Tyler Evertsen 
 * Section 2
 * Group 7
 * Date Created: 12/08/2016
 * 
 * This project enables the user to view the BYU Information Systems website.
 * This project scope allows the user to login and store their credentials into a database which is accessed through
 * the model. The user also will be able to look at the Degrees and FAQ within each of these degrees.
 * The user will be able to ask questions, look at the last most rescent response and change the response to that question.
 * The website is dynamic and works with several controllers, views, and models to access this information. 
 * */

namespace Project1.Controllers
{
    public class HomeController : Controller
    {

        private FAQContext db = new FAQContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Degrees()
        {
            return View();
        }
        
        //You must authorize the user in order to access the BSIS view
        [Authorize]
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


            return View(db.DegreeQuestions.ToList());
        }

        //You must authorize the user in order to access the MISM view
        [Authorize]
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

            return View(db.DegreeQuestions.ToList());
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

        //The Login method is what allows the the user to use credentials saved within a database and login to the system
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }

        //This HttpPost looks into the database to verify the user's email and password match the given email and password input.
        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email"].ToString();
            String password = form["Password"].ToString();

            //This verifies the email the user input actually exists
            bool userExists = db.Users.Any(m => m.userEmail.Equals(email));

            
            if(userExists)
            {
                //If password matches it will now load up the record where that email exists in the database
                UsersModels User = db.Users.SingleOrDefault(user => user.userEmail == email);

                string matchingpw = User.password.ToString();
                int myuserid = User.userID;
                Session["WHATEVER"] = myuserid;

                //With the loaded two variables it now will check to see if the password written matches the password on file
                if (string.Equals(password, matchingpw))
                {
                    //This logs the user into the site 
                    FormsAuthentication.SetAuthCookie(email, rememberMe);

                    return RedirectToAction("Index", "Home");
                }
                else
                    //If password is wrong it will return an error
                {
                     ViewBag.Error = "The password is incorrect.";
                     return ViewBag.Error();

                }
            }

            else
                //If email is wrong it will return an error
            {
                ViewBag.Error2 = "The email is incorrect.";
                return ViewBag.Error2();
            }

        }

        //Logging out
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}