using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook
{
    class AddressBookManager
    {
        private List<Contact> addressBook;

        public AddressBookManager()
        {
            addressBook = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            addressBook.Add(contact);
        }

        public List<Contact> GetAddressBook()
        {
            return addressBook;
        }

        public Contact GetContactByName(string firstName, string lastName)
        {
            return addressBook.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
        }

        public void DeleteContactByName(string firstName, string lastName)
        {
            Contact contactToDelete = GetContactByName(firstName, lastName);
            if (contactToDelete != null)
            {
                addressBook.Remove(contactToDelete);
                Console.WriteLine("Contact deleted successfully!");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
    }
}
