﻿using DocumentsMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsMicroservice.Domain
{
    public class MedicalExamination : IIdentifiable<int>
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient{ get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public MedicalExamination()
        {
        }

        public MedicalExamination(int id, int doctorId, Doctor doctor, int patientId, Patient patient, int roomId, Room room)
        {
            Id = id;
            DoctorId = doctorId;
            Doctor = doctor;
            PatientId = patientId;
            Patient = patient;
            RoomId = roomId;
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
