using DocumentsMicroservice.Domain;
using System.Net.Mail;

namespace DocumentsMicroservice.Service
{
    public interface IMedicalRecordService : IService<MedicalRecord, int>
    {
        public MedicalRecord GetMedicalRecordForPatient(int patientID);
        public MedicalRecord FindPatientMedicalRecordByUsername(string username);
        public void ActivatePatientMedicalRecord(int medicalRecordId);
        public MedicalRecord CreatePatientMedicalRecord(MailAddress email, MedicalRecord medicalRecord, string username);
        public MedicalRecord GetMedicalRecordByPatient(Patient patient);
        public void WritePatientProfilePictureInFile(string patientUsername, string profilePicture);
    }
}
