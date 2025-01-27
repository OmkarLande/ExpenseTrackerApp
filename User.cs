namespace ExpenseTrackerApp
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public List<Expense> Expenses { get; set; }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
            Balance = 0;
            Expenses = new List<Expense>();

        }
        public void TrackHistory()
        {
            foreach (var expense in Expenses)
            {
                Console.ForegroundColor = expense.IsLoss ? ConsoleColor.Red : ConsoleColor.Green;
                string transactionType = expense.IsLoss ? "Debited" : "Credited";
                Console.WriteLine($"{transactionType}: {expense.Name} | Category: {expense.Category} | {expense.Amount:C} on {expense.Date}.");
                Console.ResetColor();
            }
        }
        public void AddExpense(Expense expense)
        {
            Expenses.Add(expense);
            Balance += expense.IsLoss ? -expense.Amount : expense.Amount;
        }

    }
}
