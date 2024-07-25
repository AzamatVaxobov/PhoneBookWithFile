using PhoneBookWithFile.Models;

namespace PhoneBookWithFile.Services;

public class TxtFileService : IFileService
{
  private ILoggingService loggingService;
  private const string FilePath = "../../../Contacts.txt";
  
  public TxtFileService()
  {
    this.loggingService = new LoggingService();
    CreateFileIfNotExists();
  }
  
  public Contact AddContact(Contact contact)
  {
    File.AppendAllText(FilePath, contact.Name + "\t: " + contact.PhoneNumber + Environment.NewLine);
    return contact;
  }

  public bool DeleteContact(string phoneNumber)
  {
    throw new NotImplementedException();
  }

  public List<Contact> ReadAllContacts()
  {
    throw new NotImplementedException();
  }
  
  private static void CreateFileIfNotExists()
  {
    var isFileExists = File.Exists(FilePath);
    if (isFileExists is false)
    {
      File.Create(FilePath).Close();
    }
  }
}