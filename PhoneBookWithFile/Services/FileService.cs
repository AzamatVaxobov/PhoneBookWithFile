using PhoneBookWithFile.Models;
using System.Text.Json;

namespace PhoneBookWithFile.Services;

internal class FileService : IFileService
{
    private ILoggingService loggingService;
    private const string filePath = "../../../Contacts.json";

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
        var jsonContact = JsonSerializer.Serialize(contact);
        var contents = new string[] { jsonContact };
        File.AppendAllLines(filePath, contents);

        return contact;
    }

    public bool DeleteContact(string phoneNumber)
    {
        var isThereContact = false;
        var contacts = ReadAllContacts();
        foreach (var contact in contacts)
        {
            if (contact.PhoneNumber == phoneNumber)
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

        var stringContacts = new List<string>();
        foreach (var contact in contacts)
        {
            var stringContact = JsonSerializer.Serialize(contact);
            stringContacts.Add(stringContact);
        }
        File.WriteAllLines(filePath, stringContacts);

        return true;
    }

    public List<Contact> ReadAllContacts()
    {
        var contacts = new List<Contact>();

        var jsonContacts = File.ReadAllLines(filePath);
        foreach (var jsonContact in jsonContacts)
        {
            var contact = JsonSerializer.Deserialize<Contact>(jsonContact);
            contacts.Add(contact);
        }

        return contacts;
    }

    
}
