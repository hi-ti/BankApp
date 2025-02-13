using BankApp.Models;
using BankApp.Services;
using BankApp.Utils;

class Program
{
    //public BankUser user;
    async static Task Main(string[] args)
    {
        Console.WriteLine("\n Welcome to ABC Bank! \n");
        Console.WriteLine("\n Please select an option : \n 1. Register \n 2. Login");
        string? i = Console.ReadLine();
        if (i == "1")
        {
            Console.Write("Enter full name : ");
            string? name = Console.ReadLine();

            Console.Write("Please enter a valid 4-digit pin :");

            if (!int.TryParse(Console.ReadLine(), out int pin) || !Security.GetSecuredPin(pin))
            {
                Console.WriteLine("Invalid PIN! Account not created.");
            }

            Console.Write("Enter your initial balance: Rs. ");
            if (!int.TryParse(Console.ReadLine(), out int balance))
            {
                Console.WriteLine("Invalid amount! Account not created.");
            }
            BankUser user = new BankUser()
            { Username = name, Pin = pin, Balance = balance };
            if (user == null)
            {
                Console.WriteLine("Failed to create an account. Exiting...");
                return;
            }

            new Authentication().Register(name, pin, balance);

            Console.Write("Account successfully created! \n Please login again to continue...\n Exiting...");
            return;
        }
        else if (i == "2")
        {
            Console.WriteLine("Please enter your name");
            string? name = Console.ReadLine();
            Console.WriteLine("Please enter your pin : ");
            int pin = Convert.ToInt32(Console.ReadLine());

            BankUser user = new Authentication().Login(name, pin);

            if (user == null)
            {
                Console.WriteLine("Failed to login. Exiting...");
                return;
            }

            TransactionService ts = new TransactionService(user);

            Console.WriteLine("Welcome onboard! Your account has been successfully created.");

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nPlease select a service (please mention only number) : " +
                "\n1. Deposit an amount" +
                "\n2. Withdraw an amount" +
                "\n3. Check Balance" +
                "\n4. See transaction history" +
                "\n5. Exit");
                string? choice = Console.ReadLine();

                if (choice == "5")
                {
                    Console.Write("Thank you for choosing us.");
                    break;
                }
                else if (choice == "1" || choice == "2" || choice == "3" || choice == "4")
                {
                    PerformingOperations per = new PerformingOperations();
                    await per.Perform(choice ?? "5", ts);
                }
                else
                {
                    Console.Write("Please type a valid number");
                }
            }
        }
    }
}