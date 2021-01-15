using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Domain.Enum;

namespace UserMicroservice.Domain.ValueObjects
{
    [ComplexType]
    public class MedicalInfo
    {
        
        public string HealthInsuranceCard { get; set; }
        public BloodGroup BloodGroup { get; set; }

        public MedicalInfo() {  }

        public MedicalInfo(string healthInsuranceCard, BloodGroup bloodGroup)
        {
            HealthInsuranceCard = healthInsuranceCard;
            BloodGroup = bloodGroup;
        }
    }
}
