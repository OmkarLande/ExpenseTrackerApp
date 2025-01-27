namespace ExpenseTrackerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            WelcomeMessage();

            try
            {
                UserInputHandler userInputHandler = new UserInputHandler();

                userInputHandler.mainMenu();

            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        static void WelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("**************************************************");
            Console.WriteLine("*                                                *");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*         WELCOME TO EXPENSE TRACKER             *");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*                                                *");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*   Manage your finances with ease and style!    *");
            Console.WriteLine("*   Track your expenses, monitor your balance,   *");
            Console.WriteLine("*   and gain insights into your spending habits. *");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*                                                *");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*          Let's take control of your            *");
            Console.WriteLine("*              financial journey today!          *");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*                                                *");
            Console.WriteLine("**************************************************");
            Console.ResetColor();
        }



    }
}
