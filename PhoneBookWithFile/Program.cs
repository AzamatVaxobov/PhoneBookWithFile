﻿using PhoneBookWithFile.Models;
using PhoneBookWithFile.Services;

namespace PhoneBookWithFile
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IFileService fileService;
            ILoggingService logService = new LoggingService();
            logService.LogInformation("Choose file type: 0-JSON, 1-TXT");
            Console.Write("Enter :");
            string fileType = Console.ReadLine();
            
            if (fileType == "0")
            {
                fileService = new FileService();
            }
            else
            {
                fileService = new TxtFileService();
            }
            

            while (true)
            {
                Console.Clear();
                logService.LoggerMenu();
                Console.Write("Enter : ");
                var option = Console.ReadLine();

                if (option == "1")
                {
                    var contact = new Contact();
                    logService.LogInformation("Enter name : ");
                    contact.Name = Console.ReadLine();
                    logService.LogInformation("Enter phone number : ");
                    contact.PhoneNumber = Console.ReadLine();
                    fileService.AddContact(contact);
                }
                else if (option == "2")
                {
                    logService.LogInformation("Enter phone number to delete : ");
                    var phoneNumber = Console.ReadLine();
                    var result = fileService.DeleteContact(phoneNumber);
                    if (result is true)
                    {
                        logService.LogInformation("Successfully deleted ");
                    }
                    else
                    {
                        logService.LogInformation("No contact delete ");
                    }

                }
                else if (option == "3")
                {
                    var contacts = fileService.ReadAllContacts();
                    foreach ( var contact in contacts )
                    {
                        logService.LogInformation(contact.Name + "\t: " + contact.PhoneNumber);
                    }
                }
                else if (option == "4")
                {
                    logService.LogInformation("Thanks for using app");
                    break;
                }
                Console.ReadKey();
            }

        }
    }
}
