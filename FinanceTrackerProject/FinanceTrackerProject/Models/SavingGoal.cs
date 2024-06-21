using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceTrackerProject.Models
{
    public class SavingGoal
    {
        public int SavingGoalId { get; set; }
        public decimal TargetAmount { get; set; }
        public DateTime TargetDate { get; set; }
        public decimal CurrentAmount { get; set; }
        public string UserId { get; set; }
    }
}