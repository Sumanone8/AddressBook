﻿using System;
using System.Collections.Generic;

namespace AddressBook
{
    class AddressBook
    {
        public string Name { get; private set; }
        private List<Contact> contacts;

        public AddressBook(string name)
        {
            Name = name;
            contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public List<Contact> GetContacts()
        {
            return contacts;
        }

        public Contact GetContactByName(string firstName, string lastName)
        {
            return contacts.Find(c => c.FirstName == firstName && c.LastName == lastName);
        }

        public void DeleteContactByName(string firstName, string lastName)
        {
            Contact contactToDelete = GetContactByName(firstName, lastName);
            if (contactToDelete != null)
            {
                contacts.Remove(contactToDelete);
                Console.WriteLine("Contact deleted successfully!");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
    }
}
