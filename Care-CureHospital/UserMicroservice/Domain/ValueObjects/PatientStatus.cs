using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroservice.Domain.ValueObjects
{
    public class PatientStatus
    {
        public bool Blocked { get; set; }
        public bool Malicious { get; set; }
        public PatientStatus() { }
    }
}
