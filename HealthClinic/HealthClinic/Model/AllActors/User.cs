/***********************************************************************
 * Module:  User.cs
 * Author:  Stefan
 * Purpose: Definition of the Class AllActors.User
 ***********************************************************************/

using HealthClinic.Repository;
using System;

namespace Model.AllActors
{
   public class User : Person, IIdentifiable<int>
    {
        private String username;
        private String password;
        public int Id { get; set; }

        public string UserName { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public User(int id)
        {
            Id = id;
        }

        public User()
        {
        }

        public User(int id, string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city) 
            : base(name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)
        {
            this.username = username;
            this.Password = password;
            Id = id;
        }


        public User(string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city)
           : base(name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)
        {
            this.username = username;
            this.Password = password;
            
        }

        public User(string username, string password)
        {
            this.username = username;
            this.Password = password;
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