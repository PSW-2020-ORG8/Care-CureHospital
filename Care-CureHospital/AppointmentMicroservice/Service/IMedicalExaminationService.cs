using AppointmentMicroservice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroservice.Service
{
    public interface IMedicalExaminationService : IService<MedicalExamination, int>
    {
        public List<MedicalExamination> GetByDate(DateTime date);
    }
}