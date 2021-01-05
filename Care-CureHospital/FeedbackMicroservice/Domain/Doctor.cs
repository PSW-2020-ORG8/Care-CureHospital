using FeedbackMicroservice.Repository;
using System;


namespace FeedbackMicroservice.Domain
{
    public class Doctor : IIdentifiable <int>
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Specialitation  { get; set; }


        public Doctor(string name, string surname, string specialitation)
           
        {
            Name = name;
            Surname = surname;
            Specialitation = specialitation;
        }

        public int GetId()
        {
            throw new NotImplementedException();
        }

        public void SetId(int id)
        {
            throw new NotImplementedException();
        }
    }
}