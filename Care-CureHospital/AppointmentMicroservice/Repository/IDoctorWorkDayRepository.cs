using AppointmentMicroservice.Domain;
using static AppointmentMicroservice.Repository.IRepository;

namespace AppointmentMicroservice.Repository
{
    public interface IDoctorWorkDayRepository : IRepository<DoctorWorkDay, int>
    {
    }
}
