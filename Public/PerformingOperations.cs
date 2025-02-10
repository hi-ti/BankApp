using System.Threading.Tasks;
using BankApp.Services;

class PerformingOperations
{
    public async Task Perform(string choice, TransactionService ts)
    {
        try
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Please enter the amount you want to Deposit : Rs.");
                        int amt = Convert.ToInt32(Console.ReadLine());
                        await ts.Deposit(amt);
                        break;

                    case "2":
                        Console.WriteLine("Please enter the amount you want to Withdraw: Rs.");
                        int amount = Convert.ToInt32(Console.ReadLine());
                        await ts.Withdraw(amount);
                        break;
                    case "3":
                        ts.CheckBalance();
                        break;
                    case "4":
                        ts.ShowTransactionHistory();
                        break;
                    default:
                        Console.WriteLine("Thank you.");
                        break;
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString()); 
            }        
    }
}