using AppointmentMicroservice.Domain;
using static AppointmentMicroservice.Repository.IRepository;

namespace AppointmentMicroservice.Repository
{
    public interface IMedicalExaminationRepository : IRepository<MedicalExamination, int>
    {
       

    }
}