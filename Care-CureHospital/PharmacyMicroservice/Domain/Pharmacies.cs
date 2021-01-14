using PharmacyMicroservice.Repository;
using System;

namespace PharmacyMicroservice.Domain
{
    public class Pharmacies : IIdentifiable<int>
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Key { get; set; }

        public String Link { get; set; }

        public Pharmacies(int id, String name, String key, String link)
        {
            Id = id;
            Name = name;
            Key = key;
            Link = link;
        }

        public Pharmacies(String name, String key, String link)
        {
            Name = name;
            Key = key;
            Link = link;
        }

        public Pharmacies(String name)
        {
            Name = name;
        }

        public Pharmacies()
        {

        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public String GetName()
        {
            return Name;
        }

        public void SetName(String name)
        {
            Name = name;
        }

        public String GetKey()
        {
            return Key;
        }

        public void SetKey(String key)
        {
            Key = key;
        }

        public String GetLink()
        {
            return Link;
        }

        public void SetLink(String link)
        {
            Link = link;
        }
    }
}
