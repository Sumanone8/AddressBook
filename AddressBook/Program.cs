using System;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Fellow Learners!\n--Welcome to Address Book Problem--");

            AddressBookSystem addressBookSystem = new AddressBookSystem();

            // Add a new Address Book using Console input
            Console.Write("Enter the name of the new Address Book: ");
            string newAddressBookName = Console.ReadLine();

            if (!string.IsNullOrEmpty(newAddressBookName))
            {
                if (!addressBookSystem.AddressBookExists(newAddressBookName))
                {
                    addressBookSystem.AddAddressBook(newAddressBookName);
                }
                else
                {
                    Console.WriteLine($"An Address Book with the name '{newAddressBookName}' already exists.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Address Book name. Please provide a non-empty name.");
            }

            AddressBook? addressBook = addressBookSystem.GetAddressBook(newAddressBookName);

            if (addressBook != null)
            {
                Contact newContact1 = new Contact("John", "Doe", "123 Main St", "Cityville", "Stateville", "12345", "123-456-7890", "john.doe@example.com");
                addressBook.AddContact(newContact1);

                Contact newContact2 = new Contact("Jane", "Smith", "456 Elm St", "Townville", "Stateville", "67890", "987-654-3210", "jane.smith@example.com");
                addressBook.AddContact(newContact2);
            }
            else
            {
                Console.WriteLine($"Address Book '{newAddressBookName}' not found.");
            }

            // Displaying all contacts in the address book
            DisplayAddressBook(addressBook);

            // Saving address book to a file
            string filePath = "addressbook.txt";
            addressBook.SaveToFile(filePath);
            Console.WriteLine("Address Book saved to file.");

            // Loading address book from a file
            addressBook.LoadFromFile(filePath);
            Console.WriteLine("Address Book loaded from file.");

            Console.WriteLine("Thank you for using the Address Book program!");
        }

        static void DisplayAddressBook(AddressBook? addressBook)
        {
            if (addressBook == null)
            {
                Console.WriteLine("Address Book not found.");
                return;
            }

            Console.WriteLine($"\nAddress Book '{addressBook.Name}' Entries:");
            foreach (Contact contact in addressBook.GetContacts())
            {
                Console.WriteLine(contact.ToString());
                Console.WriteLine();
            }
        }
    }
}
