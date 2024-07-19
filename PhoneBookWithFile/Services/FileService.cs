using PhoneBookWithFile.Models;

namespace PhoneBookWithFile.Services;

internal class FileService : IFileService
{
    private ILoggingService loggingService;
    private const string filePath = "../../../Contacts.txt";

    public FileService()
    {
        this.loggingService = new LoggingService();
        CreateFileIfNotExists();
    }

    private static void CreateFileIfNotExists()
    {
        var isFileExists = File.Exists(filePath);
        if (isFileExists is false)
        {
            File.Create(filePath).Close();

        }
    }

    public Contact AddContact(Contact contact)
    {
        var contents = new string[] { $"{contact.Name} : {contact.PhoneNumber}" };
        File.AppendAllLines(filePath, contents);


        return contact;
    }

    public bool DeleteContact(string phoneNumber)
    {
        var isThereContact = false;
        var contacts = File.ReadAllLines(filePath).ToList();
        foreach (var contact in contacts)
        {
            if (contact.Contains(phoneNumber))
            {
                isThereContact = true;
                contacts.Remove(contact);
                break;
            }
        }

        if (isThereContact is false)
        {
            return false;
        }

        File.WriteAllLines(filePath, contacts);

        return true;
    }

    public List<string> ReadAllContacts()
    {
        return File.ReadAllLines(filePath).ToList();
    }

}
