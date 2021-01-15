using System;
using UserMicroservice.Domain.Enum;
using UserMicroservice.Domain.ValueObjects;

namespace UserMicroservice.Domain
{
    public class Person
    {
        public PersonalInfo PersonalInfo { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }

        public Person()
        {
        }

        public Person(PersonalInfo personalInfo, ContactInfo contactInfo, int cityId)
        {
            PersonalInfo = personalInfo;
            ContactInfo = contactInfo;
            CityId = cityId;
        }
    }
}

