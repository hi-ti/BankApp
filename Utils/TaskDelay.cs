namespace BankApp.Utils
{
    class TaskDelay
    {
        async public static Task Delay()
    {
        await Task.Delay(1000);
    }
    }
}

