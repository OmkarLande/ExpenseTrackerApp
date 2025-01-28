namespace ExpenseTrackerApp
{
    public class UserInputHandler
    {
        public void mainMenu()
        {
            while (true)
            {
                Console.WriteLine("\nPlease choose an option:");
                Console.WriteLine("1. Create New User");
                Console.WriteLine("0. Exit");
                Console.Write("Your choice: ");

                string? choice = Console.ReadLine();


                if (choice == "1")
                {
                    User user1 = CreateUser();
                    if (user1 != null)
                    {
                        Console.WriteLine($"Welcome, {user1.UserName}!");
                        ExpenseTracker expenseTracker = new ExpenseTracker(user1);
                        expenseTracker.ExpenseMenu();
                    }
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

        public User CreateUser()
        {
            string userName = "";
            while (true)
            {
                Console.Write("Enter your username: ");
                userName = Console.ReadLine();
                if (!string.IsNullOrEmpty(userName))
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid category. Please try again.");
                Console.ResetColor();
            }
            Console.Write("Enter your password: ");
            string password = ReadPassword();

            User newUser = new User(userName, password);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"User {newUser.UserName} created successfully!");
            Console.ResetColor();

            return newUser;
        }

        private string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[0..^1]; // C# 8.0 syntax for removing last character
                    Console.Write("\b \b"); // Move back, print space, and move back again
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }

            if (password.Length < 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password must be at least 6 characters long.");
                Console.ResetColor();
                return ReadPassword();
            }

            Console.WriteLine(); // Move to next line

            return password;
        }
    }
}
