using System;
using System.Collections.Generic;

namespace AddressBook
{
    class AddressBook
    {
        public string Name { get; private set; }
        private List<Contact> contacts;
        public Dictionary<string, List<Contact>> CityPersonDictionary { get; private set; }
        public Dictionary<string, List<Contact>> StatePersonDictionary { get; private set; }

        public AddressBook(string name)
        {
            Name = name;
            contacts = new List<Contact>();
            CityPersonDictionary = new Dictionary<string, List<Contact>>();
            StatePersonDictionary = new Dictionary<string, List<Contact>>();
        }

        public bool AddContact(Contact contact)
        {
            if (contacts.Contains(contact))
            {
                Console.WriteLine("Duplicate entry: Contact already exists.");
                return false;
            }

            contacts.Add(contact);

            if (!CityPersonDictionary.ContainsKey(contact.City))
            {
                CityPersonDictionary[contact.City] = new List<Contact>();
            }
            CityPersonDictionary[contact.City].Add(contact);

            if (!StatePersonDictionary.ContainsKey(contact.State))
            {
                StatePersonDictionary[contact.State] = new List<Contact>();
            }
            StatePersonDictionary[contact.State].Add(contact);

            return true;
        }

        public List<Contact> GetContacts()
        {
            return contacts;
        }

        public Contact? GetContactByName(string firstName, string lastName)
        {
            return contacts.Find(c => c.FirstName == firstName && c.LastName == lastName);
        }

        public void DeleteContactByName(string firstName, string lastName)
        {
            Contact? contactToDelete = GetContactByName(firstName, lastName);
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

        public List<Contact> SearchByCity(string city)
        {
            return CityPersonDictionary.TryGetValue(city, out List<Contact> contacts) ? contacts : new List<Contact>();
        }

        public List<Contact> SearchByState(string state)
        {
            return StatePersonDictionary.TryGetValue(state, out List<Contact> contacts) ? contacts : new List<Contact>();
        }

        public int GetContactsCountByCity(string city)
        {
            return CityPersonDictionary.TryGetValue(city, out List<Contact> contacts) ? contacts.Count : 0;
        }

        public int GetContactsCountByState(string state)
        {
            return StatePersonDictionary.TryGetValue(state, out List<Contact> contacts) ? contacts.Count : 0;
        }
    }
}