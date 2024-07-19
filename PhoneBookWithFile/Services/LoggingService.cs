namespace PhoneBookWithFile.Services;

internal class LoggingService : ILoggingService
{
    public void LoggerMenu()
    {
        Console.WriteLine("what do you want to do");
        Console.WriteLine("1. Add a contact");
        Console.WriteLine("2. Remove a contact");
        Console.WriteLine("3. Show all contact");
        Console.WriteLine("4. Exit ");
    }
    
    public void LogInformation(string message)
    {
        Console.WriteLine(message);
    }
}
