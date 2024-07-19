using PhoneBookWithFile.Models;

namespace PhoneBookWithFile.Services;

internal interface IFileService
{
    Contact AddContact(Contact contact);
    bool DeleteContact(string phoneNumber);
    List<string> ReadAllContacts();
}