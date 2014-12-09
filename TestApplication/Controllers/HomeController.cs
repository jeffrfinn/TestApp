using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class HomeController : Controller
    {
        private TESTEntities db = new TESTEntities();

        // GET: Surveys
        public ActionResult Index()
        {
            var surveys = db.Surveys.Include(s => s.Question).Include(s => s.User);
            return View(surveys.ToList());
        }

        // GET: Surveys/Create
        public ActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(db.Questions, "QuesionId", "QuestionText");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Name");
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuerveyId,UserId,QuestionId,Answer,Comment")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Surveys.Add(survey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionId = new SelectList(db.Questions, "QuesionId", "QuestionText", survey.QuestionId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Name", survey.UserId);
            return View(survey);
        }
    }
}