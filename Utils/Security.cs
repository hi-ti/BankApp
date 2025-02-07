using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using BankApp.Models;

namespace BankApp.Utils
{
    internal class Security
    {
        public static void GetSecuredPin(int input)
        {
            // while (true)
            // {
                
                if (input >= 1000 && input <= 9999)
                {
                    Console.WriteLine("PIN created successfully!");
                    return;
                }

                Console.WriteLine("Invalid PIN! Please enter a valid 4-digit number.");
            // }
        }


    }
}
