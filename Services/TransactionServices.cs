using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Models;

namespace BankApp.Services
{
    internal class TransactionServices
    {
        private readonly BankUser _user;
        //private readonly BankUser Pin;
        public TransactionServices(BankUser user) {
        _user = user;
        }

        public bool ValidatePin(int enteredPin) => _user.Pin == enteredPin;

        public void showTransactionHist()
        {
            Console.WriteLine("\nTransaction History:");
            foreach(string i in _user.TransactionHist) { 
            Console.WriteLine(i);
            }
        }

        public void AddTransaction(string transac)
        {
            _user.TransactionHist.Add(transac);
        }
        public void UpdateBalance(int amt)
        {
            _user.Balance += amt;
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Your current balance is : Rs.{_user.Balance}");
        }
        public async Task Deposit(int enteredPin, int amt)
        {
            if (ValidatePin(enteredPin) != true)
            {
                throw new UnauthorizedAccessException(message: "Invalid pin! Transaction cancelled.");
            }
            else if (amt < 0)
            {
                throw new ArgumentException(
                    "You must deposit an amount greater than zero"
                    );
            }
            await Task.Run(() =>
            {
                UpdateBalance(amt);
                AddTransaction($"Deposited Rs.${amt} | New balance : Rs.${_user.Balance}");
                Console.WriteLine($"Deposit Successful! Your new balance is Rs.${_user.Balance}");
            });
        }
        public async Task Withdrawal(int enteredPin, int amt)
        {
            if(ValidatePin(enteredPin) != true)
            {
                throw new UnauthorizedAccessException(message: "Invalid pin! Transaction cancelled.");
            }
            else if(amt < 0)
            {
                throw new ArgumentException("You must enter an amount greater than zero.");
            }
            await Task.Run(() => {
                UpdateBalance(-amt);
                AddTransaction($"Withdrawed Rs.${amt} | New Balance : Rs.${_user.Balance}");
                Console.WriteLine($"Withdrawal successful! Your new balance is ${_user.Balance}");
            });
        }

    }
}
