using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinanceTrackerProject.Models
{
    public class SavingGoal
    {
        public int SavingGoalId { get; set; }

        [Required]
        [Display(Name = "Target Amount")]
        public decimal TargetAmount { get; set; }

        [Required]
        [Display(Name = "Target Date")]
        public DateTime TargetDate { get; set; }

        [Display(Name = "Current Amount")]
        public decimal CurrentAmount { get; set; }

        public string UserId { get; set; }
    }
}
