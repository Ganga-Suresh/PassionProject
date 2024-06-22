using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceTrackerProject.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // Income or Expense
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}