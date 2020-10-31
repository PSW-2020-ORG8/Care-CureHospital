/***********************************************************************
 * Module:  Patient.cs
 * Author:  Stefan
 * Purpose: Definition of the Class AllActors.Patient
 ***********************************************************************/

using Model.PatientDoctor;
using System;

namespace Model.AllActors
{
    public class Patient : User
    {
        private Boolean guestAccount;
        private MedicalRecord medicalRecord;

        public bool GuestAccount { get => guestAccount; set => guestAccount = value; }
        public MedicalRecord MedicalRecord { get => medicalRecord; set => medicalRecord = value; }

        public Patient(int id, string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city,
            bool guestAccount, MedicalRecord medicalRecord)
            : base(id, username, password, name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)
        {
            this.guestAccount = guestAccount;
            this.medicalRecord = medicalRecord;
        }

        public Patient(string username, string password, string name, string surname, string jmbg, DateTime dateOfBirth, string contactNumber, string emailAddress, City city,
            bool guestAccount, MedicalRecord medicalRecord)
            : base(username, password, name, surname, jmbg, dateOfBirth, contactNumber, emailAddress, city)

        {
            this.guestAccount = guestAccount;
            this.medicalRecord = medicalRecord;
        }      

        public Patient(int id) : base(id)
        {
        }

        public Patient()
        {
        }

    }
}