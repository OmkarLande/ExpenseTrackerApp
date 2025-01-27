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

                string? choice = Console.ReadLine(); //'?' is there bcoz it can be null


                if (choice == "1")
                {
                    User user1 = CreateUser();
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        public User CreateUser()
        {
            Console.Write("Enter your username: ");
            string userName = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            User newUser = new User(userName, password);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"User {newUser.UserName} created successfully!");
            Console.ResetColor();

            return newUser;
        }

    }
}
