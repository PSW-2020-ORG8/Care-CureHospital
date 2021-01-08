using DocumentsMicroservice.Domain.Enum;
using DocumentsMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Domain
{
    public class Patient : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public string Jmbg { get; set; }
        public string IdentityCard { get; set; }
        public string HealthInsuranceCard { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string EMail { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }

        public Patient()
        {
        }

        public Patient(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public Patient(int id, string username, string password, string name, string parentName, string surname, Gender gender, string jmbg, string identityCard, string healthInsuranceCard, BloodGroup bloodGroup, DateTime dateOfBirth, string contactNumber, string eMail, int cityId, City city)
        {
            Id = id;
            Username = username;
            Password = password;
            Name = name;
            ParentName = parentName;
            Surname = surname;
            Gender = gender;
            Jmbg = jmbg;
            IdentityCard = identityCard;
            HealthInsuranceCard = healthInsuranceCard;
            BloodGroup = bloodGroup;
            DateOfBirth = dateOfBirth;
            ContactNumber = contactNumber;
            EMail = eMail;
            CityId = cityId;
            City = city;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
