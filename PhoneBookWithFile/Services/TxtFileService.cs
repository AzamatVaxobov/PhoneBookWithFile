using PhoneBookWithFile.Models;
using System.Text.Json;

namespace PhoneBookWithFile.Services;

public class TxtFileService : IFileService
{
    private readonly ILoggingService loggingService;
    private const string filePath = "../../../Contacts.txt";

    public TxtFileService()
    {
        this.loggingService = new LoggingService();
        CreateFileIfNotExists();
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
        var contacts = File.ReadAllLines(filePath).ToList();
        foreach (var contact in contacts)
        {
            if (contact.Contains(phoneNumber))
            {
                isThereContact = true;
                contacts.Remove(contact);
            }
        }

        if(isThereContact is false)
        {
            return false;
        }

        File.WriteAllLines(filePath, contacts);
        
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

    private static void CreateFileIfNotExists()
    {
        var isFileExists = File.Exists(filePath);
        if (isFileExists is false)
        {
            File.Create(filePath).Close();
        }
    }
}