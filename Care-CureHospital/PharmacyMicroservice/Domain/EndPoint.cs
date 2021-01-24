using System;
using System.ComponentModel.DataAnnotations;

namespace PharmacyMicroservice.Domain
{
    public class EndPoint
    {
        [Key]
        public String Link { get; set; } 
        
        public EndPoint()
        {
        }

        public EndPoint(String link)
        {
          Link = link;
        }
    }
}
