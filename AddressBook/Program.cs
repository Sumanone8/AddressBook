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
            string newAddressBookName = Console.ReadLine()!;

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

            // Creating contacts and adding them to the Address Book
            AddressBook? addressBook = addressBookSystem.GetAddressBook(newAddressBookName);
            if (addressBook != null)
            {
                Contact newContact1 = new Contact(
                    firstName: "John",
                    lastName: "Doe",
                    address: "123 Main St",
                    city: "Cityville",
                    state: "Stateville",
                    zipCode: "12345",
                    phoneNumber: "123-456-7890",
                    email: "john.doe@example.com"
                );
                addressBook!.AddContact(newContact1);

                Contact newContact2 = new Contact(
                    firstName: "Jane",
                    lastName: "Smith",
                    address: "456 Elm St",
                    city: "Townville",
                    state: "Stateville",
                    zipCode: "67890",
                    phoneNumber: "987-654-3210",
                    email: "jane.smith@example.com"
                );
                addressBook!.AddContact(newContact2);
            }
            else
            {
                Console.WriteLine($"Address Book '{newAddressBookName}' not found.");
            }

            // Displaying all contacts in the address book
            DisplayAddressBook(addressBook);

            // Search and view contacts by city or state
            Console.WriteLine("\nSearch Contacts by City: ");
            string searchCity = Console.ReadLine();
            var citySearchResults = addressBookSystem.SearchContactsByCity(searchCity);
            DisplaySearchResults(citySearchResults);

            Console.WriteLine("\nSearch Contacts by State: ");
            string searchState = Console.ReadLine();
            var stateSearchResults = addressBookSystem.SearchContactsByState(searchState);
            DisplaySearchResults(stateSearchResults);

            Console.WriteLine("Thank you for using the Address Book program!");
        }

        static void DisplayAddressBook(AddressBook? addressBook)
        {
            // Displaying existing address book entries as before
        }

        static void DisplaySearchResults(List<Contact> searchResults)
        {
            // Displaying search results as before
        }
    }
}
