using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyMicroservice.Domain
{
    public class APIKey
    {
        [Key]
        public String Key { get; set; }

        public APIKey()
        {
        }

        public APIKey(String key)
        {
            Key = key;
        }
    }
}
