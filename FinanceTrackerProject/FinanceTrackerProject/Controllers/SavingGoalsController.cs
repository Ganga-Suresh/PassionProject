using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinanceTrackerProject.Models;
using Microsoft.AspNet.Identity;

namespace FinanceTrackerProject.Controllers
{
    public class SavingGoalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var goals = db.SavingGoals.Where(g => g.UserId == userId).ToList();
            return View(goals);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SavingGoal goal)
        {
            if (ModelState.IsValid)
            {
                goal.UserId = User.Identity.GetUserId();
                db.SavingGoals.Add(goal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goal);
        }
    }
}