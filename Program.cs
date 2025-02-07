using BankApp.Models;
using BankApp.Services;
using BankApp.Utils;

class Program
{
    async static Task Main(string[] args)
    {
        Console.WriteLine("Welcome to ABC Bank");

        await Task.Delay(1000);

        Console.WriteLine("Enter full name : ");
        string name = Console.ReadLine();

        await Task.Delay(1000);

        //Security Security = new Security();

        // bool pinValid = false;

        Console.WriteLine("Set a 4-digit secure pin");
        int pin = Convert.ToInt32(Console.ReadLine());
        Security.GetSecuredPin(pin);

        //security.GetSecuredPin();

        await Task.Delay(1000);

        Console.WriteLine("Enter your initial balance : Rs.");
        int balance = Convert.ToInt32(Console.ReadLine());

        await Task.Delay(1000);

        BankUser b1 = new BankUser(name, pin, balance);
        TransactionServices ts1 = new TransactionServices(b1);

        Console.WriteLine("Welcome onboard! Your account has been successfully created.");

        // await Task.Delay(3000);

        bool exit = false;

        while (!exit)
        {
            await Task.Delay(3000);
            Console.WriteLine("\nPlease select a service (please mention only number) : " +
            "\n1. Deposit an amount" +
            "\n2. Withdraw an amount" +
            "\n3. Check Balance" +
            "\n4. See transaction history" +
            "\n5. Exit");
            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Please enter your pin first :");
                        int enterPin = Convert.ToInt32(Console.ReadLine());
                        ts1.ValidatePin(enterPin);
                        Console.WriteLine("Please enter the amount you want to Deposit : Rs.");
                        int amt = Convert.ToInt32(Console.ReadLine());
                        await ts1.Deposit(enterPin, amt);
                        break;

                    case "2":
                        Console.WriteLine("Please enter your pin first :");
                        int enteredPin = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please enter the amount you want to Withdraw: Rs.");
                        int amount = Convert.ToInt32(Console.ReadLine());
                        await ts1.Withdrawal(enteredPin, amount);
                        break;
                    case "3":
                        ts1.CheckBalance();
                        break;
                    case "4":
                        ts1.showTransactionHist();
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("Thank you for choosing us.");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
    }
}