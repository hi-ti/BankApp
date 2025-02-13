using BankApp.Models;

namespace BankApp.Services
{
    internal abstract class OperationsDer
    {
        protected BankUser? _user; // Single user object
        private readonly FileServices _fileService;
        private List<BankUser> _users; // Full user list from JSON

        protected OperationsDer(BankUser user)
        {
            _fileService = new FileServices();
            _users = _fileService.LoadUsers(); // Load all users from JSON

            // Find the specific user by Username
            _user = _users.FirstOrDefault(u => u.Username == user.Username);

            if (_user == null)
            {
                Console.WriteLine("User not found!");
            }
        }

        protected void UpdateBalance(int amount)
        {
            if (_user == null) return;

            _user.Balance += amount;
            try
            {
                SaveChanges();
                Console.WriteLine("\nBalance updated successfully!\n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFailed to update balance: {e.Message}\n");
            }
        }

        protected void AddTransaction(string transaction)
        {
            if (_user == null) return;

            //_user.TransactionHist.Add(transaction);
            try
            {
                SaveChanges();
                Console.WriteLine("\nTransaction added successfully!\n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFailed to add transaction: {e.Message}\n");
            }
        }

        //public void ShowTransactionHistory()
        //{
        //    if (_user == null) return;

        //    Console.WriteLine("\nTransaction History:");
        //    foreach (string transaction in _user.TransactionHist)
        //    {
        //        Console.WriteLine(transaction);
        //    }
        //}

        public void CheckBalance()
        {
            if (_user == null) return;

            Console.WriteLine($"Your current balance is: Rs.{_user.Balance}");
        }

        private void SaveChanges()
        {
            // Replace the updated user in the list by Username
            var index = _users.FindIndex(u => u.Username == _user.Username);
            if (index != -1)
            {
                _users[index] = _user; // Update the user in the list
                _fileService.SaveUsers(_users); // Save the entire list
            }
        }
    }
}
