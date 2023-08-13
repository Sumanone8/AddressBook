using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq;

namespace AddressBook
{
    class AddressBookSystem
    {
        private Dictionary<string, AddressBook> addressBooks;

        public AddressBookSystem()
        {
            addressBooks = new Dictionary<string, AddressBook>();
        }

        public void AddAddressBook(string name)
        {
            if (!addressBooks.ContainsKey(name))
            {
                AddressBook addressBook = new AddressBook(name);
                addressBooks.Add(name, addressBook);
                Console.WriteLine($"Address Book '{name}' created successfully!");
            }
            else
            {
                Console.WriteLine($"An Address Book with the name '{name}' already exists.");
            }
        }

        public bool AddressBookExists(string name)
        {
            return addressBooks.ContainsKey(name);
        }

        public AddressBook GetAddressBook(string name)
        {
            if (addressBooks.TryGetValue(name, out AddressBook addressBook))
            {
                return addressBook;
            }
            return null;
        }

        public List<AddressBook> GetAddressBooks()
        {
            return addressBooks.Values.ToList();
        }

        public void SaveToCsv(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
            {
                var allContacts = addressBooks.Values.SelectMany(ab => ab.GetContacts());
                csv.WriteRecords(allContacts);
            }
        }

        public void LoadFromCsv(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
            {
                var contacts = csv.GetRecords<Contact>().ToList();
                addressBooks.Clear();
                foreach (var contact in contacts)
                {
                    if (!addressBooks.ContainsKey(contact.AddressBookName))
                    {
                        addressBooks.Add(contact.AddressBookName, new AddressBook(contact.AddressBookName));
                    }
                    addressBooks[contact.AddressBookName].AddContact(contact);
                }
            }
        }
    }
}
