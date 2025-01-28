namespace ExpenseTrackerApp
{
    public class ExpenseTracker
    {
        public User User { get; set; }
        public ExpenseTracker(User user)
        {
            User = user;
        }

        public void ExpenseMenu()
        {
            while (true)
            {
                Console.WriteLine("\nPlease choose an option:");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. Show Categories");
                Console.WriteLine("3. View Expenses");
                Console.WriteLine("4. View Balance");
                Console.WriteLine("0. Exit");
                Console.Write("Your choice: ");
                string? choice = Console.ReadLine();
                if (choice == "1")
                {
                    AddExpense();
                }
                else if (choice == "2")
                {
                    foreach (var category in Enum.GetValues(typeof(ExpenseCategory)))
                    {
                        Console.WriteLine($"{(int)category}. {category}");
                    }

                }
                else if (choice == "3")
                {
                    User.TrackHistory();
                }
                else if (choice == "4")
                {
                    Console.WriteLine($"Your current balance is: {User.Balance:C}");
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ResetColor();
                }
            }
        }

        public void AddExpense()
        {
            string name = "";
            while (true)
            {
                Console.Write("Enter name of Expense: ");
                name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    break; // Valid category, exit the loop
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid category. Please try again.");
                Console.ResetColor();
            }

            // Display valid categories
            Console.WriteLine("Available categories:");
            foreach (var category in Enum.GetValues(typeof(ExpenseCategory)))
            {
                Console.WriteLine($"{(int)category}. {category}");
            }

            // Get category input with validation
            ExpenseCategory processedCategory;
            while (true)
            {
                Console.Write("Enter category: ");
                string categoryInput = Console.ReadLine();
                if (Enum.TryParse<ExpenseCategory>(categoryInput, true, out processedCategory))
                {
                    break; // Valid category, exit the loop
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid category. Please try again.");
                    Console.ResetColor();
                }
            }

            // Get amount input with validation
            decimal amount;
            while (true)
            {
                Console.Write("Enter the amount: ");
                string amountInput = Console.ReadLine();
                if (decimal.TryParse(amountInput, out amount) && amount > 0)
                {
                    break; // Valid amount, exit the loop
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid amount. Please enter a positive number.");
                    Console.ResetColor();
                }
            }

            // Get date input with validation
            DateTime date;
            while (true)
            {
                Console.Write("Enter the date (yyyy-mm-dd): ");
                string dateInput = Console.ReadLine();
                if (DateTime.TryParse(dateInput, out date))
                {
                    break; // Valid date, exit the loop
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid date format. Please try again.");
                    Console.ResetColor();
                }
            }

            // Get loss input
            bool isLoss;
            while (true)
            {
                Console.Write("Is this a loss? (y/n): ");
                string lossInput = Console.ReadLine().ToLower();
                if (lossInput == "y")
                {
                    isLoss = true;
                    break;
                }
                else if (lossInput == "n")
                {
                    isLoss = false;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                    Console.ResetColor();
                }
            }

            // Create and add the expense
            Expense expense = new Expense(name, processedCategory, amount, date, isLoss);
            User.AddExpense(expense);

            Console.ForegroundColor = isLoss ? ConsoleColor.Red : ConsoleColor.Green;
            Console.WriteLine($"Expense added successfully: {name} | Category: {processedCategory} | {amount:C} on {date}.");
            Console.ResetColor();
        }

    }
}
