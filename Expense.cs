namespace ExpenseTrackerApp
{
    public class Expense
    {
        public string Name { get; set; }
        public ExpenseCategory Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsLoss { get; set; }

        public Expense(string name, ExpenseCategory category, decimal amount, DateTime date, bool isLoss)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative.", nameof(amount));

            if(!Enum.IsDefined(typeof(ExpenseCategory), category))
                throw new ArgumentException("Invalid category.", nameof(category));
            
            if(date > DateTime.Now)
                throw new ArgumentException("Date cannot be in the future.", nameof(date));

            Name = name;
            Category = category;
            Amount = amount;
            Date = date;
            IsLoss = isLoss;
        }
    }
}
