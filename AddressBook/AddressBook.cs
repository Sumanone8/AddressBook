using System;
using System.Collections.Generic;
using System.IO;

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

        public void AddContact(Contact contact)
        {
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

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Contact contact in contacts)
                {
                    writer.WriteLine(contact.ToString());
                }
            }
        }

        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 8)
                        {
                            Contact contact = new Contact(
                                parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7]
                            );
                            contacts.Add(contact);
                        }
                    }
                }
            }
        }

        public List<Contact> GetContacts()
        {
            return contacts;
        }
    }
}
