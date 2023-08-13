using System;
using System.Collections.Generic;

namespace AddressBook
{
    class DisplayViewResults
    {
        public static void DisplayViewResult(List<Contact> viewResults)
        {
            if (viewResults.Count > 0)
            {
                Console.WriteLine("\nView Results:");
                foreach (Contact contact in viewResults)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Address: {contact.Address}");
                    Console.WriteLine($"City: {contact.City}");
                    Console.WriteLine($"State: {contact.State}");
                    Console.WriteLine($"Zip Code: {contact.ZipCode}");
                    Console.WriteLine($"Phone: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No matching contacts found.");
            }
        }
    }
}
