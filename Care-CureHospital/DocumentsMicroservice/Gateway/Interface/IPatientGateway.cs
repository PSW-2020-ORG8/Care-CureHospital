using DocumentsMicroservice.Domain;

namespace DocumentsMicroservice.Gateway.Interface
{
    public interface IPatientGateway
    {
        public bool DoesUsernameExist(string username);
        public Patient GetPatientById(int patientId);
        public Patient AddPateint(Patient patient);
        public Patient GetPatientByUsername(string username);
    }
}
