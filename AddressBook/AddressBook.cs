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

        public List<Contact> SearchByCity(string city)
        {
            if (CityPersonDictionary.TryGetValue(city, out List<Contact>? cityContacts))
            {
                return cityContacts;
            }
            return new List<Contact>();
        }

        public List<Contact> SearchByState(string state)
        {
            if (StatePersonDictionary.TryGetValue(state, out List<Contact>? stateContacts))
            {
                return stateContacts;
            }
            return new List<Contact>();
        }


        public void SortContactsByName()
        {
            contacts.Sort((contact1, contact2) =>
            {
                int result = contact1.LastName.CompareTo(contact2.LastName);
                if (result == 0)
                {
                    result = contact1.FirstName.CompareTo(contact2.FirstName);
                }
                return result;
            });
        }

        public void SortContactsByCity()
        {
            contacts.Sort((contact1, contact2) => contact1.City.CompareTo(contact2.City));
        }

        public void SortContactsByState()
        {
            contacts.Sort((contact1, contact2) => contact1.State.CompareTo(contact2.State));
        }

        public void SortContactsByZip()
        {
            contacts.Sort((contact1, contact2) => contact1.ZipCode.CompareTo(contact2.ZipCode));
        }
    }
}
