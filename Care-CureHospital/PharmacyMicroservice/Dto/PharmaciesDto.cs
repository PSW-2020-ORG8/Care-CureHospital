using System;

namespace PharmacyMicroservice.Dto
{
    public class PharmaciesDto
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Key { get; set; }

        public String Link { get; set; }

        public PharmaciesDto()
        {
        }
    }
}
