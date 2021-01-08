using FeedbackMicroservice.Repository;
using System;


namespace FeedbackMicroservice.Domain
{
    public class Doctor : IIdentifiable <int>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Specialitation Specialitation  { get; set; }

        public Doctor(string name, string surname, string username, Specialitation specialitation)        
        {
            Name = name;
            Surname = surname;
            Username = username;
            Specialitation = specialitation;
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