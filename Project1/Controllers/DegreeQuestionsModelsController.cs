using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project1.DAL;
using Project1.Models;

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
    public class DegreeQuestionsModelsController : Controller
    {
        private FAQContext db = new FAQContext();

        // GET: DegreeQuestionsModels
        public ActionResult Index()
        {
            return View(db.DegreeQuestions.ToList());
        }

        // GET: DegreeQuestionsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeQuestionsModels degreeQuestionsModels = db.DegreeQuestions.Find(id);
            if (degreeQuestionsModels == null)
            {
                return HttpNotFound();
            }
            return View(degreeQuestionsModels);
        }

        // GET: DegreeQuestionsModels/Create
        public ActionResult CreateBSIS()
        {
            return View();
        }

        // POST: DegreeQuestionsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBSIS([Bind(Include = "degreeQuestionID,degreeID,userID,question,answer")] DegreeQuestionsModels degreeQuestionsModels)
        {
            ////if (ModelState.IsValid)
            //{
            db.DegreeQuestions.Add(degreeQuestionsModels);
            db.SaveChanges();
            return RedirectToAction("Degrees", "Home");
            //}

            //return View(degreeQuestionsModels);
        }



        // GET: DegreeQuestionsModels/Create
        public ActionResult CreateMISM()
        {
            return View();
        }

        // POST: DegreeQuestionsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMISM([Bind(Include = "degreeQuestionID,degreeID,userID,question,answer")] DegreeQuestionsModels degreeQuestionsModels)
        {
            ////if (ModelState.IsValid)
            //{
            db.DegreeQuestions.Add(degreeQuestionsModels);
            db.SaveChanges();
            return RedirectToAction("Degrees", "Home");
            //}

            //return View(degreeQuestionsModels);
        }






        // GET: DegreeQuestionsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeQuestionsModels degreeQuestionsModels = db.DegreeQuestions.Find(id);
            if (degreeQuestionsModels == null)
            {
                return HttpNotFound();
            }
            return View(degreeQuestionsModels);
        }

        // POST: DegreeQuestionsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "degreeQuestionID,degreeID,userID,question,answer")] DegreeQuestionsModels degreeQuestionsModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(degreeQuestionsModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Degrees", "Home");
            }
            return View(degreeQuestionsModels);
        }

        // GET: DegreeQuestionsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DegreeQuestionsModels degreeQuestionsModels = db.DegreeQuestions.Find(id);
            if (degreeQuestionsModels == null)
            {
                return HttpNotFound();
            }
            return View(degreeQuestionsModels);
        }

        // POST: DegreeQuestionsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DegreeQuestionsModels degreeQuestionsModels = db.DegreeQuestions.Find(id);
            db.DegreeQuestions.Remove(degreeQuestionsModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
