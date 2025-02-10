using BankApp.Models;

namespace BankApp.Services
{
    internal abstract class OperationsDer
    {
        protected readonly BankUser _user; // Accessible in derived classes

        protected OperationsDer(BankUser user)
        {
            _user = user;
        }

        protected void UpdateBalance(int amount)
        {
            _user.Balance += amount;
        }

        protected void AddTransaction(string transaction)
        {
            _user.TransactionHist.Add(transaction);
        }

        public void ShowTransactionHistory()
        {
            Console.WriteLine("\nTransaction History:");
            foreach (string transaction in _user.TransactionHist)
            {
                Console.WriteLine(transaction);
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Your current balance is: Rs.{_user.Balance}");
        }
    }
}
