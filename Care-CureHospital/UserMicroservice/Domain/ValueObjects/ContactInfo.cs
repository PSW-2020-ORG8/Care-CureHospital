using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Domain.ValueObjects
{
    [ComplexType]
    public class ContactInfo
    {
        public string EMail { get; set; }
        public string ContactNumber { get; set; }

        public ContactInfo() { }
        public ContactInfo(string eMail, string contactNumber)
        {
            EMail = eMail;
            ContactNumber = contactNumber;
        }
    }
}
