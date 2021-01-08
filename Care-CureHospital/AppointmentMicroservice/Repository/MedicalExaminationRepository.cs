using AppointmentMicroservice.Domain;
using AppointmentMicroservice.Repository.MySQL;
using AppointmentMicroservice.Repository.MySQL.Stream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroservice.Repository
{
    public class MedicalExaminationRepository : MySQLRepository<MedicalExamination, int>, IMedicalExaminationRepository
    {
        public MedicalExaminationRepository(IMySQLStream<MedicalExamination> stream)
            : base(stream)
        {
        }
    }
}