using AppointmentMicroservice.Domain;
using System;
using System.Collections.Generic;

namespace AppointmentMicroservice.Service
{
    public interface IMedicalExaminationService : IService<MedicalExamination, int>
    {
        public List<MedicalExamination> GetByDate(DateTime date);
    }
}