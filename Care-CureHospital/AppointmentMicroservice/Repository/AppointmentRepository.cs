using AppointmentMicroservice.Domain;
using AppointmentMicroservice.Repository.MySQL;
using AppointmentMicroservice.Repository.MySQL.Stream;


namespace AppointmentMicroservice.Repository
{
    public class AppointmentRepository : MySQLRepository<Appointment, int>, IAppointmentRepository
    {
        public AppointmentRepository(IMySQLStream<Appointment> stream)
            : base(stream)
        {
        }
    }
}
