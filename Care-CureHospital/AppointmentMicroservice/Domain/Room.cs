using AppointmentMicroservice.Repository;
using System;
using System.Collections.Generic;

namespace AppointmentMicroservice.Domain
{
    public class Room : Term, IIdentifiable<int>
    {
        public int Id { get; set; }
        public string RoomId { get; set; }
        public int DoctorId { get; set; }

        public Room()
        {
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
