using AppointmentMicroservice.Repository;
using System;

namespace AppointmentMicroservice.Domain
{
    public class Appointment : IIdentifiable<int>
    {
        public int Id { get; set; }
        public bool Canceled { get; set; }
        public DateTime CancellationDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MedicalExaminationId { get; set; }
        public virtual MedicalExamination MedicalExamination { get; set; }
        public int DoctorWorkDayId { get; set; }
      

        public Appointment()
        {
        }

        public Appointment(int id, bool canceled, DateTime startTime, int medicalExaminationId, MedicalExamination medicalExamination, int doctorWorkDayId)
        {
            Id = id;
            Canceled = canceled;
            StartTime = startTime;
            EndTime = StartTime.AddMinutes(30);
            MedicalExaminationId = medicalExaminationId;
            MedicalExamination = medicalExamination;
            DoctorWorkDayId = doctorWorkDayId;
        }

        public Appointment(int id, bool canceled, DateTime cancellationDate, DateTime startTime, int medicalExaminationId, MedicalExamination medicalExamination, int doctorWorkDayId)
        {
            Id = id;
            Canceled = canceled;
            CancellationDate = cancellationDate;
            StartTime = startTime;
            EndTime = StartTime.AddMinutes(30);
            MedicalExaminationId = medicalExaminationId;
            MedicalExamination = medicalExamination;
            DoctorWorkDayId = doctorWorkDayId;
           
        }

        public Appointment(int id, bool canceled, DateTime startTime, DateTime endTime)
        {
            Id = id;
            Canceled = canceled;
            StartTime = startTime;
            EndTime = endTime;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
