using BankApp.Models;

namespace BankApp.Services
{
    public class Authentication
    {
        private readonly FileServices _fs;
        private List<BankUser> _users;

        public Authentication()
        {
            _fs = new FileServices();
            _users = _fs.LoadUsers();
        }

        public BankUser Register(string name, int pin, int balance)
        {
            if (_users.Any(u => u.Username == name))
            {
                throw new Exception("Username exists, kindly login...");
            }

            BankUser user = new BankUser()
            { Username = name, Pin = pin, Balance = balance };
            _users.Add(user);
            _fs.SaveUsers(_users);

            return user;
        }

        public BankUser? Login(string name, int pin)
        {
            var user = _users.FirstOrDefault(u => u.Username == name && u.Pin == pin);
            Console.Write(user + "\n login method ki line \n");
            if (user == null)
            {
                Console.WriteLine("\nInvalid username or PIN.");
                return null;
            }
            return user;
        }
    }
}