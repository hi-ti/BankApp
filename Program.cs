using System.Xml.Serialization;
using BankApp.Models;
using BankApp.Services;
using BankApp.Utils;

class Program
{
    async static Task Main(string[] args)
    {
        CreateAccount ca = new CreateAccount();
        BankUser? user = await ca.CreateYourAccount();

        if (user == null)
        {
            Console.WriteLine("Failed to create an account. Exiting...");
            return;
        }

        TransactionService ts = new TransactionService(user);

        Console.WriteLine("Welcome onboard! Your account has been successfully created.");

        bool exit = false;

        while (!exit)
        {
            await TaskDelay.Delay();
            Console.WriteLine("\nPlease select a service (please mention only number) : " +
            "\n1. Deposit an amount" +
            "\n2. Withdraw an amount" +
            "\n3. Check Balance" +
            "\n4. See transaction history" +
            "\n5. Exit");
            string? choice = Console.ReadLine();

            if(choice == "5")
            {
                Console.Write("Thank you for choosing us.");
                break;
            }
            else if(choice == "1" || choice == "2" || choice == "3" || choice =="4")
            {
                Console.Write("Please confirm your pin first : ");
                int confirmPin = Convert.ToInt32(Console.ReadLine());
                PinValidation p = new PinValidation(user);
                PerformingOperations per = new PerformingOperations();
                if(p.ValidatePin(confirmPin)) 
                {
                await per.Perform(choice ?? "5", ts);
                }
                else if(!p.ValidatePin(confirmPin)){
                Console.Write("Wrong Pin entered.");
                }
            }
            else{
                Console.Write("Please type a valid number");
            }
        }
    }
}