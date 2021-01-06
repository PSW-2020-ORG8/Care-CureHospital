using AppointmentMicroservice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroservice.Gateway.Interface
{
    public interface IDoctorGateway
    {
        public List<Doctor> GetAllDoctors();
        public Doctor GetDoctorById(int doctorId);
    }
}
