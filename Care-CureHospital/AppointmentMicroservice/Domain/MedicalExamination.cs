namespace AppointmentMicroservice.Domain
{
   public class MedicalExamination : Term, IIdentifiable<int>
    {
        public int Id { get; set; }
        public string ShortDescription { get; set; }
        public bool SurveyFilled { get; set; }
        public int RoomId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public virtual Room Room { get; set; }    

        public MedicalExamination(int id)
        {
            Id = id;
        }

        public MedicalExamination()
        {
        }


        public MedicalExamination(int id, bool urgency, string shortDescription, int roomId, int doctorId, int patientId, Room room) : this(id)
        {
            SurveyFilled = urgency;
            ShortDescription = shortDescription;
            RoomId = roomId;
            DoctorId = doctorId;
            PatientId = patientId;
            Room = room;
           
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
