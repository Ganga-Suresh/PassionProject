using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace FinanceTrackerProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Home/Transactions
        public ActionResult Transactions()
        {
            return View();
        }

        // GET: /Home/SavingGoals
        public ActionResult SavingGoals()
        {

            return View();
        }

        // GET: /Home/Reminders
        public ActionResult Reminders()
        {
            return View();
        }

        // GET: /Home/Register
        public ActionResult Register()
        {
            return View();
        }
    }
}