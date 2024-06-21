using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinanceTrackerProject.Models;
using Microsoft.AspNet.Identity;

namespace FinanceTrackerProject.Controllers
{
    public class TransactionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var transactions = db.Transactions.Where(t => t.UserId == userId).ToList();
            return View(transactions);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                transaction.UserId = User.Identity.GetUserId();
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }


        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction != null)
            {
                db.Transactions.Remove(transaction);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public ActionResult ProfitLoss()
        {
            var userId = User.Identity.GetUserId();
            var transactions = db.Transactions.Where(t => t.UserId == userId).ToList();

            var labels = transactions.Select(t => t.Date.ToString("MMM yyyy")).Distinct().ToList();
            var data = new List<decimal>();

            foreach (var label in labels)
            {
                var monthlyTransactions = transactions.Where(t => t.Date.ToString("MMM yyyy") == label);
                var monthlyTotal = monthlyTransactions.Sum(t => t.Type == "Income" ? t.Amount : -t.Amount);
                data.Add(monthlyTotal);
            }

            ViewBag.Labels = Newtonsoft.Json.JsonConvert.SerializeObject(labels);
            ViewBag.Data = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            return View();
        }

        public decimal GetProfitLoss()
        {
            var userId = User.Identity.GetUserId();
            var transactions = db.Transactions.Where(t => t.UserId == userId).ToList();

            decimal totalIncome = transactions.Where(t => t.Type == "Income").Sum(t => t.Amount);
            decimal totalExpense = transactions.Where(t => t.Type == "Expense").Sum(t => t.Amount);

            return totalIncome - totalExpense;
        }
    }
}