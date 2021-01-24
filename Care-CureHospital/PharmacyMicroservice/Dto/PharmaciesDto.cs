using PharmacyMicroservice.Domain;
using System;

namespace PharmacyMicroservice.Dto
{
    public class PharmaciesDto
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public APIKey Key { get; set; }

        public EndPoint Link { get; set; }

        public PharmaciesDto()
        {
        }
    }
}