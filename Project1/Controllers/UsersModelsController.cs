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
using System.Web.Security;

namespace Project1.Controllers
{
    public class UsersModelsController : Controller
    {
        private FAQContext db = new FAQContext();

        // GET: UsersModels
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: UsersModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersModels usersModels = db.Users.Find(id);
            if (usersModels == null)
            {
                return HttpNotFound();
            }
            return View(usersModels);
        }

        // GET: UsersModels/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: UsersModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "userID,userEmail,password,firstName,lastName")] UsersModels usersModels, bool rememberMe = false)
        {
            if (ModelState.IsValid)
            {
                string userEmail2 = usersModels.userEmail.ToString();
                db.Users.Add(usersModels);
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(userEmail2, rememberMe);
                return RedirectToAction("Index", "Home");
            }

            return View(usersModels);
        }

        // GET: UsersModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersModels usersModels = db.Users.Find(id);
            if (usersModels == null)
            {
                return HttpNotFound();
            }
            return View(usersModels);
        }

        // POST: UsersModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,userEmail,password,firstName,lastName")] UsersModels usersModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usersModels);
        }

        // GET: UsersModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersModels usersModels = db.Users.Find(id);
            if (usersModels == null)
            {
                return HttpNotFound();
            }
            return View(usersModels);
        }

        // POST: UsersModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersModels usersModels = db.Users.Find(id);
            db.Users.Remove(usersModels);
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
