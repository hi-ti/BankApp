namespace BankApp.Utils
{
    internal class Security
    {
        public static bool GetSecuredPin(int pin)
        {
            try 
            {
                if(pin > 999 && pin < 10000)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // Console.Write("Invalid pin. User not created");
            }
            return false;
        }


    }
}
