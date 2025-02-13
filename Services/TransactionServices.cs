﻿using BankApp.Models;

namespace BankApp.Services
{
    internal class TransactionService : OperationsDer
    {
        private readonly PinValidation _pinValidator;

        public TransactionService(BankUser user) : base(user)
        {
            _pinValidator = new PinValidation(user);
        }

        public async Task Deposit(int amount)
        {
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Deposit amount must be greater than zero.");
                }

                await Task.Run(() =>
                {
                    UpdateBalance(amount);
                    AddTransaction($"Deposited Rs.{amount} | New balance: Rs.{_user.Balance}");
                    Console.WriteLine($"Deposit Successful! New balance: Rs.{_user.Balance}");
                    return;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task Withdraw(int amount)
        {
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Withdrawal amount must be greater than zero.");
                }
                else if (amount > _user.Balance)
                {
                    throw new InvalidOperationException("Insufficient funds.");
                }

                await Task.Run(() =>
                {
                    UpdateBalance(-amount);
                    AddTransaction($"Withdrew Rs.{amount} | New Balance: Rs.{_user.Balance}");
                    Console.WriteLine($"Withdrawal successful! New balance: Rs.{_user.Balance}");
                    return;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}