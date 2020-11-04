/***********************************************************************
 * Module:  Actor.cs
 * Author:  Stefan
 * Purpose: Definition of the Class AllActors.Actor
 ***********************************************************************/

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.AllActors
{
    public class Person
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Jmbg { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String ContactNumber { get; set; }
        public String EMail { get; set; }
        public int cityID { get; set; }
        [NotMapped]
        public virtual City City { get; set; }

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
            this.EMail = emailAddress;
            this.City = city;
        }
    
    }
}