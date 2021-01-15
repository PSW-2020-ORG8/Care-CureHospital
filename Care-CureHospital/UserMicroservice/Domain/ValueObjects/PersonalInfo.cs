using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Domain.Enum;

namespace UserMicroservice.Domain.ValueObjects
{
    [ComplexType]
    public class PersonalInfo
    {
        public PersonalInfo(string name, string parentName, string surname, Gender gender, string jmbg, DateTime dateOfBirth, string identityCard)
        {
            Name = name;
            ParentName = parentName;
            Surname = surname;
            Gender = gender;
            Jmbg = jmbg;
            DateOfBirth = dateOfBirth;
            IdentityCard = identityCard;
        }

        public string Name { get; set; }
        public string ParentName { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public string Jmbg { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentityCard { get; set; }

        public PersonalInfo() { }
        public bool HasJMBG(string jmbg)
        {
            return (Jmbg.Equals(jmbg) ? true : false);
        }
    }
}
