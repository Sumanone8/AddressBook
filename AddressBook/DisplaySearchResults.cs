using AddressBook;

static void DisplaySearchResults(List<Contact> searchResults)
{
    if (searchResults.Count > 0)
    {
        Console.WriteLine("\nSearch Results:");
        foreach (Contact contact in searchResults)
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
