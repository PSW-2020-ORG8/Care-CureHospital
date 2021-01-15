using UserMicroservice.Domain;
using UserMicroservice.Dto;

namespace UserMicroservice.Mapper
{
    public class PatientMapper
    {
        

        public static PatientDto PatientToPatientDto(Patient patient, int numberOfCancelledAppointments)
        {
            PatientDto dto = new PatientDto();
            dto.Id = patient.Id;
            dto.Username = patient.AccountInfo.Username;
            dto.Name = patient.PersonalInfo.Name;
            dto.Surname = patient.PersonalInfo.Surname;
            dto.NumberOfCancelledAppointents = numberOfCancelledAppointments;
            dto.Malicious = patient.PatientStatus.Malicious;
            dto.Blocked = patient.PatientStatus.Blocked;
            return dto;
        }
    }
}
