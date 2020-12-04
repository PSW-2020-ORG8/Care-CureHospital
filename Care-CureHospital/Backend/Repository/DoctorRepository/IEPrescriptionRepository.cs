using Backend.Model.PatientDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository;

namespace Backend.Repository.DoctorRepository
{
    public interface IEPrescriptionRepository : IRepository<EPrescription, int>
    {
    }
}
