using AppointmentMicroservice.Domain;
using AppointmentMicroservice.Repository.MySQL;
using AppointmentMicroservice.Repository.MySQL.Stream;


namespace AppointmentMicroservice.Repository
{
    public class DoctorWorkDayRepository : MySQLRepository<DoctorWorkDay, int>, IDoctorWorkDayRepository
    {
        public DoctorWorkDayRepository(IMySQLStream<DoctorWorkDay> stream)
            : base(stream)
        {
        }
    }
}

