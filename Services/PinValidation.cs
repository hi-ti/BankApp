using BankApp.Models;

namespace BankApp.Services
{
    class PinValidation
    {
        private readonly BankUser _user;

        public PinValidation(BankUser user)
        {
            _user = user;
        }

        public bool ValidatePin(int enteredPin)
        {
            return _user.Pin == enteredPin;
        }
    }
}
