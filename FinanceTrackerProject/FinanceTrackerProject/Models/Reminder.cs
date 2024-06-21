using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinanceTrackerProject.Models
{
    public class Reminder
    {
        [Key]
        public int ReminderId { get; set; }

        [Required]
        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsPaid { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}