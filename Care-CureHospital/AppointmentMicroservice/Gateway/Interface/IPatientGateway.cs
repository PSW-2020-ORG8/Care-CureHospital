using AppointmentMicroservice.Domain;

namespace AppointmentMicroservice.Gateway.Interface
{
    public interface IPatientGateway
    {
        public Patient GetPatientById(int patientId);
        public Patient SetMaliciousPatient(int patientId);
    }
}
