using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Domain.ValueObjects;

namespace UserMicroservice.Domain
{
    public class Patient : User
    {
        public MedicalInfo MedicalInfo { get; set; }

        public PatientStatus PatientStatus { get; set; }

        public Patient()
        {
        }

        public Patient(MedicalInfo medicalInfo, PatientStatus patientStatus)
        {
            MedicalInfo = medicalInfo;
            PatientStatus = patientStatus;
        }

        public bool isBlocked()
        {
            return PatientStatus.Blocked;
        }
    }
}
