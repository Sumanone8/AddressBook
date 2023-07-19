using System;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Fellow Learners!\n--Welcome to Address Book Problem--");

            AddressBookManager addressBookManager = new AddressBookManager();

            // Creating multiple contacts and adding them to the Address Book
            Contact newContact1 = new Contact("John", "Doe", "123 Main St", "Cityville", "Stateville", "12345", "123-456-7890", "john.doe@example.com");
            addressBookManager.AddContact(newContact1);

            Contact newContact2 = new Contact("Jane", "Smith", "456 Elm St", "Townville", "Stateville", "67890", "987-654-3210", "jane.smith@example.com");
            addressBookManager.AddContact(newContact2);

            Contact newContact3 = new Contact("Michael", "Johnson", "789 Oak Ave", "Villageville", "Stateville", "45678", "567-890-1234", "michael.johnson@example.com");
            addressBookManager.AddContact(newContact3);

            // Displaying all contacts in the address book
            DisplayAddressBook(addressBookManager);

            // Delete a person using their name
            Console.Write("Enter the first name of the person you want to delete: ");
            string firstNameToDelete = Console.ReadLine() ?? ""; // Use "" as the default value if the input is null

            Console.Write("Enter the last name of the person you want to delete: ");
            string lastNameToDelete = Console.ReadLine() ?? ""; // Use "" as the default value if the input is null

            addressBookManager.DeleteContactByName(firstNameToDelete, lastNameToDelete);

            // Display the updated address book
            DisplayAddressBook(addressBookManager);

            Console.WriteLine("Thank you for using the Address Book program!");
        }

        static void DisplayAddressBook(AddressBookManager addressBookManager)
        {
            var addressBook = addressBookManager.GetAddressBook();

            Console.WriteLine("\nAddress Book Entries:");
            foreach (Contact contact in addressBook)
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
    }
}