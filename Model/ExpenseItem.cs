﻿namespace MyExpenseTracker.Model
{
    public class ExpenseItem
    {
        public int Id { get; set; }
        public string Name { get; set; }                             
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
