using BankApp.Models;
using BankApp.Utils;
class CreateAccount
{
    // TaskDelay td = new TaskDelay();
    public async Task<BankUser?> CreateYourAccount()
    {
        // int balance = 0;
        Console.WriteLine("Hello! Welcome to ABC Bank.");

        await TaskDelay.Delay();

        Console.Write("Enter full name : ");
        string?name = Console.ReadLine();

        await TaskDelay.Delay();

        Console.Write("Please enter a valid 4-digit pin :");
        // int pin = Convert.ToInt32(Console.ReadLine());
        
        await TaskDelay.Delay();

        if (!int.TryParse(Console.ReadLine(), out int pin) || !Security.GetSecuredPin(pin))
        {
            Console.WriteLine("Invalid PIN! Account not created.");
            return null;
        }

        Console.Write("Enter your initial balance: Rs. ");
        if (!int.TryParse(Console.ReadLine(), out int balance))
        {
            Console.WriteLine("Invalid amount! Account not created.");
            return null;
        }

        Console.Write("Account successfully created!");
        BankUser b1 = new BankUser(name ?? "Unknown User", pin, balance);
        return b1;        

    }
}