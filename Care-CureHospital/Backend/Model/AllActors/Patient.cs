/***********************************************************************
 * Module:  Patient.cs
 * Author:  Stefan
 * Purpose: Definition of the Class AllActors.Patient
 ***********************************************************************/

using Model.PatientDoctor;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.AllActors
{
    public class Patient : User
    {
        public Boolean GuestAccount { get; set; }
        public int MedicalRecordId { get; set; }
        [NotMapped]
        public virtual MedicalRecord MedicalRecord { get; set; }

        public Patient(int id, string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city,
            bool guestAccount, MedicalRecord medicalRecord)
            : base(id, username, password, name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)
        {
            this.GuestAccount = guestAccount;
            this.MedicalRecord = medicalRecord;
        }

        public Patient(string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city,
            bool guestAccount, MedicalRecord medicalRecord)
            : base(username, password, name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)

        {
            this.GuestAccount = guestAccount;
            this.MedicalRecord = medicalRecord;
        }      

        public Patient(int id) : base(id)
        {
        }


        public Patient()
        {
        }

    }
}