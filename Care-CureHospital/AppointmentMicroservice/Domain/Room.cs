using AppointmentMicroservice.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentMicroservice.Domain
{
    public class Room : Term, IIdentifiable<int>
    {
        public int Id { get; set; }
        public string RoomId { get; set; }
        public int DoctorId { get; set; }
        [NotMapped]
        public virtual Doctor Doctor { get; set; }

        public Room()
        {
        }

        public Room(int id, string roomId, int doctorId, Doctor doctor)
        {
            Id = id;
            RoomId = roomId;
            DoctorId = doctorId;
            Doctor = doctor;
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
