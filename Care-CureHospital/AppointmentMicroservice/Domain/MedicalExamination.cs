using AppointmentMicroservice.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentMicroservice.Domain
{
   public class MedicalExamination : Term, IIdentifiable<int>
    {
        public int Id { get; set; }
        public string ShortDescription { get; set; }
        public bool SurveyFilled { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public int DoctorId { get; set; }
        [NotMapped]
        public virtual Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        [NotMapped]
        public virtual Patient Patient { get; set; }

        public MedicalExamination(int id)
        {
            Id = id;
        }

        public MedicalExamination()
        {
        }

        public MedicalExamination(int id, string shortDescription, bool surveyFilled, int roomId, Room room, int doctorId, Doctor doctor, int patientId, Patient patient) : this(id)
        {
            Id = id;
            ShortDescription = shortDescription;
            SurveyFilled = surveyFilled;
            RoomId = roomId;
            Room = room;
            DoctorId = doctorId;
            Doctor = doctor;
            PatientId = patientId;
            Patient = patient;
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
