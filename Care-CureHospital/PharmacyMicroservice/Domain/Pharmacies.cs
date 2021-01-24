using PharmacyMicroservice.Repository;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyMicroservice.Domain
{
    public class Pharmacies : IIdentifiable<int>
    {
        public int Id { get; set; }

        public String Name { get; set; }

        [NotMapped]
        public virtual EndPoint Link { get; set; }

        [NotMapped]
        public virtual APIKey Key { get; set; }

        public Pharmacies(int id, String name, EndPoint link, APIKey key)
        {
            Id = id;
            Name = name;
            Key = key;
            Link = link;
        }

        public Pharmacies(String name, EndPoint link, APIKey key)
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

       
    }
}