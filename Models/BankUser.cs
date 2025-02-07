using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    internal class BankUser
    {
        public string FullName { get; private set; }
        public int Pin {get; private set;}
        public int Balance { get; set; }
        public List<string> TransactionHist;

        public BankUser(string fullName, int pin, int initialBalance)
        {

            FullName = fullName;
            Pin = pin;
            Balance = initialBalance;
            TransactionHist = new List<string>
            {$"Account created with initial balance ${initialBalance}"};
        }
    }
}
