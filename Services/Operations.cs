namespace BankApp.Services
{
    public interface Operations
    {
        Task Deposit(int amount);
        Task Withdraw(int amount);
        void ShowTransactionHistory();
        void CheckBalance();
    }
}
