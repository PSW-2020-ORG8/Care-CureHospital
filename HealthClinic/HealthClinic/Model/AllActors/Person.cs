/***********************************************************************
 * Module:  Actor.cs
 * Author:  Stefan
 * Purpose: Definition of the Class AllActors.Actor
 ***********************************************************************/

using System;

namespace Model.AllActors
{
    public class Person
    {
        private String name;
        private String surname;
        private String jmbg;
        private DateTime dateOfBirth;
        private String contactNumber;
        private String emailAddress;
        private City city;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Jmbg { get => jmbg; set => jmbg = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string ContactNumber { get => contactNumber; set => contactNumber = value; }
        public string EMail { get => emailAddress; set => emailAddress = value; }
        public City City { get => city; set => city = value; }

        public Person()
        {
        }

        public Person(string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city)
        {
            this.Name = name;
            this.Surname = surname;
            this.Jmbg = jmbg;
            this.DateOfBirth = dateOfBirth;
            this.ContactNumber = contactNumber;
            this.emailAddress = emailAddress;
            this.City = city;
        }
    
    }
}