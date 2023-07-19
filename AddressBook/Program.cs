using System;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Fellow Learners!\n--Welcome to Address Book Problem--");

            AddressBookManager addressBookManager = new AddressBookManager();

            // Creating a new Contact and adding it to the Address Book
            Contact newContact = new Contact("John", "Doe", "123 Main St", "Cityville", "Stateville", "12345", "123-456-7890", "john.doe@example.com");
            addressBookManager.AddContact(newContact);

            // Displaying all contacts in the address book
            DisplayAddressBook(addressBookManager);

            // Edit an existing contact by name
            Console.Write("Enter the first name of the contact you want to edit: ");
            string firstNameToEdit = Console.ReadLine() ?? ""; // Use "" as the default value if the input is null
            Console.Write("Enter the last name of the contact you want to edit: ");
            string lastNameToEdit = Console.ReadLine() ?? ""; // Use "" as the default value if the input is null

            Contact? contactToEdit = addressBookManager.GetContactByName(firstNameToEdit, lastNameToEdit);
            if (contactToEdit != null)
            {
                Console.WriteLine("\nEnter the updated details:");

                Console.Write("First Name: ");
                contactToEdit.FirstName = Console.ReadLine() ?? ""; // Use "" as the default value if the input is null

                Console.Write("Last Name: ");
                contactToEdit.LastName = Console.ReadLine() ?? ""; // Use "" as the default value if the input is null

                Console.Write("Address: ");
                contactToEdit.Address = Console.ReadLine() ?? ""; // Use "" as the default value if the input is null

                Console.Write("City: ");
                contactToEdit.City = Console.ReadLine() ?? ""; // Use "" as the default value if the input is null

                Console.Write("State: ");
                contactToEdit.State = Console.ReadLine() ?? ""; // Use "" as the default value if the input is null

                Console.Write("Zip Code: ");
                contactToEdit.ZipCode = Console.ReadLine() ?? ""; // Use "" as the default value if the input is null

                Console.Write("Phone: ");
                contactToEdit.PhoneNumber = Console.ReadLine() ?? ""; // Use "" as the default value if the input is null

                Console.Write("Email: ");
                contactToEdit.Email = Console.ReadLine() ?? ""; // Use "" as the default value if the input is null

                Console.WriteLine("Contact updated successfully!");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }

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
