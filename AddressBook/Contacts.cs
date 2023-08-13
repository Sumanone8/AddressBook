using CsvHelper.Configuration.Attributes;

namespace AddressBook
{
    class Contact
    {
        [Name("First Name")]
        public string FirstName { get; set; }

        [Name("Last Name")]
        public string LastName { get; set; }

        [Name("Address")]
        public string Address { get; set; }

        [Name("City")]
        public string City { get; set; }

        [Name("State")]
        public string State { get; set; }

        [Name("Zip Code")]
        public string ZipCode { get; set; }

        [Name("Phone Number")]
        public string PhoneNumber { get; set; }

        [Name("Email")]
        public string Email { get; set; }

        [Ignore]
        public string AddressBookName { get; set; }

        public Contact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNumber, string email, string addressBookName)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
            PhoneNumber = phoneNumber;
            Email = email;
            AddressBookName = addressBookName;
        }

        public Contact()
        {
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}\n" +
                   $"Address: {Address}\n" +
                   $"City: {City}\n" +
                   $"State: {State}\n" +
                   $"Zip Code: {ZipCode}\n" +
                   $"Phone: {PhoneNumber}\n" +
                   $"Email: {Email}\n" +
                   $"Address Book: {AddressBookName}";
        }
    }
}
