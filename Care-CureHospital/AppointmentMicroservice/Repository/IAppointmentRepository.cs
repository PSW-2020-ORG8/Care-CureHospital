using AppointmentMicroservice.Domain;
using static AppointmentMicroservice.Repository.IRepository;

namespace AppointmentMicroservice.Repository
{
    public interface IAppointmentRepository : IRepository<Appointment, int>
    {
    }
}
